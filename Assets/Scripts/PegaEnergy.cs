using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PegaEnergy : MonoBehaviour
{
    CircleManager circleManager;

    public int carga;
    public int index;

    AudioSource audio_pegaEnergy;

    Animator animacarregaEnergy;
    TextMeshProUGUI text_itemEnergy;

    public Collider2D pegaEnergy;

    public bool tocando;

    public Canvas txt_numExtraLife;
    public float desloCanvasX, desloCanvasY;

    void Start()
    {
        tocando = false;
        circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();
        audio_pegaEnergy = GetComponent<AudioSource>();
        animacarregaEnergy = GetComponent<Animator>();
        animacarregaEnergy.Play("animeGeraExtraLife");

        text_itemEnergy = GetComponentInChildren<TextMeshProUGUI>();
        text_itemEnergy.text = carga.ToString();
        pegaEnergy = GetComponent<Collider2D>();
        pegaEnergy.enabled = false;

        txt_numExtraLife = GetComponentInChildren<Canvas>();
        txt_numExtraLife.transform.position = new Vector2(txt_numExtraLife.transform.position.x + desloCanvasX, txt_numExtraLife.transform.position.y + desloCanvasY);

    }
    
    private void Update()
    {
        Ligacoll();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("collReceptLazer") && GAMEMANAGER.instance.startGame == true)
        {
            StartCoroutine(ckeckTocandoTrue());
        }

        if (GAMEMANAGER.instance.startGame == true)
        {
            //if (coll.CompareTag("collReceptLazer")/* && circleManager.circles[index].currentlife == 7*/)
            //{
            //    //UIManager.instance.txt_ModSemEnergy.text = "Modulo já com carga máxima";

            //    //testando****
            //    Destroy(gameObject, 1.5f);
            //    animacarregaEnergy.Play("AnimeitemCarregaEnergy");
            //    StartCoroutine(txtModSemEner());
                
            //}
            if (/*circleManager.circles[index].currentlife < 7 &&*/ coll.CompareTag("collReceptLazer"))
            {
                CarregaEnergy(carga, index);
                animacarregaEnergy.Play("AnimeitemCarregaEnergy");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("collReceptLazer"))
        {
            tocando = false;;
        }
    }

    void CarregaEnergy(int carga, int index)
    {
        //if (circleManager.circles[index].currentlife <= 7)
        //{
            //if (carga + circleManager.circles[index].currentlife < 7)
            //{
                circleManager.circles[index].currentlife += carga;

                //testando****
                Destroy(gameObject, 0.5f);
                audio_pegaEnergy.Play();

                circleManager.descontraExtralife += (carga *100);
            //}
            //else if (carga + circleManager.circles[index].currentlife >= 7)
            //{
            //    circleManager.circles[index].currentlife = 7;
            //}

            //audio_pegaEnergy.Play();
            //Destroy(gameObject, 1.5f);
        //}
    }    

    void Ligacoll()
    {
        if (GAMEMANAGER.instance.startGame == true)
        {
            pegaEnergy.enabled = true;
        }
    }

    //IEnumerator txtModSemEner()
    //{
    //    UIManager.instance.txt_ModSemEnergy.enabled = true;
    //    yield return new WaitForSeconds(1);
    //    UIManager.instance.txt_ModSemEnergy.enabled = false;
    //}

    IEnumerator ckeckTocandoTrue()
    {
        yield return new WaitForSeconds(0.1f);
        tocando = true;
    }
}
