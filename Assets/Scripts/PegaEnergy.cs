using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PegaEnergy : MonoBehaviour
{
    CircleManager circleManager;

    public int carga;
    public int numRepetCarga;
    public int index;

    AudioSource audio_pegaEnergy;

    Animator animacarregaEnergy;
    public TextMeshProUGUI text_cargaEnergy, text_repetEnergy;

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

        //text_cargaEnergy = GetComponentInChildren<TextMeshProUGUI>();
        text_cargaEnergy.text = carga.ToString();
        text_repetEnergy.text = numRepetCarga.ToString() + "x";
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
            if (coll.CompareTag("collReceptLazer"))
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
            tocando = false; ;
        }
    }

    void CarregaEnergy(int carga, int index)
    {
        circleManager.circles[index].currentlife += carga;

        Destroy(gameObject, 0.5f);
        audio_pegaEnergy.Play();

        circleManager.descontraExtralife += (carga * 100);
    }

    void Ligacoll()
    {
        if (GAMEMANAGER.instance.startGame == true)
        {
            pegaEnergy.enabled = true;
        }
    }

    IEnumerator ckeckTocandoTrue()
    {
        yield return new WaitForSeconds(0.1f);
        tocando = true;
    }
}
