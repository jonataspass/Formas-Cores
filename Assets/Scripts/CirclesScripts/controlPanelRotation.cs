using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        angPanel = GetComponentInChildren<SpriteRenderer>();
        circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();
        
        //desativa coliders dos angulos
        DesativaColl(GetComponent<Collider2D>());
        StartCoroutine(AtivaColl(GetComponent<Collider2D>()));
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

            verificaLose(posAng_H_Temp, posAng_AH_Temp);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("collReceptLazer"))
        {
            angPanel.color = tempAngPanel;
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

    //Verifica possibilidade de jogadas
    void verificaLose(int pos_H, int pos_AH)
    {
        if (pos_H > circleManager.circles[indexCircleVet].totalCurrentEnergy_H
            && pos_AH > circleManager.circles[indexCircleVet].totalCurrentEnergy_AH)
        {            
            GAMEMANAGER.instance.YouLose(CircleCS_Gray.instance.numCanhoes, GAMEMANAGER.instance.ativosTemp);
        }
    }
}
