using UnityEngine;
using System.Collections;

public class CircleH_Red : MonoBehaviour
{
    //tipo de shape
    public string tipo;
    //Index do vetor do obj
    public int indexVetCircles, indexVetCircle;
    //GameObject com Script Energy
    public Energy energyCH_Red;
    //GameObject com Script CircleManager
    public CircleManager circleManager;

    //comportamento: quando o valor desta variável é IGUAL ao valor de uma variável... 
    //shapeCircles[i].atRot[x], significa que este obj NÃO rotaciona ao ser clicado.
    public int autoRot;

    //teste rotações**
    private float vel;
    private float limit;
    //Teste trava click***
    public bool travaClick;


    private void Start()
    {
        energyCH_Red.AtualizaEnergy(indexVetCircles, indexVetCircle);
        //teste**
        vel = 70;
        limit = circleManager.circles[indexVetCircles].circle[indexVetCircle].angCircles;
    }

    private void Update()
    {
        //Atualiza Energy
        if (circleManager.circles[indexVetCircles].circle[indexVetCircle].currentlife >= 0)
        {
            energyCH_Red.AtualizaEnergy(indexVetCircles, indexVetCircle);
        }

        //Rotaciona este  obj teste ***
        if (limit >= circleManager.circles[indexVetCircles].circle[indexVetCircle].angCircles)
        {
            limit -= vel * Time.deltaTime;
            circleManager.circles[indexVetCircles].circle[indexVetCircle].circleTransform.transform.rotation = Quaternion.Euler(0, 0, limit);
        }
    }

    private void OnMouseDown()
    {
        if (tipo == "CH_Red" && travaClick == false)
        {
            travaClick = true;

            circleManager.NivelEnergy(indexVetCircles, indexVetCircle);

            energyCH_Red.AtualizaEnergy(indexVetCircles, indexVetCircle);
           
            for (int i = 0; i < circleManager.circles.Length; i++)
            {
                for (int j = 0; j < circleManager.circles[i].circle.Length; j++)
                {
                    if (circleManager.circles[i].circle[j].cor == "Red")
                    {
                        if (circleManager.circles[i].circle[j].autoRot != autoRot)
                        {
                            if (circleManager.circles[indexVetCircles].circle[indexVetCircle].currentlife > 0)
                                circleManager.circles[i].circle[j].angCircles -= 45;                            
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

    //Coleta cristais de energia
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cristalEnergy"))
        {
            circleManager.circles[indexVetCircles].circle[indexVetCircle].currentlife++;

            for(int i = 0; i < circleManager.circles.Length; i++)
            {
                for(int j = 0; j < circleManager.circles[i].circle.Length; j++)
                {
                    //Carrega seu obj central contralador
                    if(circleManager.circles[i].circle[j].tipo == "CCS_Gray")
                    {
                        circleManager.circles[i].circle[j].currentlife++;
                    }
                }
            }
            energyCH_Red.AtualizaEnergy(indexVetCircles, indexVetCircle);
            StartCoroutine(DestroyCristal());
            Destroy(collision.gameObject);
        }
    }

    IEnumerator DestroyCristal()
    {
        yield return new WaitForSeconds(1f);
    }

    IEnumerator DestravaClick()
    {
        yield return new WaitForSeconds(1f);
        travaClick = false;
    }
}
