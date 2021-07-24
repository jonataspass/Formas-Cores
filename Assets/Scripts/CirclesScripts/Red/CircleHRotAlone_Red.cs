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

        //Inicializa o limite de rotação do obj.        
        limit = circleManager.circles[indexVetCircles].angCircles;

        //testando****//passar esta variável para o gameManager//verificar utilidade
        //circleManager.circles[indexVetCircles].totalCurrentEnergy_H = Total_EnergyH();
        //circleManager.circles[indexVetCircles].totalCurrentEnergy_AH = Total_EnergyAH();
    }

    private void Update()
    {
        //Atualiza Energy
        AtualizaEnergy();
        
        //Rotaciona este  obj quando seu obj controlador é clicado.
        RotacionaObj();

        ////testando****
        //circleManager.circles[indexVetCircles].totalCurrentEnergy_H = Total_EnergyH();
        //circleManager.circles[indexVetCircles].totalCurrentEnergy_AH = Total_EnergyAH();

        if (GAMEMANAGER.instance.num_tentativas == 0)
        {
            travaClick = true;
        }
    }

    private void OnMouseDown()
    {
        if (tipo == "CHRA_Red" && travaClick == false
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

    //Coleta cristais de energia
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cristalEnergy"))
        {
            circleManager.circles[indexVetCircles].currentlife++;

            for (int i = 0; i < circleManager.circles.Length; i++)
            {

                //Carrega seu obj central contralador
                if (circleManager.circles[i].tipo == "CCS_Gray")
                {
                    circleManager.circles[i].currentlife++;
                }

            }

            StartCoroutine(DestroyCristal());
            Destroy(collision.gameObject);
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
        travaClick = false;
    }

    //testando*** metodo que conta o total de energia de todos os objs 04/03
    //para verificar se o jogador perdeu
    //chamar este método na inicialização
    //public int Total_EnergyH()
    //{
    //    int totalEnergyH_Temp = 0;

    //    //Total "energyH" CircleH_Red -> total de movimentos no sentido horário 
    //    //recebe energy de CCS_Gray, CH_Red menos dele próprio.
    //    for (int i = 0; i < circleManager.circles.Length; i++)
    //    {
    //        //energy "H"
    //        if (circleManager.circles[i].tipo == "CH_Red")
    //        {
    //            totalEnergyH_Temp += circleManager.circles[i].currentlife;
    //        }
    //        if (circleManager.circles[i].tipo == "CHRA_Red" && circleManager.circles[i].autoRot == autoRot)
    //        {
    //            totalEnergyH_Temp += circleManager.circles[i].currentlife;
    //        }
    //        if (circleManager.circles[i].tipo == "CCS_Gray")
    //        {
    //            totalEnergyH_Temp += circleManager.circles[i].currentlife;
    //        }
    //    }

    //    return totalEnergyH_Temp;
    //}

    ////testando*** metodo que conta o total de energia de todos os objs 04/03
    ////para verificar se o jogador perdeu
    ////chamar este método na inicialização
    //public int Total_EnergyAH()
    //{
    //    int totalEnergyAH_Temp = 0;

    //    //Total "energyAH" CircleAH_Red -> total de movimentos no sentido anti-horário 
    //    //recebe energy de CAH_Red.
    //    for (int i = 0; i < circleManager.circles.Length; i++)
    //    {
    //        //energy "AH"
    //        if (circleManager.circles[i].tipo == "CAH_Red")
    //        {
    //            totalEnergyAH_Temp += circleManager.circles[i].currentlife;
    //        }
    //    }

    //    return totalEnergyAH_Temp;
    //}
}
