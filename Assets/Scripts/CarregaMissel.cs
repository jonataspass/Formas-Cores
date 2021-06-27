using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarregaMissel : MonoBehaviour
{
    CircleManager circleManager;

    public int carga;

    AudioSource audio_pegaMissel;

    public Animator animacarregaMissel;
    public TextMeshProUGUI text_itemMissel;

    public Collider2D pegaMissel;

    public Canvas txt_numMissel;
    public float desloCanvasX, desloCanvasY;

    void Start()
    {
        circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();
        audio_pegaMissel = GetComponent<AudioSource>();
        animacarregaMissel = GetComponent<Animator>();
        animacarregaMissel.Play("AnimeGeraMissel");
        text_itemMissel = GetComponentInChildren<TextMeshProUGUI>();
        text_itemMissel.text = carga.ToString();
        pegaMissel = GetComponent<Collider2D>();
        pegaMissel.enabled = false;

        txt_numMissel = GetComponentInChildren<Canvas>();
        txt_numMissel.transform.position = new Vector2(txt_numMissel.transform.position.x + desloCanvasX, txt_numMissel.transform.position.y + desloCanvasY);

    }

    private void Update()
    {
        Ligacoll();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("collReceptLazer"))
        {
            Carrega_Missel(carga);
            animacarregaMissel.Play("AnimecarregaMissel");
        }
    }

    void Carrega_Missel(int carga)
    {
        //recebe misseis coletas no startgame
        GAMEMANAGER.instance.cargaMissel += carga;       
        
        //UIManager.instance.txt_showNmissel.text = GAMEMANAGER.instance.cargaMissel.ToString();
        audio_pegaMissel.Play();
        Destroy(gameObject, 1.5f);

    }

    void Ligacoll()
    {
        if (GAMEMANAGER.instance.startGame == true)
        {
            pegaMissel.enabled = true;
        }
    }

}
