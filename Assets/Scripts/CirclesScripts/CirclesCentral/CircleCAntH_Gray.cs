﻿using UnityEngine;
using System.Collections;

//script adicionado ao obj CirclesAntH_Gray.
//rotaciona todos os shapes tipo Circle com a parte externa em cinza no sentido anti-horário.
public class CircleCAntH_Gray : MonoBehaviour
{
    public static CircleCAntH_Gray instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //Index do vetor do obj
    public int indexVetCircles;
    //Quantidade de canhoes
    public int numCanhoes;
    //Tipo de shape
    public string tipo;
    //trava -> controla a velocidade de clicks do usuário
    public bool travaClick;
    //GameObject com Script CircleManager
    public CircleManager circleManager;
    //Energia deste Obj
    public CircleEnergy circleEnergyCS_Gray;

    //audios
    public AudioClip[] clips;
    public AudioSource effectsObjs;

    //Dicas
    public Dicas objD;

    private void Start()
    {
        //Componentes de lazer
        circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();

        //Componentes Energy
        circleEnergyCS_Gray = GetComponentInChildren<CircleEnergy>();

        //audio
        effectsObjs = GetComponent<AudioSource>();

        //Recebe obj com script Dicas
        objD = GameObject.FindWithTag("dica").GetComponent<Dicas>();
    }

    private void Update()
    {
        AtualizaEnergy();
        //add a todos scrips das circles
        if (GAMEMANAGER.instance.num_tentativas == 0)
        {
            travaClick = true;
        }
    }

    private void OnMouseDown()
    {
        if (tipo == "CCAH_Gray" && travaClick == false
            && circleManager.circles[indexVetCircles].ativa == true
            && GAMEMANAGER.instance.startGame == true)
        {
            print("olá");
            //Aviso mod sem energia
            if (circleManager.circles[indexVetCircles].currentlife == 0)
                GAMEMANAGER.instance.HabTex_ModSemEnergia("Módulo sem energia");

            //Audio e contador de clicks
            if (circleManager.circles[indexVetCircles].currentlife > 0)
            {
                effectsObjs.clip = clips[0];
                effectsObjs.Play();
                circleManager.circles[indexVetCircles].currentClicks++;
                //decrementa tentativas            
                GAMEMANAGER.instance.num_tentativas--;
            }

            travaClick = true;

            for (int i = 0; i < circleManager.circles.Length; i++)
            {
                //Currentlife -> Se ainda tiver energia rotaciona objs
                if (circleManager.circles[indexVetCircles].currentlife > 0)
                {
                    circleManager.circles[i].angCircles += 45;
                }
            }

            //decrementa energy e total energy
            if (circleManager.circles[indexVetCircles].currentlife > 0)
            {
                circleManager.circles[indexVetCircles].currentlife--;
                //circleManager.currentLifeTotal--;
            }

            StartCoroutine(DestravaClick());
        }
    }

    //Atualização da energia deste obj
    void AtualizaEnergy()
    {
        if (circleManager.circles[indexVetCircles].currentlife >= 0)
        {
            circleEnergyCS_Gray.AtualizaCircleEnergy(indexVetCircles);
        }
    }

    //velocidade de clicks
    IEnumerator DestravaClick()
    {
        yield return new WaitForSeconds(0.5f);
        travaClick = false;
    }
}
