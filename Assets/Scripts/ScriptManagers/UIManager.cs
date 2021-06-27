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
    private Button btnPainel_Guia;
    public bool ativa_Painel_Guia;   

    //variável que espera o carregamento de energia para...
    //liberar o método AtivaDesativaPainel_Guia
    public bool liberaMetodo_Painel_Guia;

    //Btn restart level
    public Button btn_restart;

    //testando****
    public bool habilitabBtnsCena;
    public bool habilitaBtnRestart;

    //Texto do ptsFaseMestra/text do "Painel_WL"   
    public TextMeshProUGUI textPts_FaseMestra_MCS, txt_Painel_WL, txt_Painel_info_WL;
    public TextMeshProUGUI txtCristalGreen;

    public TextMeshProUGUI txt_ModSemEnergy, txt_num_tentativas;

    //btns
    public Button btnSair;

    //painel_dicas
    [SerializeField]
    private GameObject painel_Dicas;
    [SerializeField]
    private Button btnPainel_Dicas;
    [SerializeField]
    private bool ativa_painel_Dicas;

    //Capacetes na barra de score
    [SerializeField]
    private SpriteRenderer capaceteBronze, capacetePrata, capaceteOuro;

    [SerializeField]
    private GameObject painel_Guia;
    [SerializeField]
    private GameObject Painel_WL;

    [SerializeField]
    private GameObject anime_mao;

    public TextMeshProUGUI textEnergy;
    public TextMeshProUGUI txt_showNmissel;

    private void Update()
    {
        HabilitDesabilitBts_Painel_WL();        
        habilitaBtnsCena();
        AtualizaUI();

        if (GAMEMANAGER.instance.win == true || GAMEMANAGER.instance.liberaCristal == true)
        {
            AtualizaCristalGreen(GAMEMANAGER.instance.cristalGreen);
        }            
    }

    void Carrega(Scene cena, LoadSceneMode modo)
    {
        StartGameUIM();

        if (LevelAtual.instance.level == 0)
        {
            //Carrega btn de acesso a cena FaseMestra
            btnFaseMestra = GameObject.FindWithTag("btnLevels").GetComponent<Button>();

            //Evento de click do btn FaseMestra
            //btnFaseMestra.onClick.AddListener(() => StartCoroutine(WaitSoundClick("2_FaseMestra")));
        }
        //Cenas FaseMestra, Galeria, Loja
        else if (LevelAtual.instance.level == 1)
        {
            //Btns Loja e galeria         
            btnGaleria = GameObject.FindWithTag("btnGaleria").GetComponent<Button>();

            //Eventos de click dos btns Loja e Galeria
            //btnGaleria.onClick.AddListener(() => StartCoroutine(WaitSoundClick("3_Galeria")));
        }
        //Cena Loja
        else if (LevelAtual.instance.level > 1 && LevelAtual.instance.level < 6)
        {
            //btn Voltar
            btnBack = GameObject.FindWithTag("btnBack").GetComponent<Button>();

            //Evento de click do btn Back
            //btnBack.onClick.AddListener(() => StartCoroutine(WaitSoundClick_Voltar()));
        }        

        //Cenas Levels //Carrega capacetes OBS** criar método específicos para carregar componentes
        else if (LevelAtual.instance.level >= 6)
        {
            capaceteBronze = GameObject.FindWithTag("capBronze").GetComponent<SpriteRenderer>();
            capacetePrata = GameObject.FindWithTag("capPrata").GetComponent<SpriteRenderer>();
            capaceteOuro = GameObject.FindWithTag("capOuro").GetComponent<SpriteRenderer>();

            // painel Dicas
            painel_Dicas = GameObject.FindWithTag("painel_dicas");
            btnPainel_Dicas = GameObject.FindWithTag("btn_dicas").GetComponent<Button>();
            btnPainel_Dicas.onClick.AddListener(() => AtivaDesativa_Painel_Dicas(ativa_painel_Dicas));

            //text do painel_WL
            txt_Painel_WL = GameObject.FindWithTag("txt_Painel_WL").GetComponent<TextMeshProUGUI>();
            txt_Painel_info_WL = GameObject.FindWithTag("txt_Painel_info_WL").GetComponent<TextMeshProUGUI>();

            txtCristalGreen = GameObject.FindWithTag("textCristalGreen").GetComponent<TextMeshProUGUI>();

            //Painel_WL/Painel_Guia
            Painel_WL = GameObject.FindWithTag("painel_WL");
            painel_Guia = GameObject.FindWithTag("painel_Guia");//Testando****
            btnPainel_Guia = GameObject.FindWithTag("btn_Painel_Guia").GetComponent<Button>();
            btnPainel_Guia.onClick.AddListener(() => AtivaDesativa_Painel_Guia(ativa_Painel_Guia));
            StartCoroutine(PegaPainel());

            //Mão_Painel guia
            anime_mao = GameObject.FindWithTag("anime_mao");
            anime_mao.SetActive(false);
            //chamando dentro de StarCoroutine(esperaWL())

            //btns do "Painel_WL"
            btnVoltar_Painel_WL = GameObject.FindWithTag("btnVlt_P_WL").GetComponent<Button>();
            btnNovamente_Painel_WL = GameObject.FindWithTag("btnNvm_P_WL").GetComponent<Button>();
            btnProximo_Painel_WL = GameObject.FindWithTag("btnPrx_P_WL").GetComponent<Button>();            

            StartCoroutine(esperaWL());
            
            btnNovamente_Painel_WL.onClick.AddListener(() => StartCoroutine(WaitSoundClick_btnRestart()));
           //restart level
           btn_restart = GameObject.FindWithTag("btn_restart").GetComponent<Button>();

            //evento de click btn_restart
            btn_restart.onClick.AddListener(() => RestartLevel());

            //btn Sai do level
            btnSair = GameObject.FindWithTag("btnSair").GetComponent<Button>();

            // inicializa quantidade de cristais;
            txtCristalGreen.text = ZPlayerPrefs.GetInt("cristaisGreen_Total").ToString();
            xcristal = ZPlayerPrefs.GetInt("cristaisGreen_Total");

            txt_ModSemEnergy = GameObject.FindWithTag("modSemEnergia").GetComponent<TextMeshProUGUI>();
            txt_ModSemEnergy.enabled = false;

            txt_showNmissel = GameObject.FindWithTag("showMissel").GetComponent<TextMeshProUGUI>();
            txt_num_tentativas = GameObject.FindWithTag("tentativas").GetComponent<TextMeshProUGUI>();
        }
    }

    IEnumerator esperaWL()
    {
        yield return new WaitForSeconds(0.001f);
        Painel_WL.SetActive(false);
        //anime_mao.SetActive(false);
    }

    void StartGameUIM()
    {
        //ativa_Painel_Guia = false;
        GAMEMANAGER.instance.startGame = false;
        liberaMetodo_Painel_Guia = false;
        //btn restart/ btn_GUia/ btn_Dicas
        habilitabBtnsCena = false;
        habilitaBtnRestart = false;
    }

    int cristalTemp;
    //Mostra capacetes/ salva Cpacetes da mestra e salva cristaisGreen
    public void ShowCapacetes()
    {
        //Bronze
        if (ScoreManager.instance.conta_ptsMarcados >= ScoreManager.instance.maxScore * 0.75 * 100)
        {
            capaceteBronze.enabled = true;
            
            //capacetes dos btns das fases MCS, MCH, MCAH
            GAMEMANAGER.instance.numCapacetes = 1;
            //GAMEMANAGER.instance.SalvaCapacetes(GAMEMANAGER.instance.numCapacetes);
            
            //capacetes dos btns da faseMestra
            GAMEMANAGER.instance.numCapsB = 1;
            //GAMEMANAGER.instance.SalvaCapacetes_Mestra(GAMEMANAGER.instance.numCapacetes);

            //cristaisGreen           
            if (!ZPlayerPrefs.HasKey(LevelAtual.instance.level + "cristaisGreenB"))
            {
                ZPlayerPrefs.SetInt(LevelAtual.instance.level + "cristaisGreenB", 1);                    //cristalTemp = GAMEMANAGER.instance.cristalGreen;
                cristalTemp = (int)(ScoreManager.instance.maxScore * 0.75 * 10);
                GAMEMANAGER.instance.ColetaCristalGreen(cristalTemp);
            }            

            //Prata
            if (ScoreManager.instance.conta_ptsMarcados >= ScoreManager.instance.maxScore * 0.85 * 100)
            {
                capacetePrata.enabled = true;

                //capacetes dos btns das fases MCS, MCH, MCAH
                GAMEMANAGER.instance.numCapacetes = 2;
                //GAMEMANAGER.instance.SalvaCapacetes(GAMEMANAGER.instance.numCapacetes);

                //capacetes dos btns da faseMestra
                GAMEMANAGER.instance.numCapsP = 1;
                //GAMEMANAGER.instance.SalvaCapacetes_Mestra(GAMEMANAGER.instance.numCapacetes);

                //cristaisGreen                
                if (!ZPlayerPrefs.HasKey(LevelAtual.instance.level + "cristaisGreenP"))
                {
                    ZPlayerPrefs.SetInt(LevelAtual.instance.level + "cristaisGreenP", 2);
                    cristalTemp = (int)(ScoreManager.instance.maxScore * 0.85 * 10) - (int)(ScoreManager.instance.maxScore * 0.5 * 10);
                    GAMEMANAGER.instance.ColetaCristalGreen(cristalTemp);
                }

                //Ouro
                if (ScoreManager.instance.conta_ptsMarcados >= ScoreManager.instance.maxScore * 100)
                {
                    capaceteOuro.enabled = true;                    

                    //capacetes dos btns das fases MCS, MCH, MCAH
                    GAMEMANAGER.instance.numCapacetes = 3;
                    //GAMEMANAGER.instance.SalvaCapacetes(GAMEMANAGER.instance.numCapacetes);

                    //capacetes dos btns da faseMestra
                    GAMEMANAGER.instance.numCapsO = 1;
                    //GAMEMANAGER.instance.SalvaCapacetes_Mestra(GAMEMANAGER.instance.numCapacetes);

                    //cristaisGreen                    
                    if (!ZPlayerPrefs.HasKey(LevelAtual.instance.level + "cristaisGreenO"))
                    {
                        ZPlayerPrefs.SetInt(LevelAtual.instance.level + "cristaisGreenO", 3);
                        cristalTemp = (int)(ScoreManager.instance.maxScore * 10) - (int)(ScoreManager.instance.maxScore * 0.75 * 10);
                        GAMEMANAGER.instance.ColetaCristalGreen(cristalTemp);//testando****
                    }
                }
            }
        }
    }

    public void Fases(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void UI_Win()
    {
        Painel_WL.SetActive(true);
        //GAMEMANAGER.instance.win = false;
    }

    public void RestartLevel()
    {
        if (GAMEMANAGER.instance.win == false)
        {
            StartCoroutine(WaitSoundClick_btnRestart());
        }
    }

    public void HabilitDesabilitBts_Painel_WL()
    {
        if (LevelAtual.instance.level >= 6)
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
                btnProximo_Painel_WL.enabled = false;

                btnProximo_Painel_WL.gameObject.SetActive(false);
            }
        }
    }

    public void habilitaBtnsCena()
    {
        if (LevelAtual.instance.level >= 6)
        {
            if (habilitabBtnsCena == true)
            {
                btnPainel_Guia.enabled = true;
                btnPainel_Dicas.enabled = true;
            }
            else
            {
                btnPainel_Guia.enabled = false;
                btnPainel_Dicas.enabled = false;
            }
            if (habilitaBtnRestart == true)
            {
                btn_restart.enabled = true;
            }
            else
            {
                btn_restart.enabled = false;
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

                FechaPainel_Dica();//testando****
                habilitaBtnRestart = false;//testando****
            }
            else
            {
                painel_Guia.GetComponent<Animator>().Play("Anime_PainelManualBack");
                ativa_Painel_Guia = false;
                GAMEMANAGER.instance.startGame = true;
                anime_mao.SetActive(false);

                habilitaBtnRestart = true;//testando****
            }
        }
    }

    //Atualiza UI colocar cristal e missel em todas as cenas
    void AtualizaUI()
    {
        //Missel
        if(LevelAtual.instance.level >= 6)
        {
            txt_showNmissel.text = GAMEMANAGER.instance.cargaMissel.ToString();
            txt_num_tentativas.text = GAMEMANAGER.instance.num_tentativas.ToString();
        }
        
    }

    public void AtivaDesativa_Painel_Dicas(bool pl)
    {
        if (liberaMetodo_Painel_Guia == true)
        {
            if (pl == false)
            {
                GAMEMANAGER.instance.startGame = false;
                ativa_painel_Dicas = true;
                painel_Dicas.SetActive(ativa_painel_Dicas);
                painel_Dicas.GetComponent<Animator>().Play("Anime_PainelDicas");

                FechaPainel_Guia();//testando****
                habilitaBtnRestart = false;//testando****
            }
            else
            {
                painel_Dicas.GetComponent<Animator>().Play("Anime_PainelDicasBack");
                ativa_painel_Dicas = false;
                GAMEMANAGER.instance.startGame = true;

                habilitaBtnRestart = true;//testando****
            }
        }
    }

    void FechaPainel_Guia()
    {
        if (ativa_Painel_Guia == true)
        {
            painel_Guia.GetComponent<Animator>().Play("Anime_PainelManualBack");
            ativa_Painel_Guia = false;
            anime_mao.SetActive(false);
        }
    }

    public void FechaPainel_Dica()
    {
        if (ativa_painel_Dicas == true)
        {
            painel_Dicas.GetComponent<Animator>().Play("Anime_PainelDicasBack");
            ativa_painel_Dicas = false;

            GAMEMANAGER.instance.startGame = false;

            habilitaBtnRestart = true;
        }
    }

    //testando Aqui****
    float xcristal;
    public float velCon;
    public void AtualizaCristalGreen(int cristais)//testando****
    {
        if (xcristal < cristais)
        {
            xcristal += 1 + (velCon * Time.deltaTime);

            txtCristalGreen.text = xcristal.ToString("F0");

            if (xcristal > cristais)
            {
                xcristal = cristais;
                txtCristalGreen.text = xcristal.ToString("F0");
            }
        }
        else if(xcristal > cristais)
        {
            xcristal -= 1 + (velCon * Time.deltaTime);

            txtCristalGreen.text = xcristal.ToString("F0");

            if (xcristal < cristais)
            {
                xcristal = cristais;
                txtCristalGreen.text = xcristal.ToString("F0");
            }
            if(xcristal == cristais)
            {
                GAMEMANAGER.instance.liberaCristal = false;
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

    IEnumerator PegaPainel()
    {
        yield return new WaitForSeconds(0.1f);
        painel_Guia.SetActive(false);
        painel_Dicas.SetActive(false);
    }

    IEnumerator Anime_Mao(bool pl)
    {
        yield return new WaitForSeconds(0.8f);
        anime_mao.SetActive(pl);
    }
}
