﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleManager : MonoBehaviour
{
    //Atributos das circles
    public CirclesAtributos[] circles;
    //Nível máximo de energia acumulável
    public int maxEnergy;

    //Variávei de MaxScore
    public int totalClicks;
    public int numCircCent;

    public int num_tentativas_Start;
    public int num_tentativas_Ideal;

    public int currentLifeTotal;

    public int extraLife;
    public int dificuldadeLevel;

    public int descontraExtralife;

    public int totalMoedasLevel;

    //número de tentativas extras necessárias para cada level
    public int num_extraTry;

    private void Start()
    {
        IniCirclesAng();
        MaxPontos();
        GuardaEnergy();
    }

    private void Update()
    {
        InitExtralife();

        if (GAMEMANAGER.instance.lose == true)
        {
            for (int i = 0; i < circles.Length; i++)
            {
                circles[i].trava_Click = true;
            }
        }
        else if(UnityAds.instance.rewardedAtivo == true)
        {
            for (int i = 0; i < circles.Length; i++)
            {
                circles[i].trava_Click = true;
            }
        }
    }

    //método que guarda energia de inicialização para ser reutilizada 
    //nas tentativas extras
    void GuardaEnergy()
    {
        for (int i = 0; i < circles.Length; i++)
        {
            circles[i].extra_life = circles[i].currentlife;
        }
    }

    //inicializa Energy de todos os módulos quando utilizado tentativas extras
    void InitExtralife()
    {
        //new; add aos outros scripts
        if (GAMEMANAGER.instance.num_tentativas == 0)
        {
            for (int i = 0; i < circles.Length; i++)
            {
                circles[i].trava_Click = true;
            }

            //desativa os btns da cena
            UIManager.instance.btnPainel_Guia.interactable = false;
            UIManager.instance.btnPainel_Dicas.interactable = false;
            UIManager.instance.btnSair.interactable = false;
            UIManager.instance.btn_restart.interactable = false;

            GAMEMANAGER.instance.painelExtraAtivado = true;
        }
        else if (GAMEMANAGER.instance.num_tentativas > 0 && GAMEMANAGER.instance.getExtra == true
            && (GAMEMANAGER.instance.win == false && GAMEMANAGER.instance.lose == false))
        {
            for (int i = 0; i < circles.Length; i++)
            {
                circles[i].trava_Click = false;
            }

            GAMEMANAGER.instance.getExtra = false;

            for (int i = 0; i < circles.Length; i++)
            {
                circles[i].currentlife = 7;
            }

            //ativa os btns da cena   21/12/2021         
            //UIManager.instance.btnPainel_Guia.enabled = true;
            //UIManager.instance.btnPainel_Dicas.enabled = true;
            //UIManager.instance.btnSair.interactable = true;
            //UIManager.instance.btn_restart.interactable = true;


            GAMEMANAGER.instance.painelExtraAtivado = false;
        }
    }

    //Inicializa os ângulos das Circles
    void IniCirclesAng()
    {
        for (int i = 0; i < circles.Length; i++)
        {

            if (circles[i].ativa == true)
            {
                circles[i].angCircles += circles[i].StartAngCircles;

                for (int a = 0; a < circles[i].clicksR.Length; a++)
                {
                    circles[i].angCircles += circles[i].clicksR[a].clicks * 45;
                }
            }
        }
    }

    //Defini a pontuação que completa 100% do objetivo
    void MaxPontos()
    {
        int currentLifeTemp = extraLife + (num_tentativas_Start - num_tentativas_Ideal);
        int maxPontoTemp = 0;
        int contCircle = 0;

        for (int i = 0; i < circles.Length; i++)
        {
            currentLifeTemp += circles[i].currentlife;
            contCircle++;
        }

        maxPontoTemp = (((currentLifeTemp - num_tentativas_Ideal) * 100) + (contCircle * 100) + (totalMoedasLevel * 300)) * dificuldadeLevel;
        ScoreManager.instance.maxScore = maxPontoTemp / 100;
        //print(totalMoedasLevel);
    }

    //Define pontuação final do level corrente
    public void ScoreFinal()
    {
        int currentLifeTemp = (num_tentativas_Start - num_tentativas_Ideal);
        int contCircleTemp = 0;
        int maxPontoTemp = 0;
        int moedasDontGet = (totalMoedasLevel - GAMEMANAGER.instance.moedaPegas);

        for (int i = 0; i < circles.Length; i++)
        {
            currentLifeTemp += circles[i].currentlife;
            contCircleTemp++;
        }

        maxPontoTemp = ((((currentLifeTemp * 100) + (contCircleTemp * 100))
            - (((GAMEMANAGER.instance.numTentativasExtras * 300) + descontraExtralife)))
            + (GAMEMANAGER.instance.moedaPegas * 300)) * dificuldadeLevel;

        if (maxPontoTemp >= 1000)
        {
            ScoreManager.instance.ptsMarcados_Total += maxPontoTemp;
        }
        else

            ScoreManager.instance.ptsMarcados_Total += 1000;
    }
}



