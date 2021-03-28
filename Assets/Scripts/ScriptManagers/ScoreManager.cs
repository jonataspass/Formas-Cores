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
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += Carrega;
    }

    //pontuação máxima possível de atingir "objetivo 100%"
    public int maxScore;

    //variáveis de pontuação
    public int ptsMarcados_Total;
    public float conta_ptsMarcados;

    //pontuação apresentada como text  
    public TextMeshProUGUI currentScore;

    //variável que incrementa a barra de score
    public float xScale;
    //Barra de score
    public Image scoreBar;
    //Salva pontuação da FaseMestra
    public int score_FaseMestra;

    //testando****variável espera contagem
    public bool waitCont;

    //audios
    public AudioClip[] clips;
    public AudioSource effectsObjs;

    private void Update()
    {
        ShowScore();        
    }

    //Carrega cena
    void Carrega(Scene cena, LoadSceneMode modo)
    {
        GameStartScoreM();

        if(LevelAtual.instance.level >= 5)
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

    public void UpdateScoreM()
    {

    }

    public void ColetaCristal()
    {

    }

    public void ColetaCromiunCoins()
    {

    }

    public void SalvaScore_FaseMestra(int pts)
    {
        if (PlayerPrefs.HasKey("Score_FaseMestra"))
        {
            if(pts > PlayerPrefs.GetInt("Score_FaseMestra", score_FaseMestra))
            {
                score_FaseMestra = pts;
                PlayerPrefs.SetInt("Score_FaseMestra", score_FaseMestra);
                print(pts);
            }
        }
        else
        {
            score_FaseMestra = pts;
            PlayerPrefs.SetInt("Score_FaseMestra", score_FaseMestra);
        }       
    }

    //Atualiza a pontuação da barra de score
    void ShowScore()
    {
        if (conta_ptsMarcados < ptsMarcados_Total)
        {
            if (conta_ptsMarcados < 100)
            {
                conta_ptsMarcados ++;
                xScale = conta_ptsMarcados / 100 / maxScore;
                currentScore.text = conta_ptsMarcados.ToString();
                
                //effect sound
                effectsObjs.clip = clips[0];
                effectsObjs.Play();

                if (xScale > 1)
                {
                    xScale = 1;
                    scoreBar.rectTransform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
                }

                scoreBar.rectTransform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                conta_ptsMarcados += 10f;
                xScale = conta_ptsMarcados / 100 / maxScore;
                currentScore.text = conta_ptsMarcados.ToString();

                //effect sound
                effectsObjs.clip = clips[0];
                effectsObjs.Play();

                //Salva pontuação a ser exibida no score da "FaseMestra"
                SalvaScore_FaseMestra((int)ptsMarcados_Total);

                if (xScale > 1)
                {
                    xScale = 1;
                    scoreBar.rectTransform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
                }

                scoreBar.rectTransform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);                
            }

            //testando****
            if (conta_ptsMarcados > ptsMarcados_Total)
                conta_ptsMarcados = ptsMarcados_Total;

            
            if(GAMEMANAGER.instance.win == true && ptsMarcados_Total == conta_ptsMarcados)
            {
                waitCont = true;
            }

            UIManager.instance.ShowCapacetes();
        }
    }
}
