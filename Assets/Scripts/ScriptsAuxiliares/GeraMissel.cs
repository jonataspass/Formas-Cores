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
    public int num_MaxMissel;

   // public int randMissel;

    public int cargMissel;

    public float desloCanvasX, desloCanvasY;

    //public CarregaMissel cargM;

    void Start()
    {
        if (tocando == false)
            Gera_Missel();      
    }

    public void Gera_Missel()
    {
        if (num_Missel < num_MaxMissel && tocando == false && new_missel == null)
        {
            new_missel = Instantiate(prefab_missel) as GameObject;
            CarregaMissel cargM = new_missel.GetComponent<CarregaMissel>();
            cargM.carga = cargMissel;
            cargM.desloCanvasX = desloCanvasX;
            cargM.desloCanvasY = desloCanvasY;

            //TextMeshProUGUI text_itemMissel = GetComponentInChildren<TextMeshProUGUI>();
            //cargM.text_itemMissel.text = cargM.carga.ToString();
            new_missel.transform.position = gameObject.transform.position;
            num_Missel += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("collReceptLazer"))
        {
            //randMissel = Random.Range(0, 7);
            tocando = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("collReceptLazer"))
        {
            tocando = false;

            //if (randMissel != 0)
            //{
                Gera_Missel();
            //}
        }
    }
}
