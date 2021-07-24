﻿using UnityEngine;
using System.Collections;

public class CircleH_Red : MonoBehaviour
{
    //tipo de shape
    public string tipo;
    //Index do vetor do obj
    public int indexVetCircles;
    //GameObject com Script CircleManager
    public CircleManager circleManager;
    //Script CircleEnergy
    public CircleEnergy circleEnergyCH_Red;

    //Comportamento: quando o valor desta variável é IGUAL ao valor de uma variável... 
    //shapeCircles[i].atRot[x], significa que este obj NÃO rotaciona ao ser clicado.
    private int autoRot;

    //Velocidade de rotação do obj.
    [SerializeField]
    private float vel = 0;
    //Variável sentinela -> controla a rotação do obj dentro do método Update().
    public float limit;
    //Controla velocidade de clicks do usuário
    public bool travaClick;

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
        circleEnergyCH_Red = GetComponentInChildren<CircleEnergy>();

        //audio
        effectsObjs = GetComponent<AudioSource>();

        //Recebe obj com script Dicas//verificar necessidade
        objD = GameObject.FindWithTag("dica").GetComponent<Dicas>();

        //Limite de rotação
        limit = circleManager.circles[indexVetCircles].angCircles;

        autoRot = indexVetCircles;
    }

    private void Update()
    {
        //Atualiza Energy
        AtualizaEnergy();
        
        //Rotaciona este  obj quando seu obj controlador é clicado.
        RotacionaObj();

        if (GAMEMANAGER.instance.num_tentativas == 0)
        {
            travaClick = true;
        }
    }

    private void OnMouseDown()
    {
        if (tipo == "CH_Red" && travaClick == false 
            && circleManager.circles[indexVetCircles].ativa == true
            && GAMEMANAGER.instance.startGame == true)
        {
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
                //new***//new****add aos outros circlesScrpts
                GAMEMANAGER.instance.num_tentativas--;
            }

            travaClick = true;

            for (int i = 0; i < circleManager.circles.Length; i++)
            {
                if (circleManager.circles[i].cor == "Red")
                {
                    if (circleManager.circles[i].autoRot != autoRot)
                    {
                        if (circleManager.circles[indexVetCircles].currentlife > 0)
                            circleManager.circles[i].angCircles -= 45;
                    }
                }
            }

            //Decrementa energy
            if (circleManager.circles[indexVetCircles].currentlife > 0)
            {
                circleManager.circles[indexVetCircles].currentlife--;
                //new****add aos outros circlesScrpts
                //circleManager.currentLifeTotal--;
            }

            StartCoroutine(DestravaClick());
        }
    }

    //Rotaciona este  obj quando seu obj controlador é clicado.
    void RotacionaObj()
    {
        if (limit >= circleManager.circles[indexVetCircles].angCircles)
        {
            limit -= vel * Time.deltaTime;
            //estabiliza o valor de limit
            if (limit < circleManager.circles[indexVetCircles].angCircles)
            {
                limit = circleManager.circles[indexVetCircles].angCircles;
            }

            circleManager.circles[indexVetCircles].circleTransform.transform.rotation = Quaternion.Euler(0, 0, limit);
        }
        else if (limit <= circleManager.circles[indexVetCircles].angCircles)
        {
            limit += vel * Time.deltaTime;
            //estabiliza o valor de limit
            if (limit > circleManager.circles[indexVetCircles].angCircles)
            {
                limit = circleManager.circles[indexVetCircles].angCircles;
            }

            circleManager.circles[indexVetCircles].circleTransform.transform.rotation = Quaternion.Euler(0, 0, limit);
        }
    }

    //Atualização da energia deste obj
    void AtualizaEnergy()
    {
        if (circleManager.circles[indexVetCircles].currentlife >= 0)
        {
            circleEnergyCH_Red.AtualizaCircleEnergy(indexVetCircles);
        }
    }

    IEnumerator DestroyCristal()
    {
        yield return new WaitForSeconds(1f);
    }

    IEnumerator DestravaClick()
    {
        yield return new WaitForSeconds(0.5f);
        travaClick = false;
    }
}
