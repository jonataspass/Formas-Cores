using System.Collections;
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
    //GameObject com Script CircleManager
    public CircleManager circleManager;
    //Quantidade de canhoes
    public int numCanhoes;
    //testando****
    public CircleEnergy circleEnergyCS_Gray;

    //trava -> controla a velocidade de clicks do usuário
    public bool travaClick;

    //audios
    public AudioClip[] clips;
    public AudioSource effectsObjs;

    //testando****
    public Dicas objD;

    private void Start()
    {
        //Componentes de lazer
        circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();
        //Componentes Energy//testando****
        circleEnergyCS_Gray = GetComponentInChildren<CircleEnergy>();
        //audio
        effectsObjs = GetComponent<AudioSource>();

        //testando****
        objD = GameObject.FindWithTag("dica").GetComponent<Dicas>();
    }

    private void Update()
    {
        AtualizaEnergy();
    }

    int xClicks;//teatando****
    private void OnMouseDown()
    {                                                   
        if (tipo == "CCS_Gray" && travaClick == false 
            && circleManager.circles[indexVetCircles].ativa == true
            && GAMEMANAGER.instance.startGame == true)
        {
            //Controles do objDica//testando****
            if (objD.objDica[indexVetCircles].dicaAtiva == true && circleManager.circles[indexVetCircles].currentlife > 0)
            {
                objD.objDica[indexVetCircles].dicaClick--;

                if(objD.objDica[indexVetCircles].dicaClick == 0)
                {
                    objD.Desat_Dica(indexVetCircles);
                }                
            }
            //testando****
            //Audio
            if (circleManager.circles[indexVetCircles].currentlife > 0)
            {
                effectsObjs.clip = clips[0];
                effectsObjs.Play();
                circleManager.circles[indexVetCircles].currentClicks++;
            } 
            
            travaClick = true;

            AtualizaEnergy();

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




