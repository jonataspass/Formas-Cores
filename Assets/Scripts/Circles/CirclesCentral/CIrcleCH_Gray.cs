using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIrcleCH_Gray : MonoBehaviour
{
    public static CIrcleCH_Gray instance;

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
    //GameObject com Script Energy
    public Energy energyCS_Gray;
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
        energyCS_Gray = GetComponentInChildren<Energy>();
        //Inicializa a energia        
        energyCS_Gray.AtualizaEnergy(indexVetCircles);
    }

    private void Update()
    {
        AtualizaEnergy();
    }

    private void OnMouseDown()
    {
        if (tipo == "CCH_Gray" && travaClick == false)
        {
            travaClick = true;

            circleManager.NivelEnergy(indexVetCircles);

            energyCS_Gray.AtualizaEnergy(indexVetCircles);

            for (int i = 0; i < circleManager.circles.Length; i++)
            {
                //Currentlife -> Se ainda tiver energia rotaciona objs
                if (circleManager.circles[indexVetCircles].currentlife > 0)
                {
                    circleManager.circles[i].angCircles -= 45;
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
            energyCS_Gray.AtualizaEnergy(indexVetCircles);
        }
    }

    //velocidade de clicks
    IEnumerator DestravaClick()
    {
        yield return new WaitForSeconds(0.5f);
        travaClick = false;
    }
}
