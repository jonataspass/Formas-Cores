using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class GeraMissel : MonoBehaviour
{
    public GameObject prefab_missel;

    GameObject new_missel;

    public bool tocando;
    public int num_Missel;

    public int cargMissel;

    public float desloCanvasX, desloCanvasY;

    //testando new adiction
    public GameObject portalMissel;
    public Animator destroiPortalMissel;

    void Start()
    {
        if (tocando == false)
            Gera_Missel();
    }

    public void Gera_Missel()
    {
        if (num_Missel > 0 && tocando == false && new_missel == null)
        {
            new_missel = Instantiate(prefab_missel) as GameObject;
            CarregaMissel cargM = new_missel.GetComponent<CarregaMissel>();
            cargM.carga = cargMissel;
            cargM.numRepeteCarga = num_Missel;
            cargM.desloCanvasX = desloCanvasX;
            cargM.desloCanvasY = desloCanvasY;
            new_missel.transform.position = gameObject.transform.position;
            num_Missel -= 1;
        }
        else if (num_Missel == 0)
        {
            destroiPortalMissel.Play("animePortalMissel");
            Destroy(portalMissel, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("collReceptLazer"))
        {
            tocando = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("collReceptLazer"))
        {
            tocando = false;

            Gera_Missel();
        }
    }
}
