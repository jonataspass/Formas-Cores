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

    //GameObject com Script CircleManager
    public CircleManager circleManager;

    //Btns de acesso às fases: cena de faseMestra, galeria e loja
    [SerializeField]
    private Button btnFaseMestra, btnGaleria, btnLoja;

    //Btn BACK das fases : fasesMestra, Galeria, Loja e Fase com btns levels e...
    //Btns do Painel_WL
    [SerializeField]
    private Button btnBack, btnVoltar_Painel_WL, btnNovamente_Painel_WL, btnProximo_Painel_WL;

    public Button btnPainel_Guia;
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

    public TextMeshProUGUI txt_Informativo, txt_num_tentativas;
    //btns
    public Button btnSair;

    //painel_dicas
    [SerializeField]
    private GameObject painel_Dicas;

    public Button btnPainel_Dicas;
    public bool ativa_painel_Dicas;

    //Capacetes na barra de score
    [SerializeField]
    private SpriteRenderer capaceteBronze, capacetePrata, capaceteOuro;

    [SerializeField]
    private GameObject painel_Guia;
    [SerializeField]
    private GameObject Painel_WL;
    [SerializeField]
    public GameObject painel_CompraExtra;//utilizado no Script controlPanelRotation

    public Button btnDesistir, btnComprar;//utilizado no Script controlPanelRotation
    public Image imgExtra, imgMissel, imgEnergy;
    public TextMeshProUGUI txtTipoItem, txtExtra, txtMissel, txtEng;


    [SerializeField]
    private GameObject anime_mao;

    public TextMeshProUGUI textEnergy;
    public TextMeshProUGUI txt_showNmissel;
    public TextMeshProUGUI txt_showNmoeda;

    //public Button btn_Recompensa;
    public GameObject painel_Recompensa;
    public Image crs, missel, dica, extras;

    public AudioSource soundMoedas;

    //[SerializeField]
    //GameObject animaMaoCarregaCrs;

    private void Update()
    {
        HabilitDesabilitBts_Painel_WL();
        habilitaBtnsCena();
        AtualizaUI();
        //new
        ConverteMisselToCoin();
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
            //mão carrega crs tutorial
            //animaMaoCarregaCrs = GameObject.FindWithTag("animeMao_Dica");
            //animaMaoCarregaCrs.SetActive(false);


            //btns do "Painel_WL"
            btnVoltar_Painel_WL = GameObject.FindWithTag("btnVlt_P_WL").GetComponent<Button>();
            btnNovamente_Painel_WL = GameObject.FindWithTag("btnNvm_P_WL").GetComponent<Button>();
            btnProximo_Painel_WL = GameObject.FindWithTag("btnPrx_P_WL").GetComponent<Button>();

            //btnRecompensa*********testando
            painel_Recompensa = GameObject.FindWithTag("painelBtnRecompensa");
            //btn_Recompensa = GameObject.FindWithTag("btnRecompensa").GetComponent<Button>();

            //utilizados no script controlpanelrotation
            painel_CompraExtra = GameObject.FindWithTag("compraExtra");
            btnDesistir = GameObject.FindWithTag("btn_desistir").GetComponent<Button>();
            btnComprar = GameObject.FindWithTag("btn_comprar").GetComponent<Button>();
            imgExtra = GameObject.FindWithTag("imgExtra").GetComponent<Image>();
            imgMissel = GameObject.FindWithTag("imgMissel").GetComponent<Image>();
            imgEnergy = GameObject.FindWithTag("imgEnergy").GetComponent<Image>();
            txtExtra = GameObject.FindWithTag("txtExtra").GetComponent<TextMeshProUGUI>();
            txtMissel = GameObject.FindWithTag("txtMissel").GetComponent<TextMeshProUGUI>();
            txtEng = GameObject.FindWithTag("txtEng").GetComponent<TextMeshProUGUI>();
            txtTipoItem = GameObject.FindWithTag("txtTipodeItem").GetComponent<TextMeshProUGUI>();
            txtTipoItem.enabled = false;
            txtExtra.enabled = false;
            txtMissel.enabled = false;
            txtEng.enabled = false;
            imgExtra.enabled = false;
            imgMissel.enabled = false;
            imgEnergy.enabled = false;
            painel_CompraExtra.SetActive(false);

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

            txt_Informativo = GameObject.FindWithTag("modSemEnergia").GetComponent<TextMeshProUGUI>();
            txt_Informativo.enabled = false;

            txt_showNmissel = GameObject.FindWithTag("showMissel").GetComponent<TextMeshProUGUI>();
            txt_num_tentativas = GameObject.FindWithTag("tentativas").GetComponent<TextMeshProUGUI>();

            txt_showNmoeda = GameObject.FindWithTag("ShowMoeda").GetComponent<TextMeshProUGUI>();

            //AtualizaMoedaZ(GAMEMANAGER.instance.qtd_moedaSalvas);          
            //images do btnRecompensa
            crs = GameObject.FindWithTag("Crs_R").GetComponent<Image>();
            missel = GameObject.FindWithTag("Missel_R").GetComponent<Image>();
            dica = GameObject.FindWithTag("Dica_R").GetComponent<Image>();
            extras = GameObject.FindWithTag("Extra_R").GetComponent<Image>();
            crs.enabled = false;
            missel.enabled = false;
            dica.enabled = false;
            extras.enabled = false;
        }
    }

    IEnumerator esperaWL()
    {
        yield return new WaitForSeconds(0.001f);
        Painel_WL.SetActive(false);
        painel_Recompensa.SetActive(false);
    }

    void StartGameUIM()
    {
        GAMEMANAGER.instance.startGame = false;
        liberaMetodo_Painel_Guia = false;
        habilitabBtnsCena = false;
        habilitaBtnRestart = false;
        descarregaMissel = false;
        dicaComprada = false;
        ativa_painel_Dicas = false;
        ativa_Painel_Guia = false;

        xmoedas = ZPlayerPrefs.GetInt("qtdMoedas");
        soundMoedas = GetComponent<AudioSource>();

        if (LevelAtual.instance.level >= 6)
        {
            circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();
        }
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
                cristalTemp = 2;
                GAMEMANAGER.instance.ColetaCristalGreen(cristalTemp);
                GAMEMANAGER.instance.qtd_moedaSalvas += 50;
                GAMEMANAGER.instance.SalvaMoedasZ(GAMEMANAGER.instance.qtd_moedaSalvas);
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
                    cristalTemp = 3;
                    GAMEMANAGER.instance.ColetaCristalGreen(cristalTemp);
                    GAMEMANAGER.instance.qtd_moedaSalvas += 100;
                    GAMEMANAGER.instance.SalvaMoedasZ(GAMEMANAGER.instance.qtd_moedaSalvas);
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
                        cristalTemp = 5;
                        GAMEMANAGER.instance.ColetaCristalGreen(cristalTemp);//testando****
                        GAMEMANAGER.instance.qtd_moedaSalvas += 200;
                        GAMEMANAGER.instance.SalvaMoedasZ(GAMEMANAGER.instance.qtd_moedaSalvas);
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
    }

    public void RestartLevel()
    {
        if (GAMEMANAGER.instance.win == false && dicaComprada == false
            && GAMEMANAGER.instance.qtd_moedaSalvas >= 300)
        {
            StartCoroutine(WaitSoundClick_btnRestart());

            if (GAMEMANAGER.instance.liberaCargaCrs == false)
            {
                GAMEMANAGER.instance.qtd_moedaSalvas -= 300;
                GAMEMANAGER.instance.SalvaMoedasZ(GAMEMANAGER.instance.qtd_moedaSalvas);
            }
        }
        else if (GAMEMANAGER.instance.win == false && dicaComprada == true)
        {
            StartCoroutine(WaitSoundClick_btnRestart());
        }
    }

    //testando proximoLevel debloqueado
    public bool proximoLevel_desbloqueado = false;
    public void HabilitDesabilitBts_Painel_WL()
    {
        if (LevelAtual.instance.level >= 6)
        {
            if (ScoreManager.instance.waitCont == true)
            {
                btnVoltar_Painel_WL.interactable = true;
                btnNovamente_Painel_WL.interactable = true;
                btnProximo_Painel_WL.interactable = true;
            }
            else if (ScoreManager.instance.waitCont == false && GAMEMANAGER.instance.startGame == false)
            {
                btnVoltar_Painel_WL.interactable = false;
                btnNovamente_Painel_WL.interactable = false;
                btnProximo_Painel_WL.interactable = false;
            }
            else if (GAMEMANAGER.instance.lose == true)
            {
                btnVoltar_Painel_WL.interactable = true;
                btnNovamente_Painel_WL.interactable = true;

                //desabilita btn próximo caso o próximo level estiver bloqueado
                //ou habilita caso esteja desbloqueado
                VerificaNextLevel();
            }
        }
    }

    //metodo verifica se proximo level está desbloqueado
    //para habilitar btn proximo
    void VerificaNextLevel()
    {
        //cena MCS
        if (LevelAtual.instance.level >= 6 && LevelAtual.instance.level <= 30)
        {
            int temp = LevelAtual.instance.level - 5;
            temp++;

            if (ZPlayerPrefs.GetInt("Level" + temp + "_MCS") == 1)
            {
                btnProximo_Painel_WL.interactable = true;
                btnProximo_Painel_WL.gameObject.SetActive(true);
            }
            else
            {
                btnProximo_Painel_WL.interactable = false;
                btnProximo_Painel_WL.gameObject.SetActive(false);
            }
        }
        //cena MCH
        else if (LevelAtual.instance.level >= 31)
        {
            int temp = LevelAtual.instance.level - 30;
            temp++;
            if (ZPlayerPrefs.GetInt("Level" + temp + "_MCH") == 1)
            {
                btnProximo_Painel_WL.interactable = true;
                btnProximo_Painel_WL.gameObject.SetActive(true);
            }
            else
            {
                print("2");
                btnProximo_Painel_WL.interactable = false;
                btnProximo_Painel_WL.gameObject.SetActive(false);
            }
        }
        //cena MCAH
        else if (LevelAtual.instance.level == 10)
        {
            int temp = LevelAtual.instance.level - 9;
            temp++;
            ZPlayerPrefs.SetInt("Level" + temp + "_MCAH", 1);
        }
    }

    //libera restart
    public bool dicaComprada;

    public void habilitaBtnsCena()
    {
        if (GAMEMANAGER.instance.startGame == true 
            && (GAMEMANAGER.instance.lose == false && GAMEMANAGER.instance.win == false))
        {
            habilitabBtnsCena = true;
            habilitaBtnRestart = true;
        }
        else
        {
            habilitabBtnsCena = false;
            habilitaBtnRestart = false;
        }        

        if (LevelAtual.instance.level >= 6 && GAMEMANAGER.instance.painelExtraAtivado == false)
        {
            //btns gui e dica
            if (habilitabBtnsCena == true)
            {
                btnPainel_Guia.interactable = true;
                btnPainel_Dicas.interactable = true;
            }
            else if (habilitabBtnsCena == false)
            {
                btnPainel_Guia.interactable = false;
                btnPainel_Dicas.interactable = false;
            }

            //desabilita btn restant quando jogo está inicializando 
            if (GAMEMANAGER.instance.startGame == false)
            {
                btn_restart.interactable = false;
            }
            else            //habilita btnrestart quando possui moedas suficientes
            if (habilitaBtnRestart == true && GAMEMANAGER.instance.win == false
                && GAMEMANAGER.instance.qtd_moedaSalvas > 300 && GAMEMANAGER.instance.startGame == true)
            {
                btn_restart.interactable = true;
            }
            //desabilita se não possuir moedas suficientes e não tiver usando dicas
            else if (habilitaBtnRestart == false && GAMEMANAGER.instance.qtd_moedaSalvas < 30)
            {
                btn_restart.interactable = false;
            }

            //desabilita btn reiniciar uando num de tentativas menor que 3
            if (GAMEMANAGER.instance.num_tentativas <= 3 && dicaComprada == false)
            {
                btn_restart.interactable = false;
            }

            //desabilita btn sair quando play já usou uma tentativa
            if (GAMEMANAGER.instance.num_tentativas != circleManager.num_tentativas_Start)
            {
                btnSair.interactable = false;
            }
        }
    }

    public void AtivaDesativa_Painel_Guia(bool pl)
    {
        if (liberaMetodo_Painel_Guia == true)
        {
            if (pl == false)
            {
                TravaClicksMods();
                ativa_Painel_Guia = true;
                painel_Guia.SetActive(ativa_Painel_Guia);
                painel_Guia.GetComponent<Animator>().Play("Anime_PainelManual");
                StartCoroutine(Anime_Mao(ativa_Painel_Guia));

                FechaPainel_Dica();
                habilitaBtnRestart = false;
            }
            else
            {
                painel_Guia.GetComponent<Animator>().Play("Anime_PainelManualBack");
                ativa_Painel_Guia = false;
                DestravaClicksMods();
                anime_mao.SetActive(false);

                habilitaBtnRestart = true;
            }
        }
    }

    //Atualiza UI colocar cristal e missel em todas as cenas
    void AtualizaUI()
    {
        //Missel
        if (LevelAtual.instance.level >= 6)
        {
            txt_showNmissel.text = GAMEMANAGER.instance.cargaMissel.ToString();
            txt_showNmoeda.text = GAMEMANAGER.instance.qtd_moedaSalvas.ToString();
            txt_num_tentativas.text = GAMEMANAGER.instance.num_tentativas.ToString();
            AtualizaMoedaZ(GAMEMANAGER.instance.qtd_moedaSalvas);
        }
        //atualiza cristais
        if (GAMEMANAGER.instance.win == true || GAMEMANAGER.instance.liberaCristal == true)
        {
            AtualizaCristalGreen(GAMEMANAGER.instance.cristalGreen);
            AtualizaMoedaZ(GAMEMANAGER.instance.qtd_moedaSalvas);
        }
        if (GAMEMANAGER.instance.liberaCristal == true)//libera pelo btnrecompensa
        {
            AtualizaCristalGreen(GAMEMANAGER.instance.cristalGreen);
        }

    }

    public void AtivaDesativa_Painel_Dicas(bool pl)
    {
        //RepeteLevel.instance.animaMao_Dica.SetActive(false);

        if (liberaMetodo_Painel_Guia == true)
        {
            if (pl == false)
            {
                TravaClicksMods();
                ativa_painel_Dicas = true;
                painel_Dicas.SetActive(ativa_painel_Dicas);
                painel_Dicas.GetComponent<Animator>().Play("Anime_PainelDicas");

                FechaPainel_Guia();
                habilitaBtnRestart = false;
            }
            else
            {
                painel_Dicas.GetComponent<Animator>().Play("Anime_PainelDicasBack");
                ativa_painel_Dicas = false;
                DestravaClicksMods();

                habilitaBtnRestart = true;
            }
        }
    }

    //trava o click sobre os mods
    void TravaClicksMods()
    {
        for (int i = 0; i < circleManager.circles.Length; i++)
        {
            circleManager.circles[i].trava_Click = true;
        }
    }
    //destrava o click sobre os mods
    void DestravaClicksMods()
    {
        for (int i = 0; i < circleManager.circles.Length; i++)
        {
            circleManager.circles[i].trava_Click = false;
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

    //Contagem final do total de cristais ganhos
    public float xcristal;
    public float velCon;
    public void AtualizaCristalGreen(int cristais)
    {
        if (xcristal < cristais)
        {
            if (cristais <= 100)
                xcristal += 1 + (velCon * Time.deltaTime);
            else if (cristais > 100 || cristais <= 1000)
                xcristal += 10 + (velCon * Time.deltaTime);
            else
                xcristal += 100;


            txtCristalGreen.text = xcristal.ToString("F0");

            if (xcristal > cristais)
            {
                xcristal = cristais;
                txtCristalGreen.text = xcristal.ToString("F0");
            }
        }
        else if (xcristal > cristais)
        {
            xcristal -= 1 + (velCon * Time.deltaTime);

            txtCristalGreen.text = xcristal.ToString("F0");

            if (xcristal < cristais)
            {
                xcristal = cristais;
                txtCristalGreen.text = xcristal.ToString("F0");
            }
            if (xcristal == cristais)
            {
                GAMEMANAGER.instance.liberaCristal = false;
            }
        }
    }

    //Contagem final do total de moedas ganhas
    public float xmoedas;
    public void AtualizaMoedaZ(int moedas)
    {
        if (xmoedas < moedas)
        {
            if (moedas <= 100)
                xmoedas += 1 + (velCon * Time.deltaTime);
            else if (moedas > 100 || moedas <= 1000)
                xmoedas += 10 + (velCon * Time.deltaTime);
            else
                xmoedas += 100 + (velCon * Time.deltaTime);

            //efeito de audio da contagem das moedas
            if (soundMoedas != null)
            {
                soundMoedas.Play();
            }

            txt_showNmoeda.text = xmoedas.ToString("F0");

            if (xmoedas > moedas)
            {
                xmoedas = moedas;
                txt_showNmoeda.text = xmoedas.ToString("F0");
            }
        }
        else if (xmoedas > moedas)
        {
            if (moedas <= 100)
                xmoedas -= 1 + (velCon * Time.deltaTime);
            else if (moedas > 100 || moedas <= 1000)
                xmoedas -= 10 + (velCon * Time.deltaTime);
            else
                xmoedas -= 100 + (velCon * Time.deltaTime);

            //efeito de audio da contagem das moedas
            if (soundMoedas != null)
            {
                soundMoedas.Play();
            }

            txt_showNmoeda.text = xmoedas.ToString("F0");

            if (xmoedas < moedas)
            {
                xmoedas = moedas;
                txt_showNmoeda.text = xcristal.ToString("F0");
            }
        }
    }

    public bool descarregaMissel;
    //converte mísseis em moedas
    public void ConverteMisselToCoin()
    {
        if (GAMEMANAGER.instance.win == true && GAMEMANAGER.instance.cargaMissel > 0
            && descarregaMissel == true && ScoreManager.instance.waitCont == true)
        {
            descarregaMissel = false;
            StartCoroutine(convertTeste());
        }
    }

    //testando convertemissel to coin
    IEnumerator convertTeste()
    {
        yield return new WaitForSeconds(0.5f);
        if(GAMEMANAGER.instance.cargaMissel > 0)
        {
            GAMEMANAGER.instance.cargaMissel -= 1;
        }
        GAMEMANAGER.instance.qtd_moedaSalvas += 5;
        descarregaMissel = true;
    }

    IEnumerator WaitSoundClick(string s)
    {
        yield return new WaitForSeconds(0.4f);
        UI_Metodo.CarregaCena(s);
    }

    //btn novamente
    IEnumerator WaitSoundClick_btnRestart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(LevelAtual.instance.level);
        RepeteLevel.instance.SaveRepetLevel();

        //deve ser zerado para não descotar no scoreFinal
        GAMEMANAGER.instance.numTentativasExtras = 0;
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
