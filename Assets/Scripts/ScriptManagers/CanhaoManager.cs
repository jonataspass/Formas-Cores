using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanhaoManager : MonoBehaviour
{
    //trava -> controla a velocidade de clicks do usuário
    public bool travaClick;

    //Lazer -> raio de lazer que saia do canhão; sprite que recebe as configurações de cor e localScale 
    public SpriteRenderer feixeLazer;

    //variáveis de controle e configurações do SpriteRendere feixeLazer
    public bool lazerTrava;
    public float LazerSpeed = 10;
    public float lazerMaxLargura;
    private float lazerLargura;
    public float lazerComprimento;
    public Color lazerAlphaLazer;
    public bool desativaLazer;
    public int ativados;

    //teste
    public AudioClip[] clips;
    public AudioSource effectsObjs;

    private void Start()
    {
        feixeLazer = GetComponentInChildren<SpriteRenderer>();
        feixeLazer.color = new Color(lazerAlphaLazer.r, lazerAlphaLazer.g, lazerAlphaLazer.b, lazerAlphaLazer.a);
        DesativaColl(gameObject.GetComponent<Collider2D>());
        StartCoroutine(AtivaColl(gameObject.GetComponent<Collider2D>()));
        //audio
        effectsObjs = GetComponent<AudioSource>();
    }

    private void Update()
    {
        StopSoundLazer();
        AcionaLazer();
    }

    //Ativa canhão
    private void OnTriggerEnter2D(Collider2D coll)
    {        
        if (coll.gameObject.CompareTag("collReceptLazer"))
        {
            //ativados = 1;
            //GAMEMANAGER.instance.YouWin(CircleCS_Gray.instance.numCanhoes, ativados); 
            StartCoroutine(WaitBuster());
            //Incremente score
            ScoreManager.instance.ptsMarcados_Total += 100;
            //lazerSound
            StartCoroutine(Wait_AtivaSoundLazer());
        }
    }

    //Desativa canhão
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("collReceptLazer"))
        {
            ativados = 0;
            GAMEMANAGER.instance.YouWin(CircleCS_Gray.instance.numCanhoes, ativados);
            //SoundDesativaLazer();
            effectsObjs.clip = clips[1];
            effectsObjs.Play();
        }
    }

    void AcionaLazer()
    {
        if (ativados == 1)
        {
            StartCoroutine(LiberaLazer());
            desativaLazer = true;            

            if (lazerTrava == true)
            {
                //acende lazer
                if (lazerAlphaLazer.a < 1)
                {
                    lazerAlphaLazer.a += LazerSpeed * Time.deltaTime;
                    feixeLazer.color = new Color(lazerAlphaLazer.r, lazerAlphaLazer.g, lazerAlphaLazer.b, lazerAlphaLazer.a);
                    //Aumenta largura do lazer
                    if (lazerLargura < lazerMaxLargura)
                    {
                        lazerLargura += LazerSpeed * Time.deltaTime;
                        feixeLazer.transform.localScale = new Vector3(lazerLargura, lazerComprimento, 0);
                    }
                }
            }            
        }
        else if (ativados == 0)
        {
            lazerTrava = false;

            if (lazerAlphaLazer.a > 0)
            {
                lazerAlphaLazer.a -= LazerSpeed * Time.deltaTime;
                feixeLazer.color = new Color(lazerAlphaLazer.r, lazerAlphaLazer.g, lazerAlphaLazer.b, lazerAlphaLazer.a);
                //Diminui largura do lazer
                if (lazerAlphaLazer.a < 0.8f)
                {
                    lazerLargura -= LazerSpeed * Time.deltaTime;
                    feixeLazer.transform.localScale = new Vector3(lazerLargura, lazerComprimento, 0);
                }
                if (lazerAlphaLazer.a <= 0)
                {
                    lazerAlphaLazer.a = 0;
                    lazerLargura = 0;
                    feixeLazer.transform.localScale = new Vector3(0, lazerComprimento, 0);
                    desativaLazer = false;
                }
            }
        }
    }

    //Desativa collider "o collider deve ser desativado rapidamente no inicio
    //para que o lazer não seja ativado inicialmente
    void DesativaColl(Collider2D coll)
    {
        coll.enabled = false;
    }
    //testando****
    IEnumerator WaitBuster()
    {
        yield return new WaitForSeconds(0.3f);
        ativados = 1;
        GAMEMANAGER.instance.YouWin(CircleCS_Gray.instance.numCanhoes, ativados);
    }

    //velocidades de clicks
    IEnumerator DestravaClick()
    {
        yield return new WaitForSeconds(0.5f);
        travaClick = false;
    }
    //velocidade de ativação do lazer
    IEnumerator LiberaLazer()
    {
        yield return new WaitForSeconds(0.3f);
        lazerTrava = true;
    }
    //Ativa collider
    IEnumerator AtivaColl(Collider2D coll)
    {
        yield return new WaitForSeconds(0.1f);
        coll.enabled = true;
    }

    IEnumerator Wait_AtivaSoundLazer()
    {
        yield return new WaitForSeconds(0.3f);
        //SoundAtivaLazer();
        effectsObjs.clip = clips[0];
        effectsObjs.Play();

    }

    void StopSoundLazer()
    {
        if(ScoreManager.instance.waitCont == true)
        {
            effectsObjs.Stop();
        }
    }
}
