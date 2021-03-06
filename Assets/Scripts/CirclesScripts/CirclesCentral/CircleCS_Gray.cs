﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CIRCLE CENTRAL SIMPLES GRAY -> ROTACIONA TODAS AS CIRCLES, NO SENTIDO ESPECÍFICO INDICADO EM CADA 
//CIRCLE, QUE ESTIVEREM SENDO CONTROLADAS POR "CCS_Gray".
public class CircleCS_Gray : MonoBehaviour
{
    public static CircleCS_Gray instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //Tipo de shape
    public string tipo;
    //Index do vetor do obj
    public int indexVetCircles;
    //GameObject com Script Energy
    public Energy energyCS_Gray;
    //GameObject com Script CircleManager
    public CircleManager circleManager;
    //Quantidade de canhoes
    public int numCanhoes;

    //trava -> controla a velocidade de clicks do usuário
    public bool travaClick;

    private void Start()
    {
        //Componentes de lazer
        circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();
        //Componentes Energy
        energyCS_Gray = GetComponentInChildren<Energy>();
        //Inicializa a energia        
        energyCS_Gray.AtualizaEnergy(indexVetCircles);
    }

    private void Update()
    {
        AtualizaEnergy();
    }

    private void OnMouseDown()
    {                                                   
        if (tipo == "CCS_Gray" && travaClick == false && circleManager.circles[indexVetCircles].ativa == true)
        {
            travaClick = true;

            circleManager.NivelEnergy(indexVetCircles);

            energyCS_Gray.AtualizaEnergy(indexVetCircles);

            for (int i = 0; i < circleManager.circles.Length; i++)
            {
                //Currentlife -> Se ainda tiver energia rotaciona objs 
                if (circleManager.circles[indexVetCircles].currentlife > 0 && circleManager.circles[i].tipo != "CS")
                {
                    //Tipos de objs que são rotacionados por this obj                    
                    if (circleManager.circles[i].sentRot == 1)
                    {
                        circleManager.circles[i].angCircles -= 45;
                    }
                    else
                    {
                        circleManager.circles[i].angCircles += 45;
                    }
                }

            }

            if (circleManager.circles[indexVetCircles].currentlife > 0)
            {
                circleManager.circles[indexVetCircles].currentlife--;
            }

            StartCoroutine(DestravaClick());
        }
    }
    //USAR PARA EXIBIR INFORMAÇÕES SOBRE OS OBJS: EXEMPLO: NÍVEL ENERGIA DO MÒDULO
    private void OnMouseOver()
    {
        //print("OLÀÀÀ");
    }

    private void OnMouseExit()
    {
        //print("Saiu!!!");
    }

    //Atualização da energia deste obj
    void AtualizaEnergy()
    {
        if (circleManager.circles[indexVetCircles].currentlife >= 0)
        {
            energyCS_Gray.AtualizaEnergy(indexVetCircles);
        }
    }

    //velocidade de clicks
    IEnumerator DestravaClick()
    {
        yield return new WaitForSeconds(0.5f);
        travaClick = false;
    }
}




