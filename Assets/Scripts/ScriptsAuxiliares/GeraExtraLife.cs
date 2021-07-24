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

    public int randextralife;

    public int cargExtraLife;
    public int indexExtraLife;

    public float desloCanvasX, desloCanvasY;

    void Start()
    {
        //num_Maxextralife = Random.Range(1, 7);
        //decrementaEnerg = 0;
        if(tocando == false)
        Gera_extralife();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.CompareTag("collReceptLazer"))
        {
           // randextralife = Random.Range(0, 7);
            //if(collPegEnergy.IsTouching(coll))
            tocando = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("collReceptLazer"))
        {
            tocando = false;

            //if (randextralife != 0)
            //{
                Gera_extralife();
            //}
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
