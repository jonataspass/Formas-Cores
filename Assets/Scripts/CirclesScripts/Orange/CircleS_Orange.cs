using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleS_Orange : MonoBehaviour
{
    //tipo de shape
    public string tipo;
    //Index do vetor do obj
    public int indexVetCircles;
    //GameObject com Script CircleManager
    public CircleManager circleManager;

    //Comportamento: quando o valor desta variável é IGUAL ao valor de uma variável... 
    //shapeCircles[i].atRot[x], significa que este obj NÃO rotaciona ao ser clicado.
    public int autoRot;

    //Velocidade de rotação do obj.
    [SerializeField]
    private float vel = 0;
    //Variável sentinela -> controla a rotação do obj dentro do método Update().
    public float limit;

    //audios
    public AudioClip[] clips;
    public AudioSource effectsObjs;

    //Dicas
    public Dicas objD;

    private void Start()
    {
        //Componentes de lazer
        circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();
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
        //Rotaciona este  obj quando seu obj controlador é clicado.
        RotacionaObj();
    }

    //Coleta cristais de energia
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("cristalEnergy"))
    //    {
    //        circleManager.circles[indexVetCircles].currentlife++;

    //        for (int i = 0; i < circleManager.circles.Length; i++)
    //        {
    //            //Carrega seu obj central contralador
    //            if (circleManager.circles[i].tipo == "CCS_Gray")
    //            {
    //                circleManager.circles[i].currentlife++;
    //            }
    //        }

    //        StartCoroutine(DestroyCristal());
    //        Destroy(collision.gameObject);
    //    }
    //}

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

    IEnumerator DestroyCristal()
    {
        yield return new WaitForSeconds(1f);
    }
}
