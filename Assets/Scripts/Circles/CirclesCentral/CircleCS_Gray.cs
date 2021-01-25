using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CIRCLE CENTRAL SIMPLES GRAY
//ROTACIONA TODAS AS CIRCLES NO SENTIDO ESPECÍFICO INDICADO EM CADA UMA
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

    //Teste trava click***
    public bool travaClick;

    private void Start()
    {
        //Inicializa a energia        
        energyCS_Gray.AtualizaEnergy(indexVetCircles, indexVetCircle);
    }

    private void Update()
    {
        if (circleManager.circles[indexVetCircles].circle[indexVetCircle].currentlife >= 0)
        {
            energyCS_Gray.AtualizaEnergy(indexVetCircles, indexVetCircle);
        }
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
                    //Se ainda tiver energia rotaciona objs
                    if (circleManager.circles[indexVetCircles].circle[indexVetCircle].currentlife > 0)
                    {
                        if (circleManager.circles[i].circle[j].tipo == "CH_Red" 
                                  && circleManager.circles[i].circle[j].sentRot == 1)
                        {
                            if(circleManager.circles[i].circle[j].tipo != "CS_Red")
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

    IEnumerator DestravaClick()
    {
        yield return new WaitForSeconds(1f);
        travaClick = false;
    }
}
