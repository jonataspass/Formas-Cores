using System.Collections;
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

    //testando****
    public int extraLife;
    public int dificuldadeLevel;

    public int descontraExtralife;

    private void Start()
    {
        IniCirclesAng();
        MaxPontos();
        //TotalEnergy();
    }

    //Nível de energia -> controla a quatidade de clicks por objs
    //Desativar
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
        int currentLifeTemp = extraLife + (num_tentativas_Start - num_tentativas_Ideal);
        int maxPontoTemp = 0;
        int contCircle = 0;

        for (int i = 0; i < circles.Length; i++)
        {
            currentLifeTemp += circles[i].currentlife;
            contCircle++;
        }
        
        maxPontoTemp = (((currentLifeTemp - totalClicks) * 100) + (contCircle * 100)) * dificuldadeLevel;
        ScoreManager.instance.maxScore = maxPontoTemp / 100;
    }

    //Define pontuação final do level corrente
    public void ScoreFinal()
    {
        int currentLifeTemp = (num_tentativas_Start - num_tentativas_Ideal);
        int contCircleTemp = 0;
        int maxPontoTemp = 0;
        int currentclicksTotal = 0;

        for (int i = 0; i < circles.Length; i++)
        {
            //for()
            currentLifeTemp += circles[i].currentlife;
            contCircleTemp++;
        }

        for (int i = 0; i < circles.Length; i++)
        {
            for (int j = 0; j < circles[i].currentClicks; j++)
            {
                currentclicksTotal++;
            }
        }

        maxPontoTemp = (((currentLifeTemp * 100) + (contCircleTemp * 100)) - descontraExtralife)  * dificuldadeLevel;
        ScoreManager.instance.ptsMarcados_Total += maxPontoTemp;
    }

    //void TotalEnergy()
    //{
    //    for (int i = 0; i < circles.Length; i++)
    //    {
    //        currentLifeTotal += circles[i].currentlife;
    //    }
    //}
}



