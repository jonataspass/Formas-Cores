using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
//using UnityEngine.Advertisements;

public class GAMEMANAGER : MonoBehaviour
{
    public static GAMEMANAGER instance;

    //VARIÁVEIS DE AJUSTES DE VISUALIZAÇÃO
    //private float orthoSize = 5;
    //[SerializeField]
    //private float aspect = 1.66f;

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
        //ZPlayerPrefs.DeleteAll();
        //ZPlayerPrefs.DeleteKey("Level3_MCS");
    }

    //GameObject com Script CircleManager
    public CircleManager circleManager;

    //*******criar outros circleManagers para gerenciar estações interdependentes****
    public CircleManager circleManager1;

    //Variáveis de Win
    public bool win, lose;

    //variável que destrava inicialização do jogo
    public bool startGame;

    //variável de canhao ativo
    public int ativosTemp = 0;

    //variável que armazena quantidade de cristais green
    public int cristalGreen;
    //variável que indica que cristal foi coletado
    public bool coletouCrs;
    public int id_Crs_gameManager;

    //capacetes conquistados btns fases MCS, MCH, MCAH
    public int numCapacetes;

    //capacetes conquistados dos btns da faseMestra;
    public int numCapsB, numCapsP, numCapsO;
    public int capsOuro_msOne, capsOuro_msTwo;

    //numero de tentativas 
    public int num_tentativas;

    //testando****
    //componentes do missel - relacionado com os scripts Rotationmeteor  e Missel
    public float powerMissel = 5;
    public float speedMissel;
    public Vector2 positioMeteor;
    public int cargaMissel;

    public int numextrameteor;

    public bool misselAtivo;

    public bool canhaoAtivo;

    //TEXT NUM MOEDAS DO PREFAB MOEDA
    public int txt_numMoedaspref;
    //public int txt_moedasSalvas;
    public int qtd_moedaSalvas;
    //public int moedaPegas, total de moedas pegas em um level
    public int moedaPegas;

    //testando****
    //cristais que estão no btncarrega cristal
    public int CrsCargaAtiva;

    public bool travaPanelInit;
    public GameObject Panel_InitEnergy;

    //desativa os txts do script CanvasObjs C: 
    //"Sem energia para inicializar os módulos\n click em novamenete e depois carregue com cristais" 
    //"Sem energia para inicializar os módulos\n carregue com cristais"
    public bool destTxtCanvas;

    private bool AdsOnceTime = false;

    //recompensas capacetes
    public int recompensaCapaceteB, recompensaCapaceteP, recompensaCapaceteO;
    //recompensas experiências
    public int totalScore_recompensas;
    //recompensa destroyer
    public int totalMeteorDestuidos;

    //painel extras
    public bool liberalose;
    public bool travaPainelExtras;

    //randon que libera oferta de compra de tentativas extras
    //se liberaExtras == 1 oferece tentativas extras
    //se for diferente chama Lose
    public float liberaExtras;

    //variável usada para qando o painel de tentativas extras for ativado
    //os btns restart, guia, dica e sair devem ser desativados quado exta variável for true
    public bool painelExtraAtivado;

    //variável que destrava o click sobre os módulos depois que o player...
    //adquire tentativas extras
    public bool getExtra;

    public int numTentativasExtras;

    public int numTotalmeteor;

    //variáveis desbloquia mestra, usada no script ShowPts_Caps    
    public int desbloMS1, desbloMS2, desbloMS3;
    //testando variavel para atualizar pts btn fase mestra
    ShowPts_Caps ptsMestra;

    //Carrega cena
    void Carrega(Scene cena, LoadSceneMode modo)
    {
        ////visualização da camera
        //Camera.main.projectionMatrix = Matrix4x4.Ortho(-orthoSize * aspect, orthoSize * aspect, -orthoSize, orthoSize,
        //    Camera.main.nearClipPlane, Camera.main.farClipPlane);

        //desbloqueio de fase mestra MCH
        if (ZPlayerPrefs.HasKey("DesbloqMCH"))
        {
            desbloMS2 = ZPlayerPrefs.GetInt("DesbloqMCH");
        }

        //carrega meteoros destruidos
        if (ZPlayerPrefs.HasKey("meteorsDestruidos"))
        {
            totalMeteorDestuidos = ZPlayerPrefs.GetInt("meteorsDestruidos");
        }

        //Salva cristais
        if (ZPlayerPrefs.HasKey("cristaisGreen_Total"))
        {
            cristalGreen = ZPlayerPrefs.GetInt("cristaisGreen_Total");
        }

        //salva Missel
        if (ZPlayerPrefs.HasKey("cargaMissel"))
        {
            cargaMissel = ZPlayerPrefs.GetInt("cargaMissel");
            //txt_moedasSalvas = cargaMissel;
        }

        //Salva MoedasZ
        if (ZPlayerPrefs.HasKey("qtdMoedas"))
        {
            //print("moedasS");
            qtd_moedaSalvas = ZPlayerPrefs.GetInt("qtdMoedas");
        }

        if (LevelAtual.instance.level >= 6)
        {
            //num_tentativas = circleManager.num_tentativas_Start;
        }

        //carga de critais para inicializar o sistema
        if (!ZPlayerPrefs.HasKey("cargaCrs"))
        {
            ZPlayerPrefs.SetInt("cargaCrs", 5);
        }
        else if (ZPlayerPrefs.HasKey("cargaCrs"))
        {
            CrsCargaAtiva = ZPlayerPrefs.GetInt("cargaCrs");
        }

        if (LevelAtual.instance.level >= 6)
        {
            circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();

            StartGame();
        }

    }

    void StartGame()
    {
        //Advertisement.Initialize("4238821");
        num_tentativas = circleManager.num_tentativas_Start;
        win = false;
        lose = false;
        liberaCristal = false;
        misselAtivo = false;
        canhaoAtivo = true;
        //teste
        Panel_InitEnergy = GameObject.FindWithTag("PanelInitEnergy");
        Panel_InitEnergy.SetActive(false);
        //teste
        liberaCargaCrs = false;
        AdsOnceTime = false;
        travaBtnReompensa = false;
        destTxtCanvas = false;
        getExtra = false;
        moedaPegas = 0;
        extraTry = circleManager.num_extraTry;
        painelExtraAtivado = false;
        numTentativasExtras = 0;
        precoTentarNovamente = GameObject.Find("TextPrecoItem").GetComponent<TextMeshProUGUI>();
        ScoreManager.instance.ptsMarcados_Total = 0;
        ScoreManager.instance.conta_ptsMarcados = 0;
        coletouCrs = false;

        liberaExtras = Random.Range(1, 4);//*****

        ////Salva cristais
        //if (ZPlayerPrefs.HasKey("cristaisGreen_Total"))
        //{
        //    cristalGreen = ZPlayerPrefs.GetInt("cristaisGreen_Total");
        //}

        ////salva Missel
        //if (ZPlayerPrefs.HasKey("cargaMissel"))
        //{
        //    cargaMissel = ZPlayerPrefs.GetInt("cargaMissel");
        //    //txt_moedasSalvas = cargaMissel;
        //}

        ////Salva MoedasZ
        //if (ZPlayerPrefs.HasKey("qtdMoedas"))
        //{
        //    //print("moedasS");
        //    qtd_moedaSalvas = ZPlayerPrefs.GetInt("qtdMoedas");
        //}

        //if (LevelAtual.instance.level >= 6)
        //{
        //    //num_tentativas = circleManager.num_tentativas_Start;
        //}

        ////carga de critais para inicializar o sistema
        //if (!ZPlayerPrefs.HasKey("cargaCrs"))
        //{
        //    ZPlayerPrefs.SetInt("cargaCrs", 5);
        //}
        //else if (ZPlayerPrefs.HasKey("cargaCrs"))
        //{
        //    CrsCargaAtiva = ZPlayerPrefs.GetInt("cargaCrs");
        //}        

        //canhões
        ativosTemp = 0;
        numTotalmeteor = 0;

        //ZPlayerPrefs.DeleteAll();
    }

    //salva missel
    public void SalvaMissel(int carga)
    {
        //cargaMissel += carga;

        if (!ZPlayerPrefs.HasKey("cargaMissel"))
        {
            ZPlayerPrefs.SetInt("cargaMissel", carga);
        }
        else
        {
            ZPlayerPrefs.SetInt("cargaMissel", carga);
        }
    }

    public int canTest;

    public void YouWin(int canhoes, int ativos)
    {
        canTest = canhoes;

        if (ativos == 1)
        {
            ativosTemp++;
        }
        else if (ativos == 0)
        {
            if (ativosTemp == 0)
            {
                ativosTemp = 0;
            }
            else if (ativosTemp > 0)
            {
                ativosTemp--;
            }
        }

        if (canhoes == ativosTemp)
        {
            win = true;
            lose = false;
        }

        if (win == true)
        {
            //ScoreManager.instance.ptsMarcados_Total += 100;
            circleManager.ScoreFinal();
            DesabClicks();
            DesbloqueiaLevel();

            UIManager.instance.txt_Painel_WL.text = "You Win";
            UIManager.instance.btn_restart.interactable = false;

            FeedBackObjetivo();

            //SALVA LEVEIS QUE JÁ FORAM JOGADOS
            //POSSIBILITA HABILITAR BTNPROXIMO PARA O PROXIMO LEVEL
            //if (!ZPlayerPrefs.HasKey(LevelAtual.instance.cenaAtual))
            //{
            //    ZPlayerPrefs.SetInt(LevelAtual.instance.cenaAtual + "levelConcluido", 1);
            //}

            //if (moedaPegas == 0 && circleManager.totalClicks == circleManager.num_tentativas_Ideal)
            //{
            //    UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você completou 100% do objetivo!!!";
            //}
            //else if (moedaPegas == circleManager.totalMoedasLevel && circleManager.totalClicks == circleManager.num_tentativas_Ideal)
            //{
            //    UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você completou 100% do objetivo!!!";
            //}
            //else if (moedaPegas == circleManager.totalMoedasLevel && circleManager.totalClicks > circleManager.num_tentativas_Ideal)
            //{
            //    UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você coletou todas as moedasZ, \n porém deu "
            //        + (circleManager.totalClicks - circleManager.num_tentativas_Ideal) + " clicks a mais!!!";
            //}
            //else if (moedaPegas == circleManager.totalMoedasLevel && circleManager.totalClicks < circleManager.num_tentativas_Ideal)
            //{
            //    UIManager.instance.txt_Painel_info_WL.text = "Fantástico, você completou 100% do objetivo com "
            //        + (circleManager.num_tentativas_Ideal - circleManager.totalClicks) + " clicks a menos!!!";
            //}
            //else if (moedaPegas < circleManager.totalMoedasLevel && circleManager.totalClicks == circleManager.num_tentativas_Ideal)
            //{
            //    UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você alinhou todos os módulos mas deixou para trás "
            //        + (circleManager.totalMoedasLevel - moedaPegas) + " moedaZ!!!";
            //}
            //else if (moedaPegas < circleManager.totalMoedasLevel && circleManager.totalClicks > circleManager.num_tentativas_Ideal)
            //{
            //    UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você alinhou todos os módulos, \n porém deu "
            //        + (circleManager.totalClicks - circleManager.num_tentativas_Ideal) + " clicks a mais e deixou para trás "
            //        + (circleManager.totalMoedasLevel - moedaPegas) + " moedaZ!!!";
            //}
            //else if (moedaPegas < circleManager.totalMoedasLevel && circleManager.totalClicks < circleManager.num_tentativas_Ideal)
            //{
            //    UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você alinhou todos os módulos com apenas "
            //        + (circleManager.totalClicks) + " clicks, porém deixou para trás "
            //        + (circleManager.totalMoedasLevel - moedaPegas) + " moedaZ!!!";
            //}

            UIManager.instance.UI_Win();

            //if (ZPlayerPrefs.HasKey(LevelAtual.instance.level + "cristaisGreenB"))
            //{
            //    //ColetaCristalGreen(1);
            //    //qtd_moedaSalvas += 50;
            //}
            //if (ZPlayerPrefs.HasKey(LevelAtual.instance.level + "cristaisGreenP"))
            //{
            //    //ColetaCristalGreen(1);
            //    //qtd_moedaSalvas += 50;
            //}
            //if (ZPlayerPrefs.HasKey(LevelAtual.instance.level + "cristaisGreenO"))
            //{
            //    //ColetaCristalGreen(1);
            //    //qtd_moedaSalvas += 50;
            //}

            //SalvaMissel(cargaMissel);
            SalvaMoedasZ(qtd_moedaSalvas);
            SalveCargaCrs(CrsCargaAtiva);
            //Salva crscoletado em cena para destruílo se a cena for jogada novamente
            SalvaCrsColetado(id_Crs_gameManager);

            UIManager.instance.habilitabBtnsCena = false;
            UIManager.instance.habilitaBtnRestart = false;
            startGame = false;

            //anuncio
            if (AdsOnceTime == false)
            {
                UnityAds.instance.ShowAds();
                AdsOnceTime = true;
            }

            UIManager.instance.descarregaMissel = true;
            SalvaMissel(0);
        }
    }

    void FeedBackObjetivo()
    {
        if (moedaPegas == 0 && circleManager.totalClicks == circleManager.num_tentativas_Ideal)
        {
            UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você completou 100% do objetivo!!!";
        }
        else if (moedaPegas == circleManager.totalMoedasLevel && circleManager.totalClicks == circleManager.num_tentativas_Ideal)
        {
            UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você completou 100% do objetivo!!!";
        }
        else if (moedaPegas == circleManager.totalMoedasLevel && circleManager.totalClicks > circleManager.num_tentativas_Ideal 
            && (circleManager.totalMoedasLevel == 1 && circleManager.totalClicks == 1))
        {
            UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você coletou a moedaZ, \n porém deu "
                + (circleManager.totalClicks - circleManager.num_tentativas_Ideal) + " click a mais!!!";
        }
        else if (moedaPegas == circleManager.totalMoedasLevel && circleManager.totalClicks > circleManager.num_tentativas_Ideal
            && (circleManager.totalMoedasLevel == 1 && circleManager.totalClicks > 1))
        {
            UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você coletou a moedaZ, \n porém deu "
                + (circleManager.totalClicks - circleManager.num_tentativas_Ideal) + " clicks a mais!!!";
        }
        else if (moedaPegas == circleManager.totalMoedasLevel && circleManager.totalClicks > circleManager.num_tentativas_Ideal
            && (moedaPegas > 1 && circleManager.totalClicks == 1))
        {
            UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você coletou todas as moedasZ, \n porém deu "
                + (circleManager.totalClicks - circleManager.num_tentativas_Ideal) + " click a mais!!!";
        }
        else if (moedaPegas == circleManager.totalMoedasLevel && circleManager.totalClicks > circleManager.num_tentativas_Ideal
            && (moedaPegas > 1 && circleManager.totalClicks > 1))
        {
            UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você coletou todas as moedasZ, \n porém deu "
                + (circleManager.totalClicks - circleManager.num_tentativas_Ideal) + " clicks a mais!!!";
        }
        else if (moedaPegas == circleManager.totalMoedasLevel && circleManager.totalClicks < circleManager.num_tentativas_Ideal
            && circleManager.totalClicks > 1)
        {
            UIManager.instance.txt_Painel_info_WL.text = "Fantástico, você completou 100% do objetivo com "
                + (circleManager.num_tentativas_Ideal - circleManager.totalClicks) + " clicks a menos!!!";
        }
        else if (moedaPegas == circleManager.totalMoedasLevel && circleManager.totalClicks < circleManager.num_tentativas_Ideal
            && circleManager.totalClicks == 1)
        {
            UIManager.instance.txt_Painel_info_WL.text = "Fantástico, você completou 100% do objetivo com "
                + (circleManager.num_tentativas_Ideal - circleManager.totalClicks) + " click a menos!!!";
        }
        else if (moedaPegas < circleManager.totalMoedasLevel && circleManager.totalClicks == circleManager.num_tentativas_Ideal
            && (circleManager.totalMoedasLevel - moedaPegas) == 1)
        {
            UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você alinhou os módulos mas deixou para trás "
                + (circleManager.totalMoedasLevel - moedaPegas) + " moedaZ!!!";
        }
        else if (moedaPegas < circleManager.totalMoedasLevel && circleManager.totalClicks == circleManager.num_tentativas_Ideal
            && (circleManager.totalMoedasLevel - moedaPegas) > 1)
        {
            UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você alinhou os módulos mas deixou para trás "
                + (circleManager.totalMoedasLevel - moedaPegas) + " moedasZ!!!";
        }
        else if (moedaPegas < circleManager.totalMoedasLevel && circleManager.totalClicks > circleManager.num_tentativas_Ideal
            && ((circleManager.totalMoedasLevel - moedaPegas) == 1 && circleManager.totalClicks == 1))
        {
            UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você alinhou os módulos, \n porém deu "
                + (circleManager.totalClicks - circleManager.num_tentativas_Ideal) + " click a mais e deixou para trás "
                + (circleManager.totalMoedasLevel - moedaPegas) + " moedaZ!!!";
        }
        else if (moedaPegas < circleManager.totalMoedasLevel && circleManager.totalClicks > circleManager.num_tentativas_Ideal
            && ((circleManager.totalMoedasLevel - moedaPegas) > 1 && circleManager.totalClicks == 1))
        {
            UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você alinhou os módulos, \n porém deu "
                + (circleManager.totalClicks - circleManager.num_tentativas_Ideal) + " click a mais e deixou para trás "
                + (circleManager.totalMoedasLevel - moedaPegas) + " moedasZ!!!";
        }
        else if (moedaPegas < circleManager.totalMoedasLevel && circleManager.totalClicks > circleManager.num_tentativas_Ideal
            && ((circleManager.totalMoedasLevel - moedaPegas) > 1 && circleManager.totalClicks > 1))
        {
            UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você alinhou os módulos, \n porém deu "
                + (circleManager.totalClicks - circleManager.num_tentativas_Ideal) + " clicks a mais e deixou para trás "
                + (circleManager.totalMoedasLevel - moedaPegas) + " moedasZ!!!";
        }
        else if (moedaPegas < circleManager.totalMoedasLevel && circleManager.totalClicks > circleManager.num_tentativas_Ideal
            && ((circleManager.totalMoedasLevel - moedaPegas) == 1 && circleManager.totalClicks > 1))
        {
            UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você alinhou os módulos, \n porém deu "
                + (circleManager.totalClicks - circleManager.num_tentativas_Ideal) + " clicks a mais e deixou para trás "
                + (circleManager.totalMoedasLevel - moedaPegas) + " moedaZ!!!";
        }
        else if (moedaPegas < circleManager.totalMoedasLevel && circleManager.totalClicks < circleManager.num_tentativas_Ideal
            && ((circleManager.totalMoedasLevel - moedaPegas) == 1 && circleManager.totalClicks == 1))
        {
            UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você alinhou todos os módulos com apenas "
                + (circleManager.totalClicks) + " click, porém deixou para trás "
                + (circleManager.totalMoedasLevel - moedaPegas) + " moedaZ!!!";
        }
        else if (moedaPegas < circleManager.totalMoedasLevel && circleManager.totalClicks < circleManager.num_tentativas_Ideal
            && ((circleManager.totalMoedasLevel - moedaPegas) == 1 && circleManager.totalClicks > 1))
        {
            UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você alinhou todos os módulos com apenas "
                + (circleManager.totalClicks) + " clicks, porém deixou para trás "
                + (circleManager.totalMoedasLevel - moedaPegas) + " moedaZ!!!";
        }
        else if (moedaPegas < circleManager.totalMoedasLevel && circleManager.totalClicks < circleManager.num_tentativas_Ideal
            && ((circleManager.totalMoedasLevel - moedaPegas) > 1 && circleManager.totalClicks == 1))
        {
            UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você alinhou todos os módulos com apenas "
                + (circleManager.totalClicks) + " click, porém deixou para trás "
                + (circleManager.totalMoedasLevel - moedaPegas) + " moedasZ!!!";
        }
        else if (moedaPegas < circleManager.totalMoedasLevel && circleManager.totalClicks < circleManager.num_tentativas_Ideal
            && ((circleManager.totalMoedasLevel - moedaPegas) > 1 && circleManager.totalClicks > 1))
        {
            UIManager.instance.txt_Painel_info_WL.text = "Parabéns, você alinhou todos os módulos com apenas "
                + (circleManager.totalClicks) + " clicks, porém deixou para trás "
                + (circleManager.totalMoedasLevel - moedaPegas) + " moedasZ!!!";
        }
    }

    //salva os cristais que ja foram coletados para que eles não apareçam na cena novamente
    public void SalvaCrsColetado(int id_crs)
    {
        if(coletouCrs == true)
        {
            if (!ZPlayerPrefs.HasKey(LevelAtual.instance.level + id_crs + "cristalRecolhido"))
            {
                ZPlayerPrefs.SetInt(LevelAtual.instance.level + id_crs + "cristalRecolhido", 1);
            }
        }
    }

    //VERIFICA SE TODOS OS LAZER ESTÃO ATIVADOS
    public void VerificaLose()
    {
        YouLose(CircleCS_Gray.instance.numCanhoes, ativosTemp);
    }

    //lose por acabar as tentativas
    public void YouLose(int canhoes, int ativados)
    {
        //print("lose");
        if (ativados < canhoes)
        {
            //print("loseIN");
            lose = true;
            DesabClicks();
            UIManager.instance.txt_Painel_WL.text = "You Lose!!!";
            UIManager.instance.txt_Painel_info_WL.text = "Acabaram suas tentativas";
            UIManager.instance.UI_Win();
            UIManager.instance.habilitabBtnsCena = false;
            UIManager.instance.habilitaBtnRestart = false;            

            if (AdsOnceTime == false)
            {
                UnityAds.instance.ShowAds();
                AdsOnceTime = true;
            }

            //habilita anúncio Dica_R
            RepeteLevel.instance.HabilitaDica_R();
            numTentativasExtras = 0;
        }
    }

    //Desabilita clicks quando o jogo chega ao fim
    void DesabClicks()
    {
        for (int i = 0; i < circleManager.circles.Length; i++)
        {
            circleManager.circles[i].ativa = false;
        }
    }

    //Desbloqueia uma nova fase quando um level é concluído
    void DesbloqueiaLevel()
    {
        //cena MCS
        if (LevelAtual.instance.level >= 6 && LevelAtual.instance.level <= 30)
        {
            int temp = LevelAtual.instance.level - 5;
            temp++;
            ZPlayerPrefs.SetInt("Level" + temp + "_MCS", 1);
        }
        //cena MCH
        else if (LevelAtual.instance.level >= 31)
        {
            int temp = LevelAtual.instance.level - 30;
            temp++;
            ZPlayerPrefs.SetInt("Level" + temp + "_MCH", 1);
        }
        //cena MCAH
        else if (LevelAtual.instance.level == 10)
        {
            int temp = LevelAtual.instance.level - 9;
            temp++;
            ZPlayerPrefs.SetInt("Level" + temp + "_MCAH", 1);
        }
    }

    public void SalvaMoedasZ(int moedas)
    {
        if (!ZPlayerPrefs.HasKey("qtdMoedas"))
        {
            ZPlayerPrefs.SetInt("qtdMoedas", moedas);
        }
        else
        {
            ZPlayerPrefs.SetInt("qtdMoedas", moedas);
        }
    }

    //SalvaCapacetes mostrados nos btns das fases MCS, MCH, MCAH
    public void SalvaCapacetes(int nCapacetes)
    {
        if (win == true)
        {
            if (!ZPlayerPrefs.HasKey(LevelAtual.instance.cenaAtual + "capacete"))
            {
                ZPlayerPrefs.SetInt(LevelAtual.instance.cenaAtual + "capacete", nCapacetes);
            }
            else if (ZPlayerPrefs.GetInt(LevelAtual.instance.cenaAtual + "capacete") < nCapacetes)
            {
                ZPlayerPrefs.SetInt(LevelAtual.instance.cenaAtual + "capacete", nCapacetes);                
            }
        }
    }

    //SalvaCapacetes moostrados nos btns da faseMestra
    public void SalvaCapacetes_Mestra(int nCapacetes)
    {
        if (win == true)
        {
            if (!ZPlayerPrefs.HasKey(LevelAtual.instance.cenaAtual + "capaceteBronze") && nCapacetes == 1)
            {
                ZPlayerPrefs.SetInt(LevelAtual.instance.cenaAtual + "capaceteBronze", numCapsB);
            }
            else if (!ZPlayerPrefs.HasKey(LevelAtual.instance.cenaAtual + "capacetePrata") && nCapacetes == 2)
            {
                ZPlayerPrefs.SetInt(LevelAtual.instance.cenaAtual + "capaceteBronze", numCapsB);
                ZPlayerPrefs.SetInt(LevelAtual.instance.cenaAtual + "capacetePrata", numCapsP);
            }
            else if (!ZPlayerPrefs.HasKey(LevelAtual.instance.cenaAtual + "capaceteOuro") && nCapacetes == 3)
            {
                ZPlayerPrefs.SetInt(LevelAtual.instance.cenaAtual + "capaceteBronze", numCapsB);
                ZPlayerPrefs.SetInt(LevelAtual.instance.cenaAtual + "capacetePrata", numCapsP);
                ZPlayerPrefs.SetInt(LevelAtual.instance.cenaAtual + "capaceteOuro", numCapsO);
            }
        }
    }

    //Salva a carga ativa de cristais no btnCarrgaCrs
    public void SalveCargaCrs(int cgCrs)
    {
        ZPlayerPrefs.SetInt("cargaCrs", cgCrs);

        CrsCargaAtiva = cgCrs;
    }

    public void ColetaCristalGreen(int crsG)
    {
        cristalGreen += crsG;
        SalvaCristais(cristalGreen);
    }

    public void DecrementaCristal(int crsG)
    {
        liberaCristal = true;
        cristalGreen -= crsG;
        SalvaCristais(cristalGreen);
    }

    //Salva Cristais  
    public bool liberaCristal;
    public bool liberaCargaCrs;
    public void SalvaCristais(int cristais)
    {
        if (win == true || liberaCristal == true)
        {
            if (!ZPlayerPrefs.HasKey("cristaisGreen_Total"))
            {
                ZPlayerPrefs.SetInt("cristaisGreen_Total", cristais);
            }
            else
            {
                ZPlayerPrefs.SetInt("cristaisGreen_Total", cristais);
            }
        }
        else if (liberaCargaCrs == true)
        {
            ZPlayerPrefs.SetInt("cristaisGreen_Total", cristais);
            liberaCargaCrs = false;
        }
    }

    //SALVA METEOROS DESTRUÍDOS
    public void SalvaMetDestruidos(int metsDestruidos)
    {
        if (!ZPlayerPrefs.HasKey("meteorsDestruidos"))
        {
            ZPlayerPrefs.SetInt("meteorsDestruidos", metsDestruidos);
        }
        else
        {
            ZPlayerPrefs.SetInt("meteorsDestruidos", metsDestruidos);
        }
    }

    //testando****
    public void ShowTextEnergy(int indexVet)
    {
        UIManager.instance.textEnergy.text = circleManager.circles[indexVet].currentlife.ToString();
    }

    public void HabTex_Informativo(string s)
    {
        StartCoroutine(txtInformativo(s));
    }

    IEnumerator txtInformativo(string s)
    {
        UIManager.instance.txt_Informativo.text = s;
        UIManager.instance.txt_Informativo.enabled = true;
        yield return new WaitForSeconds(3);
        UIManager.instance.txt_Informativo.enabled = false;
    }

    //Aviso sistema sem crsital
    public bool ativapainelRecompensa;
    public bool travaBtnReompensa;
    public void HabTex_Infor_NoCrs(string s)
    {
        UIManager.instance.txt_Informativo.text = s;
        UIManager.instance.txt_Informativo.enabled = true;
    }

    //Oferece comprar mais tentativas extras
    public TextMeshProUGUI precoTentarNovamente;
    public int extraTry;    
    public void OfereceTentativasExtras()
    {
        //ADD VALOR E QUANTIDADE DE TENTATIVS EXTRAS
        if (qtd_moedaSalvas >= extraTry * 100)
        {     
            precoTentarNovamente.text = (extraTry * 100).ToString();
            //ativa painel comprar tentativas
            UIManager.instance.painel_CompraExtra.SetActive(true);
            UIManager.instance.txtTipoItem.text = "Suas tentativas acabaram, compre " + extraTry + " tentativas extras para continuar jogando";
            UIManager.instance.btnComprar.gameObject.SetActive(true);
            UIManager.instance.txtTipoItem.enabled = true;
            UIManager.instance.imgExtra.enabled = true;
            UIManager.instance.txtExtra.enabled = true;
        }
        //else if (qtd_moedaSalvas < extraTry * 100)
        //{
        //    print("AQUI");
        //    StartCoroutine(AvisoSemTentativas());
        //}
    }

    //IEnumerator AvisoSemTentativas()
    //{
    //    yield return new WaitForSeconds(1f);
    //    HabTex_Infor_NoCrs("Suas tentativas acabaram, \n clique no botão abaixo e assista um vídeo para ganhar " + extraTry + " tentativas extras");
    //    UIManager.instance.painel_Recompensa.SetActive(true);
    //    UIManager.instance.extras.enabled = true;
    //    travaPainelExtras = false;
    //}
}


