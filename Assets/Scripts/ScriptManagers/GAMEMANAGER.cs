using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GAMEMANAGER : MonoBehaviour
{
    public static GAMEMANAGER instance;

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
    }

    //GameObject com Script CircleManager
    public CircleManager circleManager;

    //*******criar outros circleManagers para gerenciar estações interdependentes****
    public CircleManager circleManager1;

    //Variáveis de Win
    public bool win, lose;

    //testando****variável que destrava inicialização do jogo
    public bool startGame;

    //variável de canhao ativo
    public int ativosTemp = 0;

    //variável que armazena quantidade de cristais green
    public int cristalGreen;

    //capacetes conquistados btns fases MCS, MCH, MCAH
    public int numCapacetes;

    //capacetes conquistados dos btns da faseMestra
    public int numCapsB, numCapsP, numCapsO;

    //numero de tentativas testando****
    public int num_tentativas;

    //testando****
    //componentes do missel - relacionado com os scripts Rotationmeteor  e Missel
    public float powerMissel = 5;
    public float speedMissel;
    public Vector2 positioMeteor;
    public int cargaMissel;

    public int numextrameteor;

    public bool misselAtivo;

    //Carrega cena
    void Carrega(Scene cena, LoadSceneMode modo)
    {

        if (LevelAtual.instance.level >= 6)
        {
            circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();

            StartGame();
        }
    }

    void StartGame()
    {
        win = false;
        lose = false;
        liberaCristal = false;
        misselAtivo = false;

        //pontuação
        ScoreManager.instance.ptsMarcados_Total = 0;
        ScoreManager.instance.conta_ptsMarcados = 0;

        //Salva cristais
        if (ZPlayerPrefs.HasKey("cristaisGreen_Total"))
        {
            cristalGreen = ZPlayerPrefs.GetInt("cristaisGreen_Total");
        }

        //salva Missel
        if (ZPlayerPrefs.HasKey("cargaMissel"))
        {
            cargaMissel = ZPlayerPrefs.GetInt("cargaMissel");
        }

        if(LevelAtual.instance.level >= 6)
        {
            num_tentativas = circleManager.num_tentativas_Start;
        }

        //canhões
        ativosTemp = 0;

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
        }

        if (win == true)
        {
            //ScoreManager.instance.ptsMarcados_Total += 100;
            circleManager.ScoreFinal();
            DesabClicks();
            DesbloqueiaLevel();

            UIManager.instance.txt_Painel_WL.text = "You Win!!!";
            UIManager.instance.txt_Painel_info_WL.text = "";
            UIManager.instance.UI_Win();

            if (ZPlayerPrefs.HasKey(LevelAtual.instance.level + "cristaisGreenB"))
            {
                ColetaCristalGreen(1);
            }
            if (ZPlayerPrefs.HasKey(LevelAtual.instance.level + "cristaisGreenP"))
            {
                ColetaCristalGreen(1);
            }
            if (ZPlayerPrefs.HasKey(LevelAtual.instance.level + "cristaisGreenO"))
            {
                ColetaCristalGreen(1);
            }
            
                SalvaMissel(cargaMissel);            

            UIManager.instance.habilitabBtnsCena = false;
            UIManager.instance.habilitaBtnRestart = false;
            startGame = false;
        }
    }


    public void YouLose(int canhoes, int ativados)
    {
        if (ativados < canhoes)
        {
            lose = true;
            DesabClicks();
            UIManager.instance.txt_Painel_WL.text = "You Lose!!!";
            UIManager.instance.txt_Painel_info_WL.text = "Acabaram suas tentativas";
            UIManager.instance.UI_Win();
            UIManager.instance.habilitabBtnsCena = false;
            UIManager.instance.habilitaBtnRestart = false;
        }
        //else if (ativados < canhoes && circleManager.currentLifeTotal == 0)
        //{
        //    lose = true;
        //    DesabClicks();
        //    UIManager.instance.txt_Painel_WL.text = "You Lose!!!";
        //    UIManager.instance.txt_Painel_info_WL.text = "Todos os seus módulos estão sem energia";
        //    UIManager.instance.UI_Win();
        //    UIManager.instance.habilitabBtnsCena = false;
        //    UIManager.instance.habilitaBtnRestart = false;
        //}
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
        if (LevelAtual.instance.level >= 6 && LevelAtual.instance.level <= 100)
        {
            int temp = LevelAtual.instance.level - 5;
            temp++;
            ZPlayerPrefs.SetInt("Level" + temp + "_MCS", 1);
        }
        //cena MCH
        else if (LevelAtual.instance.level == 8)
        {
            int temp = LevelAtual.instance.level - 7;
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

    //SalvaCapacetes mostrados nos btns das fases MCS, MCH, MCAH
    public void SalvaCapacetes(int nCapacetes)
    {
        if (win == true)
        {
            //print("Salcacapacetes");
            if (!ZPlayerPrefs.HasKey(LevelAtual.instance.cenaAtual + "capacete"))
            {
                ZPlayerPrefs.SetInt(LevelAtual.instance.cenaAtual + "capacete", nCapacetes);
               // print(LevelAtual.instance.cenaAtual + "capacete");
            }
            else if (ZPlayerPrefs.GetInt(LevelAtual.instance.cenaAtual + "capacete") < nCapacetes)
            {
                ZPlayerPrefs.SetInt(LevelAtual.instance.cenaAtual + "capacete", nCapacetes);
                //print("2");
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
        //UIManager.instance.AtualizaCristalGreen(cristalGreen);
    }

    //Salva Cristais  
    public bool liberaCristal;

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
    }

    //testando****
    public void ShowTextEnergy(int indexVet)
    {
        UIManager.instance.textEnergy.text = circleManager.circles[indexVet].currentlife.ToString();
    }

    //Habilita e desabilita txt mod sem energia
    public void HabTex_ModSemEnergia()
    {
        StartCoroutine(txtModSemEner());
    }

    //public void ChamaLose()
    //{
    //    if(num_tentativas == 0 && win == false)
    //    {
    //        lose = true;
    //    } 
    //}

    IEnumerator txtModSemEner()
    {
        UIManager.instance.txt_ModSemEnergy.text = "Módulo sem energia";
        UIManager.instance.txt_ModSemEnergy.enabled = true;
        yield return new WaitForSeconds(1);
        UIManager.instance.txt_ModSemEnergy.enabled = false;
    }
}


