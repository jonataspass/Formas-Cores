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

    //Btn BACK das fases : fasesMestra, Galeria, Loja e Fase com btns levels e...
    //Btns do Painel_WL
    [SerializeField]
    private Button btnBack, btnVoltar_Painel_WL, btnNovamente_Painel_WL, btnProximo_Painel_WL;
    [SerializeField]
    private Button btnPainel_Guia;//testando****
    public bool ativa_Painel_Guia;//testando****
    //variável que espera o carregamento de energia para...
    //liberar o método AtivaDesativaPainel_Guia
    public bool liberaMetodo_Painel_Guia;

    //Btn restart level
    public Button btn_restart;

    //testando****
    public bool desabBtnsCena;

    //Texto do ptsFaseMestra; text do "Painel_WL"
    [SerializeField]
    public TextMeshProUGUI textPts_FaseMestra, txt_Painel_WL, txt_Painel_info_WL;


    //Capacetes na barra de score
    [SerializeField]
    private SpriteRenderer capaceteBronze, capacetePrata, capaceteOuro;

    [SerializeField]
    private GameObject painel_Guia;//testando****
    [SerializeField]
    private GameObject Painel_WL;

    [SerializeField]
    private GameObject anime_mao;//testando****

    //testando****
    public TextMeshProUGUI textEnergy;

    private void Update()
    {
        HabilitDesabilitBts_Painel_WL();
        //testando****
        habilitaBtnsCena();
    }

    void Carrega(Scene cena, LoadSceneMode modo)
    {
        StartGameUIM();

        //Cena Inicial
        if (LevelAtual.instance.level == 0)
        {
            //Carrega btn de acesso a cena FaseMestra
            btnFaseMestra = GameObject.FindWithTag("btnLevels").GetComponent<Button>();

            //Evento de click do btn FaseMestra
            btnFaseMestra.onClick.AddListener(() => StartCoroutine(WaitSoundClick("2_FaseMestra")));
        }
        //Cenas FaseMestra, Galeria, Loja
        else if (LevelAtual.instance.level == 1)
        {
            //Btns Loja e galeria         
            btnGaleria = GameObject.FindWithTag("btnGaleria").GetComponent<Button>();
            btnLoja = GameObject.FindWithTag("btnLoja").GetComponent<Button>();

            //Eventos de click dos btns Loja e Galeria
            btnGaleria.onClick.AddListener(() => StartCoroutine(WaitSoundClick("4_Galeria")));
            btnLoja.onClick.AddListener(() => StartCoroutine(WaitSoundClick("3_Loja")));

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
            btnBack.onClick.AddListener(() => StartCoroutine(WaitSoundClick_Voltar()));
        }
        //Cena Galeria
        else if (LevelAtual.instance.level == 3)
        {
            //btn Voltar
            btnBack = GameObject.FindWithTag("btnBack").GetComponent<Button>();

            //Evento de click do btn Voltar
            btnBack.onClick.AddListener(() => StartCoroutine(WaitSoundClick_Voltar()));
        }
        //Cena Levels
        else if (LevelAtual.instance.level == 4)
        {
            //btn Voltar
            btnBack = GameObject.FindWithTag("btnBack").GetComponent<Button>();

            //Evento de click do btn Voltar
            btnBack.onClick.AddListener(() => StartCoroutine(WaitSoundClick_Voltar()));
        }

        //Cenas Levels //Carrega capacetes OBS** criar método específicos para carregar componentes
        else if (LevelAtual.instance.level >= 5)
        {
            capaceteBronze = GameObject.FindWithTag("capBronze").GetComponent<SpriteRenderer>();
            capacetePrata = GameObject.FindWithTag("capPrata").GetComponent<SpriteRenderer>();
            capaceteOuro = GameObject.FindWithTag("capOuro").GetComponent<SpriteRenderer>();

            //text do painel_WL
            txt_Painel_WL = GameObject.FindWithTag("txt_Painel_WL").GetComponent<TextMeshProUGUI>();
            txt_Painel_info_WL = GameObject.FindWithTag("txt_Painel_info_WL").GetComponent<TextMeshProUGUI>();

            //Painel_WL/Painel_Guia
            Painel_WL = GameObject.FindWithTag("painel_WL");
            painel_Guia = GameObject.FindWithTag("painel_Guia");//Testando****
            btnPainel_Guia = GameObject.FindWithTag("btn_Painel_Guia").GetComponent<Button>();
            btnPainel_Guia.onClick.AddListener(() => AtivaDesativa_Painel_Guia(ativa_Painel_Guia));
            StartCoroutine(PegaPainel_Guia());

            //Mão_Painel guia
            anime_mao = GameObject.FindWithTag("anime_mao");
            anime_mao.SetActive(false);

            //btns do "Painel_WL"
            btnVoltar_Painel_WL = GameObject.FindWithTag("btnVlt_P_WL").GetComponent<Button>();
            btnNovamente_Painel_WL = GameObject.FindWithTag("btnNvm_P_WL").GetComponent<Button>();
            btnProximo_Painel_WL = GameObject.FindWithTag("btnPrx_P_WL").GetComponent<Button>();

            StartCoroutine(esperaWL());

            //eventos de clicks dos btns do painel_WL            
            btnNovamente_Painel_WL.onClick.AddListener(() => SceneManager.LoadScene(LevelAtual.instance.level));
            btnProximo_Painel_WL.onClick.AddListener(() => SceneManager.LoadScene(LevelAtual.instance.level + 1));

            //testando//restart level
            btn_restart = GameObject.FindWithTag("btn_restart").GetComponent<Button>();

            //testando//evento de click btn_restart
            btn_restart.onClick.AddListener(() => RestartLevel());
        }
    }

    IEnumerator esperaWL()
    {
        yield return new WaitForSeconds(0.01f);
        Painel_WL.SetActive(false);
    }

    void StartGameUIM()
    {
        //ativa_Painel_Guia = false;
        GAMEMANAGER.instance.startGame = false;
        liberaMetodo_Painel_Guia = false;
        //btn restart/ btn_GUia/ btn_Dicas
        desabBtnsCena = false;
    }

    public void ShowCapacetes()
    {
        if (ScoreManager.instance.conta_ptsMarcados >= ScoreManager.instance.maxScore * 0.5 * 100)
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

    public void RestartLevel()
    {
        if (GAMEMANAGER.instance.startGame == true && GAMEMANAGER.instance.win == false)
        {
            StartCoroutine(WaitSoundClick_btnRestart());
        }
    }

    public void HabilitDesabilitBts_Painel_WL()
    {
        if (LevelAtual.instance.level >= 5)
        {
            if (ScoreManager.instance.waitCont == true)
            {
                btnVoltar_Painel_WL.enabled = true;
                btnNovamente_Painel_WL.enabled = true;
                btnProximo_Painel_WL.enabled = true;
            }
            else
            {
                btnVoltar_Painel_WL.enabled = false;
                btnNovamente_Painel_WL.enabled = false;
                btnProximo_Painel_WL.enabled = false;
            }
            if (GAMEMANAGER.instance.lose == true)
            {
                btnVoltar_Painel_WL.enabled = true;
                btnNovamente_Painel_WL.enabled = true;
                btnProximo_Painel_WL.enabled = true;
            }
        }
    }

    public void habilitaBtnsCena()
    {
        if (LevelAtual.instance.level >= 5)
        {
            if (desabBtnsCena == true)
            {
                btn_restart.enabled = true;
                btnPainel_Guia.enabled = true;
            }
            else
            {
                btn_restart.enabled = false;
                btnPainel_Guia.enabled = false;
            }
        }
    }

    public void AtivaDesativa_Painel_Guia(bool pl)
    {
        if (liberaMetodo_Painel_Guia == true)
        {
            if (pl == false)
            {
                GAMEMANAGER.instance.startGame = false;
                ativa_Painel_Guia = true;
                painel_Guia.SetActive(ativa_Painel_Guia);
                painel_Guia.GetComponent<Animator>().Play("Anime_PainelManual");
                StartCoroutine(Anime_Mao(ativa_Painel_Guia));
            }
            else
            {
                painel_Guia.GetComponent<Animator>().Play("Anime_PainelManualBack");
                ativa_Painel_Guia = false;
                GAMEMANAGER.instance.startGame = true;
                anime_mao.SetActive(false);
            }
        }
    }

    IEnumerator WaitSoundClick(string s)
    {
        yield return new WaitForSeconds(0.4f);
        UI_Metodo.CarregaCena(s);
    }

    IEnumerator WaitSoundClick_btnRestart()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(LevelAtual.instance.level);
    }

    IEnumerator WaitSoundClick_Voltar()
    {
        yield return new WaitForSeconds(0.4f);
        UI_Metodo.Voltar();
    }

    IEnumerator PegaPainel_Guia()
    {
        yield return new WaitForSeconds(0.1f);
        painel_Guia.SetActive(false);
    }

    IEnumerator Anime_Mao(bool pl)
    {
        yield return new WaitForSeconds(0.8f);
        anime_mao.SetActive(pl);
    }
}
