using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PegaMoedasZ : MonoBehaviour
{
    public GameObject prefab_moeda;
    GameObject new_moeda;

    public int qtdmoedaTxt;

    //AudioSource audio_pegaMissel;

    //public Animator animacarregaMissel;
    public TextMeshProUGUI text_itemMoeda;

    //public Collider2D pegaMoeda;

    public Canvas txt_numMoeda;
    public float desloCanvasX, desloCanvasY;

    void Start()
    {
        //text_itemMoeda = GetComponentInChildren<TextMeshProUGUI>();
        text_itemMoeda.text = qtdmoedaTxt.ToString() + "x";

        txt_numMoeda = GetComponentInChildren<Canvas>();
        txt_numMoeda.transform.position = new Vector2(txt_numMoeda.transform.position.x + desloCanvasX, txt_numMoeda.transform.position.y + desloCanvasY);
    }

    private void Update()
    {
        //Ligacoll();
    }

    //public bool pegouMoeda;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("collReceptLazer"))
        {
            new_moeda = Instantiate(prefab_moeda) as GameObject;
            new_moeda.transform.position = gameObject.transform.position;
            Coleta_Moeda();
            //animacarregaMissel.Play("AnimecarregaMissel");
            //print("toou");
        }
    }

    void Coleta_Moeda()
    {
        GAMEMANAGER.instance.qtd_moedaSalvas += 10;
        GAMEMANAGER.instance.moedaPegas += 1;
        Destroy(gameObject);
    }
}
