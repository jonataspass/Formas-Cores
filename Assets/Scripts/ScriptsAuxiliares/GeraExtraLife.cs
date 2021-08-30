using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraExtraLife : MonoBehaviour
{
    public GameObject prefab_extralife;

    GameObject new_extralife;

    public bool tocando;
    public int num_extralife;
    public int num_Maxextralife;

    public int cargExtraLife;
    public int indexExtraLife;

    public float desloCanvasX, desloCanvasY;

    //new adiction
    //variáveis usadas quando player usa tentativas extras
    public int extra_num_extralife;
    public int extra_num_Maxextralife;
    public int extra_cargExtraLife;

    void Start()
    {
        if (tocando == false)
            Gera_extralife();

        //new adiction
        extra_num_extralife = num_extralife;
        extra_num_Maxextralife = num_Maxextralife;
        extra_cargExtraLife = cargExtraLife;
    }
    
    //new adiction
    private void Update()
    {
        //if(GAMEMANAGER.instance.num_tentativas > 0 && GAMEMANAGER.instance.getExtra == true)
        //{
        //    GAMEMANAGER.instance.getExtra = false;

        //     num_extralife = extra_num_extralife;
        //     num_Maxextralife = extra_num_Maxextralife;
        //     cargExtraLife = extra_cargExtraLife;
        //}       
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

            Gera_extralife();
        }
    }

    void Gera_extralife()
    {
        if (num_extralife < num_Maxextralife && tocando == false && new_extralife == null)
        {
            new_extralife = Instantiate(prefab_extralife) as GameObject;
            PegaEnergy extraL = new_extralife.GetComponent<PegaEnergy>();
            extraL.carga = cargExtraLife;
            extraL.index = indexExtraLife;
            extraL.desloCanvasX = desloCanvasX;
            extraL.desloCanvasY = desloCanvasY;
            new_extralife.transform.position = gameObject.transform.position;
            num_extralife += 1;
        }
    }
}
