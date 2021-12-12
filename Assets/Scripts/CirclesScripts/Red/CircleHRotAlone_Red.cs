using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleHRotAlone_Red : MonoBehaviour
{
    //tipo de shape
    public string tipo;
    //Index do vetor do obj
    public int indexVetCircles;
    //GameObject com Script CircleManager
    public CircleManager circleManager;
    //Script CircleEnergy
    public CircleEnergy circleEnergyCH_Red;

    //Comportamento: quando o valor desta variável for IGUAL ao valor de uma variável... 
    //shapeCircles[i].aut0Rot[x], significa que este obj APENAS rotaciona ele mesmo ao ser clicado.
    public int autoRot;

    //Velocidade de rotação do obj.
    [SerializeField]
    private float vel = 0;
    //Variável sentinela -> controla a rotação do obj dentro do método Update().
    private float limit;

    //audios
    public AudioClip[] clips;
    public AudioSource effectsObjs;

    //Dicas
    public Dicas objD;

    //collider moedaZ
    public Collider2D ativaCollMoeda;

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
        //Inicializa o limite de rotação do obj.        
        limit = circleManager.circles[indexVetCircles].angCircles;

        autoRot = indexVetCircles;

        StartCoroutine(LigaCollMoeda());
    }

    private void Update()
    {
        //Atualiza Energy
        AtualizaEnergy();        
        //Rotaciona este  obj quando seu obj controlador é clicado.
        RotacionaObj();
    }

    private void OnMouseDown()
    {
        if (tipo == "CHRA_Red" && circleManager.circles[indexVetCircles].trava_Click == false
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
                //incrementa numClickstotal
                circleManager.totalClicks += 1;
                //decrementa tentativas 
                GAMEMANAGER.instance.num_tentativas--;
            }

            circleManager.circles[indexVetCircles].trava_Click = true;

            for (int i = 0; i < circleManager.circles.Length; i++)
            {

                if (circleManager.circles[i].cor == "Red")
                {
                    if (circleManager.circles[i].autoRot == autoRot)
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
                //circleManager.currentLifeTotal--;
            }

            StartCoroutine(DestravaClick());
        }
    }    

    //Rotaciona este  obj quando seu obj controlador é clicado.
    void RotacionaObj()
    {       
        if (limit <= circleManager.circles[indexVetCircles].angCircles)
        {
            limit += vel * Time.deltaTime;
            
            //estabiliza o valor de limit
            if (limit > circleManager.circles[indexVetCircles].angCircles)
            {
                limit = circleManager.circles[indexVetCircles].angCircles;
            }

            circleManager.circles[indexVetCircles].circleTransform.transform.rotation = Quaternion.Euler(0, 0, limit);

        }
        else if (limit >= circleManager.circles[indexVetCircles].angCircles)
        {
            limit -= vel * Time.deltaTime;
            
            //estabiliza o valor de limit
            if (limit < circleManager.circles[indexVetCircles].angCircles)
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
        circleManager.circles[indexVetCircles].trava_Click = false;
    }

    IEnumerator LigaCollMoeda()
    {
        yield return new WaitForSeconds(3);
        ativaCollMoeda.enabled = true;
    }
}
