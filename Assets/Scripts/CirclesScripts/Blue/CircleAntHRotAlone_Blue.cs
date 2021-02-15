using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAntHRotAlone_Blue : MonoBehaviour
{
    //tipo de shape
    public string tipo;
    //Index do vetor do obj
    public int indexVetCircles;
    //GameObject com Script Energy
    public Energy energyCH_Red;
    //GameObject com Script CircleManager
    public CircleManager circleManager;

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

    private void Start()
    {
        //Componentes de lazer
        circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();
        //Componentes Energy
        energyCH_Red = GetComponentInChildren<Energy>();
        //Inicializa a carga de enegia inicial do obj.
        energyCH_Red.AtualizaEnergy(indexVetCircles);
        //Inicializa o limite de rotação do obj.        
        limit = circleManager.circles[indexVetCircles].angCircles;
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
        if (tipo == "CAHRA_Blue" && travaClick == false)
        {
            travaClick = true;

            circleManager.NivelEnergy(indexVetCircles);
            energyCH_Red.AtualizaEnergy(indexVetCircles);

            for (int i = 0; i < circleManager.circles.Length; i++)
            {

                if (circleManager.circles[i].cor == "Blue")
                {
                    if (circleManager.circles[i].autoRot == autoRot)
                    {
                        if (circleManager.circles[indexVetCircles].currentlife > 0)
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

            energyCH_Red.AtualizaEnergy(indexVetCircles);
            StartCoroutine(DestroyCristal());
            Destroy(collision.gameObject);
        }
    }

    //Rotaciona este  obj quando seu obj controlador é clicado.
    void RotacionaObj()
    {//testando***trabalhando aqui        
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
            energyCH_Red.AtualizaEnergy(indexVetCircles);
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
