using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    void Awake()
    {
        ZPlayerPrefs.Initialize("157JONATAS", "157157157");

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //PlayerPrefs.DeleteAll();

        SceneManager.sceneLoaded += Carrega;
    }

    //pontuação máxima possível de atingir "objetivo 100%"
    public int maxScore;

    //variáveis de pontuação
    public int ptsMarcados_Total;
    public float conta_ptsMarcados;

    //pontuação apresentada como text  
    public TextMeshProUGUI currentScore;

    //trabalhando aqui
    float xcristal;

    //variável que incrementa a barra de score
    public float xScale;
    //Barra de score
    public Image scoreBar;
    //Salva pontuação da FaseMestra
    public int score_FaseMestra_MCS;

    //testando****variável espera contagem
    public bool waitCont;

    //audios
    public AudioClip[] clips;
    public AudioSource effectsObjs;

    private void Update()
    {
        ShowScore();
    }

    private void FixedUpdate()
    {
        // ShowScore();
    }

    //Carrega cena
    void Carrega(Scene cena, LoadSceneMode modo)
    {
        GameStartScoreM();

        if (LevelAtual.instance.level >= 6)
        {
            //Elementos barra de score e texto de pontuação da UI
            scoreBar = GameObject.FindWithTag("scoreBar").GetComponent<Image>();
            currentScore = GameObject.FindWithTag("ptsText").GetComponent<TextMeshProUGUI>();
            //carregamento de pts
            scoreBar.rectTransform.localScale = new Vector3(ptsMarcados_Total, 0, 0);
        }
    }

    //trabalhando aqui******Variáveis que devem ser inicializadas
    public void GameStartScoreM()
    {
        waitCont = false;
        //audio
        effectsObjs = GetComponent<AudioSource>();
    }

    public void SalvaScore_FaseMestra(int pts)
    {
        if(GAMEMANAGER.instance.win == true)
        {
            if (ZPlayerPrefs.HasKey(LevelAtual.instance.cenaAtual + "score"))
            {
                //adicionar um indice para identificar cada level para a saber qual a pontuação mais alta em cada level
                if (pts > ZPlayerPrefs.GetInt(LevelAtual.instance.cenaAtual + "score"))
                {
                    score_FaseMestra_MCS = pts;//testando****
                    ZPlayerPrefs.SetInt(LevelAtual.instance.cenaAtual + "score", score_FaseMestra_MCS);
                    print(pts);
                }
            }
            else
            {
                score_FaseMestra_MCS = pts;
                ZPlayerPrefs.SetInt(LevelAtual.instance.cenaAtual + "score", score_FaseMestra_MCS);
            }
        }        
    }

    //testando****TRABALHANDO AQUI
    public float velCon;
    //Atualiza a pontuação da barra de score
    void ShowScore()
    {
        if (conta_ptsMarcados < ptsMarcados_Total)
        {
            //testando****
            if(conta_ptsMarcados <= 1000)
            {
                conta_ptsMarcados += 10 + (velCon * Time.deltaTime);
                xScale = conta_ptsMarcados/ 100 / maxScore;
            }
            else if(conta_ptsMarcados > 1000)
            {
                conta_ptsMarcados += 100 + (velCon * Time.deltaTime);
                xScale = conta_ptsMarcados / 100 / maxScore;
            }
            //conta_ptsMarcados += 10 + (velCon * Time.deltaTime);
            //xScale = conta_ptsMarcados / 100 / maxScore;

            //effect sound
            effectsObjs.clip = clips[0];
            effectsObjs.Play();            

            if (xScale > 1)
            {
                xScale = 1;
                scoreBar.rectTransform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
            }

            scoreBar.rectTransform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
            
            if (conta_ptsMarcados > ptsMarcados_Total)
                conta_ptsMarcados = ptsMarcados_Total; 
            
            currentScore.text = conta_ptsMarcados.ToString("F0");            

            UIManager.instance.ShowCapacetes();
        }
        //passar para o gamemanager
        if (GAMEMANAGER.instance.win == true && ptsMarcados_Total == conta_ptsMarcados)
        {
            waitCont = true;
            //Salva pontuação a ser exibida no score da "FaseMestra"
            SalvaScore_FaseMestra(ptsMarcados_Total);
            GAMEMANAGER.instance.SalvaCapacetes(GAMEMANAGER.instance.numCapacetes);
            GAMEMANAGER.instance.SalvaCapacetes_Mestra(GAMEMANAGER.instance.numCapacetes);            
        }
    }   
}
