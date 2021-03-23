using UnityEngine;
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

    //Tipo de shape
    public string tipo;
    //Index do vetor do obj
    public int indexVetCircles;
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
    }

    private void Update()
    {
        AtualizaEnergy();
    }

    private void OnMouseDown()
    {
        if (tipo == "CCAH_Gray" && travaClick == false)
        {
            travaClick = true;

            circleManager.NivelEnergy(indexVetCircles);

            for (int i = 0; i < circleManager.circles.Length; i++)
            {
                //Currentlife -> Se ainda tiver energia rotaciona objs
                if (circleManager.circles[indexVetCircles].currentlife > 0)
                {
                    circleManager.circles[i].angCircles += 45;
                }
            }

            if (circleManager.circles[indexVetCircles].currentlife > 0)
            {
                circleManager.circles[indexVetCircles].currentlife--;
            }

            StartCoroutine(DestravaClick());
        }
    }

    //Atualização da energia deste obj
    void AtualizaEnergy()
    {
        if (circleManager.circles[indexVetCircles].currentlife >= 0)
        {
            
        }
    }

    //velocidade de clicks
    IEnumerator DestravaClick()
    {
        yield return new WaitForSeconds(0.5f);
        travaClick = false;
    }
}
