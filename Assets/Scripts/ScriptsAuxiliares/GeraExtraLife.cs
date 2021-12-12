using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraExtraLife : MonoBehaviour
{
    public GameObject prefab_extralife;

    GameObject new_extralife;

    public bool tocando;
    public int num_extralife;
    //public int num_Maxextralife;

    public int cargExtraLife;
    public int indexExtraLife;

    public float desloCanvasX, desloCanvasY;

    //new adiction
    //variáveis usadas quando player usar tentativas extras
    public int extra_num_extralife;
    public int extra_num_Maxextralife;
    public int extra_cargExtraLife;

    //testando new adiction
    public GameObject portalExtraLife;
    public Animator destroiPortalExtralife;

    void Start()
    {
        if (tocando == false)
            Gera_extralife();

        //new adiction
        extra_num_extralife = num_extralife;
        extra_cargExtraLife = cargExtraLife;
    }

    private void Update()
    {
            if (tocando == false)
                Gera_extralife();

            //new adiction
            extra_num_extralife = num_extralife;
            extra_cargExtraLife = cargExtraLife;
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
        if (num_extralife > 0 && tocando == false && new_extralife == null)
        {
            new_extralife = Instantiate(prefab_extralife) as GameObject;
            PegaEnergy extraL = new_extralife.GetComponent<PegaEnergy>();
            extraL.carga = cargExtraLife;
            extraL.index = indexExtraLife;
            extraL.numRepetCarga = num_extralife;
            extraL.desloCanvasX = desloCanvasX;
            extraL.desloCanvasY = desloCanvasY;
            new_extralife.transform.position = gameObject.transform.position;
            num_extralife -= 1;
        }
        else if(num_extralife == 0 && destroiPortalExtralife != null)
        {
            destroiPortalExtralife.Play("animeDestroiPortal"); 
            Destroy(portalExtraLife, 1);
        }
    }
}
