﻿using System.Collections;
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
    //Variáveis de Win
    public bool win;

    private void Update()
    {
                
    }//não em uso

    //Carrega cena
    void Carrega(Scene cena, LoadSceneMode modo)
    {
        win = false;

        if (LevelAtual.instance.level >= 5)
        {
            circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();

            StartGame();
        }
    }

    void StartGame()
    {
        //pontuação
        ScoreManager.instance.ptsMarcados_Total = 0;
        ScoreManager.instance.conta_ptsMarcados = 0;

        //canhões
        ativosTemp = 0;
        
        //PlayerPrefs.DeleteAll();
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

            //testando****  
            UIManager.instance.txt_Painel_WL.text = "You Win!!!";
            UIManager.instance.UI_Win();
        }
    }

    //testando****
    public void YouLose(int canhoes, int ativados)
    {
        int totalTemp_CurrentLife = circleManager.Total_CurrentLife();

        if (ativados < canhoes)
        {
            //testando****  
            UIManager.instance.txt_Painel_WL.text = "You Lose!!!";
            UIManager.instance.UI_Win();
            print("LOSE");
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
        int temp = LevelAtual.instance.level - 4;
        temp++;
        PlayerPrefs.SetInt("Level" + temp + "_RedSC", 1);
    }
}


