using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraMoedasZ : MonoBehaviour
{
    public GameObject prefab_moeda;

    GameObject new_moeda;

    public bool tocando;
    int num_Moeda;
    public int num_MaxMoeda;

    // public int randMissel;

    public int qtdMoeda;

    public float desloCanvasX, desloCanvasY;

    void Start()
    {
        if (tocando == false)
        {
            print("tocando");
            Gera_Moeda();
        }            
    }

    void Gera_Moeda()
    {
        if ( num_Moeda < num_MaxMoeda && tocando == false && new_moeda == null)
        {
            StartCoroutine(WaitGeraObj());
        }
    }

    IEnumerator WaitGeraObj()
    {
        yield return new WaitForSeconds(0.5f);
        new_moeda = Instantiate(prefab_moeda) as GameObject;
        PegaMoedasZ itemMoedas = new_moeda.GetComponent<PegaMoedasZ>();
        //cargM.qtdMoeda = qtdMoeda;
        itemMoedas.desloCanvasX = desloCanvasX;
        itemMoedas.desloCanvasY = desloCanvasY;
        itemMoedas.qtdmoedaTxt = qtdMoeda;

        if(qtdMoeda > 1)
        {
            qtdMoeda -= 1;
        }

        new_moeda.transform.position = gameObject.transform.position;
        num_Moeda += 1;
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
            Gera_Moeda();
            //}
        }
    }
}
