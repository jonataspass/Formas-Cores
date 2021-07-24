using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PegaMoedasZ : MonoBehaviour
{
    public GameObject prefab_moeda;
    GameObject new_moeda;

    //AudioSource audio_pegaMissel;

    //public Animator animacarregaMissel;
    public TextMeshProUGUI text_itemMoeda;

    public Collider2D pegaMissel;

    public Canvas txt_numMoeda;
    public float desloCanvasX, desloCanvasY;

    void Start()
    {
        //audio_pegaMissel = GetComponent<AudioSource>();
        //animacarregaMissel = GetComponent<Animator>();
        //animacarregaMissel.Play("AnimeGeraMissel");
        text_itemMoeda = GetComponentInChildren<TextMeshProUGUI>();
        text_itemMoeda.text = GAMEMANAGER.instance.txt_numMoedaspref.ToString() + "x";
        pegaMissel = GetComponent<Collider2D>();
        pegaMissel.enabled = false;

        txt_numMoeda = GetComponentInChildren<Canvas>();
        txt_numMoeda.transform.position = new Vector2(txt_numMoeda.transform.position.x + desloCanvasX, txt_numMoeda.transform.position.y + desloCanvasY);

    }

    private void Update()
    {
        Ligacoll();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("collReceptLazer"))
        {
            new_moeda = Instantiate(prefab_moeda) as GameObject;
            new_moeda.transform.position = gameObject.transform.position;
            Coleta_Moeda();
            //animacarregaMissel.Play("AnimecarregaMissel");
        }
    }

    void Coleta_Moeda()
    {
        //MoveUp();
        //recebe misseis coletas no startgame
        //GAMEMANAGER.instance.cargaMissel += carga;

        //UIManager.instance.txt_showNmissel.text = GAMEMANAGER.instance.cargaMissel.ToString();
        //audio_pegaMissel.Play();
        //qtdMoeda--;
        //qtdMoeda++;
        GAMEMANAGER.instance.qtd_moedaSalvas += 100;
        UIManager.instance.AtualizaMoedaZ(GAMEMANAGER.instance.qtd_moedaSalvas);
        Destroy(gameObject);
    }

    void Ligacoll()
    {
        if (GAMEMANAGER.instance.startGame == true)
        {
            pegaMissel.enabled = true;
        }
    }
}
