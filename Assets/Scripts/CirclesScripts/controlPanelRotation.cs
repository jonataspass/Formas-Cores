using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlPanelRotation : MonoBehaviour
{
    //controle da sprite dos ângulos do painel de orientação de rotação
    private SpriteRenderer angPanel;

    //cor do ângulo de rotação
    public Color colorAngPanel;
    public Color tempAngPanel;

    //posição do click para chegar ao ang 0°
    public int posAng_H;
    public int posAng_AH;
    public int posAng_H_Temp;
    public int posAng_AH_Temp;

    public CircleManager circleManager;

    //index da circle atrelada ao painel de angulos
    public int indexCircleVet;

    private void Start()
    {
        GAMEMANAGER.instance.liberalose = false;
        GAMEMANAGER.instance.travaPainelExtras = true;
        angPanel = GetComponentInChildren<SpriteRenderer>();
        circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();

        //desativa coliders dos angulos
        DesativaColl(GetComponent<Collider2D>());
        StartCoroutine(AtivaColl(GetComponent<Collider2D>()));

        //testando*******
        executouChek = false;
    }

    //Não permite que a couroutine AguardaCheckWin seja executada mais de uma vez
    public bool executouChek;

    private void Update()
    {
        //CHAMADA DO YOULOSE
        if (GAMEMANAGER.instance.num_tentativas == 0 && executouChek== false)
        {
            executouChek = true;
            StartCoroutine(AguardaCheckWin());            
        }
        else if(GAMEMANAGER.instance.num_tentativas > 0)
        {
            executouChek = false;
        }
    }

    bool travaExtra;//testando
    //Aguarda a condição da variável win
    IEnumerator AguardaCheckWin()
    {
        yield return new WaitForSeconds(1);
        
        if(GAMEMANAGER.instance.win == false && GAMEMANAGER.instance.qtd_moedaSalvas < GAMEMANAGER.instance.extraTry * 100)
        {
            GAMEMANAGER.instance.VerificaLose();
        }
        else if (GAMEMANAGER.instance.win == false && GAMEMANAGER.instance.qtd_moedaSalvas >= GAMEMANAGER.instance.extraTry * 100
                 && travaExtra == false)
        {
            GAMEMANAGER.instance.OfereceTentativasExtras();
        }
        else if(GAMEMANAGER.instance.win == false && GAMEMANAGER.instance.qtd_moedaSalvas >= GAMEMANAGER.instance.extraTry * 100
                 && travaExtra == true)
        {
            GAMEMANAGER.instance.VerificaLose();
        }

        //testando
        if(GAMEMANAGER.instance.numTentativasExtras * 100 > (ScoreManager.instance.maxScore * 100) / 10)
        {
            travaExtra = true;
        }

        print((ScoreManager.instance.maxScore * 100) / 10);
        print(GAMEMANAGER.instance.numTentativasExtras * 100);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("collReceptLazer"))
        {
            tempAngPanel = angPanel.color;
            angPanel.color = new Color(colorAngPanel.r, colorAngPanel.g, colorAngPanel.b, colorAngPanel.a + 135);

            //posições dos angulos ativos
            posAng_H_Temp = posAng_H;
            posAng_AH_Temp = posAng_AH;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("collReceptLazer"))
        {
            angPanel.color = tempAngPanel;
            posAng_H_Temp = 0;
            posAng_AH_Temp = 0;
        }
    }

    //desativa o collidar para que não seja chamado o método lose
    void DesativaColl(Collider2D coll)
    {
        coll.enabled = false;
    }

    //Ativa collider
    IEnumerator AtivaColl(Collider2D coll)
    {
        yield return new WaitForSeconds(0.1f);
        coll.enabled = true;
    }    
}
