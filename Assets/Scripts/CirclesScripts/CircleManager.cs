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

    private void Start()
    {
        IniCirclesAng();
        MaxPontos();
    }
    //passar todos os updatees dos scripts instances para o update do Gamemanager; criar um metodo "UpdateCircleManager"...
    //e chamar este no update do gamemanager
    private void Update()
    { //testando****
        int x = Total_CurrentLife();

        if (x == 0)
        {
            GAMEMANAGER.instance.YouLose(CircleCS_Gray.instance.numCanhoes, GAMEMANAGER.instance.ativosTemp);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(LevelAtual.instance.level);
        }
    }

    //Nível de energia -> controla a quatidade de clicks por objs
    public void NivelEnergy(int indexCircles)
    {
        //O cáculo do enery_Y é uma regra de 3        
        Vector3 energy_Y = new Vector3(7, circles[indexCircles].currentlife
                                         * maxEnergy / circles[indexCircles].maxLife, 1);

        circles[indexCircles].currentlife = (int)energy_Y.y;
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
        int currentLifeTemp = 0;
        int clicksTemp = 0;
        int maxPontoTemp = 0;
        int contCircle = 0;

        for (int i = 0; i < circles.Length; i++)
        {
            currentLifeTemp += circles[i].currentlife;
            contCircle++;

            for (int j = 0; j < circles[i].clicksR.Length; j++)
            {
                clicksTemp += circles[i].clicksR[j].clicks;
            }
        }

        maxPontoTemp = ((currentLifeTemp - totalClicks) * 100) + ((contCircle - numCircCent) * 100);
        ScoreManager.instance.maxScore = maxPontoTemp / 100;
    }

    //Define pontuação final do level corrente
    public void ScoreFinal()
    {
        int currentLifeTemp = 0;
        int clicksTemp = 0;
        int maxPontoTemp = 0;

        for (int i = 0; i < circles.Length; i++)
        {
            currentLifeTemp += circles[i].currentlife;

            for (int j = 0; j < circles[i].clicksR.Length; j++)
            {
                clicksTemp += circles[i].clicksR[j].clicks;
            }
        }

        maxPontoTemp = currentLifeTemp * 100;
        ScoreManager.instance.ptsMarcados_Total += maxPontoTemp;
    }
    
    //testando*** metodo que conta o total de energia de todos os objs 04/03
    //para verificar se o jogador perdeu
    public int Total_CurrentLife()
    {
        int totalEnergy = 0;

        for(int i = 0; i < circles.Length; i++)
        {
            totalEnergy += circles[i].currentlife;
        }

        return totalEnergy;
    }
}



