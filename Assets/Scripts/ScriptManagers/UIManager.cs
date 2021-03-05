using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

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

    //Btns de acesso às fases: cena de faseMestra, galeria e loja
    [SerializeField]
    private Button btnFaseMestra, btnGaleria, btnLoja;

    //Btn BACK das fases : fasesMestra, Galeria, Loja e Fase com btns levels
    [SerializeField]
    private Button btnBack;

    //Texto do ptsFaseMestra; text do "Painel_WL"
    [SerializeField]
    public TextMeshProUGUI textPts_FaseMestra, txt_Painel_WL;

    //Capacetes na barra de score
    [SerializeField]
    private SpriteRenderer capaceteBronze, capacetePrata, capaceteOuro;

    //testando***
    [SerializeField]
    private GameObject Painel_WL;

    void Carrega(Scene cena, LoadSceneMode modo)
    {
        //Cena Inicial
        if (LevelAtual.instance.level == 0)
        {
            //Carrega btn de acesso a cena FaseMestra
            btnFaseMestra = GameObject.FindWithTag("btnLevels").GetComponent<Button>();

            //Evento de click do btn FaseMestra
            btnFaseMestra.onClick.AddListener(() => UI_Metodo.CarregaCena("2_FaseMestra"));
        }
        //Cenas FaseMestra, Galeria, Loja
        else if (LevelAtual.instance.level == 1)
        {
            //Btns Loja e galeria         
            btnGaleria = GameObject.FindWithTag("btnGaleria").GetComponent<Button>();
            btnLoja = GameObject.FindWithTag("btnLoja").GetComponent<Button>();
            //Eventos de click dos btns Loja e Galeria
            btnGaleria.onClick.AddListener(() => UI_Metodo.CarregaCena("4_Galeria"));
            btnLoja.onClick.AddListener(() => UI_Metodo.CarregaCena("3_Loja"));

            //trabalhando aqui*****
            textPts_FaseMestra = GameObject.FindWithTag("textPts_FaseMestra").GetComponent<TextMeshProUGUI>();
            ShowScore();
        }
        //Cena Loja
        else if (LevelAtual.instance.level == 2)
        {
            //btn Voltar
            btnBack = GameObject.FindWithTag("btnBack").GetComponent<Button>();
            //Evento de click do btn Voltar
            btnBack.onClick.AddListener(UI_Metodo.Voltar);
        }
        //Cena Galeria
        else if(LevelAtual.instance.level == 3)
        {
            //btn Voltar
            btnBack = GameObject.FindWithTag("btnBack").GetComponent<Button>();
            //Evento de click do btn Voltar
            btnBack.onClick.AddListener(UI_Metodo.Voltar);
        }
        //Cena Levels
        else if (LevelAtual.instance.level == 4)
        {
            //btn Voltar
            btnBack = GameObject.FindWithTag("btnBack").GetComponent<Button>();
            //Evento de click do btn Voltar
            btnBack.onClick.AddListener(UI_Metodo.Voltar);
        }

        //Cenas Levels //Carrega capacetes OBS** criar método específicos para carregar componentes
        else if(LevelAtual.instance.level >= 5)
        {            
            capaceteBronze = GameObject.FindWithTag("capBronze").GetComponent<SpriteRenderer>();
            capacetePrata = GameObject.FindWithTag("capPrata").GetComponent<SpriteRenderer>();
            capaceteOuro = GameObject.FindWithTag("capOuro").GetComponent<SpriteRenderer>();

            //testando****text do painel_WL
            txt_Painel_WL = GameObject.FindWithTag("txt_Painel_WL").GetComponent<TextMeshProUGUI>();

            //testando****
            Painel_WL = GameObject.FindWithTag("painel_WL");
            Painel_WL.SetActive(false);
        }

        //StartGameUIM();
    }
    
    void StartGameUIM()
    {
        //testando***
        
    }
    
    public void ShowCapacetes()
    {
        if(ScoreManager.instance.conta_ptsMarcados >= ScoreManager.instance.maxScore * 0.5 * 100)
        {
            capaceteBronze.enabled = true;

            if (ScoreManager.instance.conta_ptsMarcados >= ScoreManager.instance.maxScore * 0.75 * 100)
            {
                capacetePrata.enabled = true;

                if (ScoreManager.instance.conta_ptsMarcados >= ScoreManager.instance.maxScore * 100)
                {
                    capaceteOuro.enabled = true;
                }
            }
        }        
    }
    
    void ShowScore()
    {
        int pts = PlayerPrefs.GetInt("Score_FaseMestra");
        textPts_FaseMestra.text = pts.ToString();
    }    

    public void Fases(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void UI_Win()
    {
        Painel_WL.SetActive(true);
    }
}
