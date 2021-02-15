using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleManager : MonoBehaviour
{
    //Atributos das circles
    public CirclesAtributos[] circles;

    private void Start()
    {
        IniCirclesAng();
        MaxPontos();
    }

    private void Update()
    {
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
                                         * 62 / circles[indexCircles].maxLife, 1);

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

    //Defini a pontuação que completa 100% do objetivo****Em testes iniciais
    void MaxPontos()
    {
        int currentLifeTemp = 0;
        int clicksTemp = 0;
        int maxPontoTemp = 0;

        for(int i = 0; i < circles.Length; i++)
        {
            currentLifeTemp += circles[i].currentlife;

            for (int j = 0; j < circles[i].clicksR.Length; j++)
            {
                clicksTemp += circles[i].clicksR[j].clicks;
            }            
        }

        maxPontoTemp = (currentLifeTemp - clicksTemp) * 100;

        ScoreManager.instance.score.text = maxPontoTemp.ToString();
    }
}



