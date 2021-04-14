using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GAMEMANAGER : MonoBehaviour
{
    public static GAMEMANAGER instance;

    public int ativosTemp = 0;

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

    //variável que armazena quantidade de cristais green
    public int cristalGreen;//testando****

    //capacetes conquistados btns fases MCS, MCH, MCAH
    public int numCapacetes;

    //capacetes conquistados dos btns da faseMestra
    public int numCapsB, numCapsP, numCapsO;

    private void Update()
    {
        //print("TotalUpdate " + ZPlayerPrefs.GetInt(LevelAtual.instance.cenaAtual + "cristaisGreen_Total"));
    }

    //Carrega cena
    void Carrega(Scene cena, LoadSceneMode modo)
    {
        //win = false;

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
        //pontuação
        ScoreManager.instance.ptsMarcados_Total = 0;
        ScoreManager.instance.conta_ptsMarcados = 0;
        //testando****08/04/2021
        if (ZPlayerPrefs.HasKey("cristaisGreen_Total"))
        {
            print("Inicializando cristal");
            cristalGreen = ZPlayerPrefs.GetInt("cristaisGreen_Total");
        }

        //canhões
        ativosTemp = 0;

        //ZPlayerPrefs.DeleteAll();
    }

    public void YouWin(int canhoes, int ativos)
    {
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
            UIManager.instance.txt_Painel_WL.text = "You Lose!!!";
            UIManager.instance.txt_Painel_info_WL.text = "não haviam mais jogadas possíveis";
            UIManager.instance.UI_Win();
            UIManager.instance.habilitabBtnsCena = false;
            UIManager.instance.habilitaBtnRestart = false;
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
        if (LevelAtual.instance.level >= 6 && LevelAtual.instance.level <= 7)
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

    public void ColetaCristalGreen(int crsG)
    {
        cristalGreen += crsG;
        print("Coleta " + cristalGreen);
        SalvaCristais(cristalGreen);
    }

    public void DecrementaCristal(int crsG)
    {
        liberaCristal = true;
        cristalGreen -= crsG;
        print("Decrementa " + cristalGreen);
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
                print("Total " + ZPlayerPrefs.GetInt("cristaisGreen_Total"));
            }
            else
            {
                ZPlayerPrefs.SetInt("cristaisGreen_Total", cristais);
                print("Total " + ZPlayerPrefs.GetInt("cristaisGreen_Total"));
                //liberaCristal = false;
            }
        }
    }

    //testando****
    public void ShowTextEnergy(int indexVet)
    {
        UIManager.instance.textEnergy.text = circleManager.circles[indexVet].currentlife.ToString();
    }
}


