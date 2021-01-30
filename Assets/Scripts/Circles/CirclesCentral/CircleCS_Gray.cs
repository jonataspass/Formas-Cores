using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CIRCLE CENTRAL SIMPLES GRAY -> ROTACIONA TODAS AS CIRCLES, NO SENTIDO ESPECÍFICO INDICADO EM CADA 
//CIRCLE, QUE ESTIVEREM SENDO CONTROLADAS POR "CCS_Gray".
public class CircleCS_Gray : MonoBehaviour
{
    //Tipo de shape
    public string tipo;
    //Index do vetor do obj
    public int indexVetCircles, indexVetCircle;
    //GameObject com Script Energy
    public Energy energyCS_Gray;
    //GameObject com Script CircleManager
    public CircleManager circleManager;

    //trava -> controla a velocidade de clicks do usuário
    public bool travaClick;    

    private void Start()
    {
        //Componentes de lazer
        circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();        
        //Componentes Energy
        energyCS_Gray = GameObject.FindWithTag("energy").GetComponentInChildren<Energy>();
        //Inicializa a energia        
        energyCS_Gray.AtualizaEnergy(indexVetCircles, indexVetCircle);        
        
    }

    private void Update()
    {
        AtualizaEnergy();
    }

    private void OnMouseDown()
    {
        if (tipo == "CCS_Gray" && travaClick == false)
        {
            travaClick = true;

            circleManager.NivelEnergy(indexVetCircles, indexVetCircle);

            energyCS_Gray.AtualizaEnergy(indexVetCircles, indexVetCircle);

            for (int i = 0; i < circleManager.circles.Length; i++)
            {
                for (int j = 0; j < circleManager.circles[i].circle.Length; j++)
                {
                    //Currentlife -> Se ainda tiver energia rotaciona objs
                    if (circleManager.circles[indexVetCircles].circle[indexVetCircle].currentlife > 0)
                    {
                        //Tipos de objs que são rotacionados por this obj
                        if (circleManager.circles[i].circle[j].tipo == "CH_Red"
                                  && circleManager.circles[i].circle[j].sentRot == 1)
                        {
                            if (circleManager.circles[i].circle[j].tipo != "CS_Red")
                            {
                                circleManager.circles[i].circle[j].angCircles -= 45;
                            }
                        }
                        else
                        {
                            if (circleManager.circles[i].circle[j].tipo != "CS_Red")
                            {
                                circleManager.circles[i].circle[j].angCircles += 45;
                            }
                        }
                    }
                }
            }

            if (circleManager.circles[indexVetCircles].circle[indexVetCircle].currentlife > 0)
            {
                circleManager.circles[indexVetCircles].circle[indexVetCircle].currentlife--;
            }

            StartCoroutine(DestravaClick());
        }
    } 
    
    //Atuallização da energia deste obj
    void AtualizaEnergy()
    {
        if (circleManager.circles[indexVetCircles].circle[indexVetCircle].currentlife >= 0)
        {
            energyCS_Gray.AtualizaEnergy(indexVetCircles, indexVetCircle);
        }
    }

    //velocidade de clicks
    IEnumerator DestravaClick()
    {
        yield return new WaitForSeconds(0.5f);
        travaClick = false;
    }
}




