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

    //Index do vetor do obj
    public int indexVetCircles;
    //Quantidade de canhoes
    public int numCanhoes;
    //Tipo de shape
    public string tipo;
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
        //Atualiza Energy
        AtualizaEnergy();        
    }
    
    private void OnMouseDown()
    {                                                   
        if (tipo == "CCS_Gray" && circleManager.circles[indexVetCircles].trava_Click == false
            && circleManager.circles[indexVetCircles].ativa == true
            && GAMEMANAGER.instance.startGame == true)
        {
            // se texto compre uma dica ativado => desative
            if (UIManager.instance.txt_Informativo.enabled == true)
            {
                UIManager.instance.txt_Informativo.enabled = false;
            }

            //Aviso mod sem energia
            if (circleManager.circles[indexVetCircles].currentlife == 0)
                GAMEMANAGER.instance.HabTex_Informativo("Módulo sem energia");
            
            //Audio e contador de clicks
            if (circleManager.circles[indexVetCircles].currentlife > 0)
            {
                effectsObjs.clip = clips[0];
                effectsObjs.Play();
                circleManager.circles[indexVetCircles].currentClicks++;
                //decrementa tentativas            
                GAMEMANAGER.instance.num_tentativas--;
            }

            //travaClick = true;
            circleManager.circles[indexVetCircles].trava_Click = true;

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

            //decrementa energy e total energy
            if (circleManager.circles[indexVetCircles].currentlife > 0)
            {
                circleManager.circles[indexVetCircles].currentlife--;
            }

            StartCoroutine(DestravaClick());
        }
    }

    //Atualização da energia deste obj "CÍRCULO DE LUZ"
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

        circleManager.circles[indexVetCircles].trava_Click = false;
    }
}




