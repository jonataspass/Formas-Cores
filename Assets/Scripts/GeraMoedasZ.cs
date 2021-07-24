using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraMoedasZ : MonoBehaviour
{
    public GameObject prefab_moeda;

    GameObject new_moeda;

    public bool tocando;
    //public int num_Moeda;
    public int num_MaxMoeda;

    // public int randMissel;

    public int qtdMoeda;

    public float desloCanvasX, desloCanvasY;

    //public CarregaMissel cargM;

    void Start()
    {

        if (tocando == false)
            Gera_Moeda();
    }

    void Gera_Moeda()
    {
        if ( num_MaxMoeda > 0 && tocando == false && new_moeda == null)
        {
            new_moeda = Instantiate(prefab_moeda) as GameObject;
            PegaMoedasZ cargM = new_moeda.GetComponent<PegaMoedasZ>();
            //cargM.qtdMoeda = qtdMoeda;
            cargM.desloCanvasX = desloCanvasX;
            cargM.desloCanvasY = desloCanvasY;
            GAMEMANAGER.instance.txt_numMoedaspref = num_MaxMoeda;
            //TextMeshProUGUI text_itemMissel = GetComponentInChildren<TextMeshProUGUI>();
            //cargM.text_itemMissel.text = cargM.carga.ToString();
            new_moeda.transform.position = gameObject.transform.position;
            //num_Moeda += 1;
            num_MaxMoeda--;
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
            Gera_Moeda();
            //}
        }
    }
}
