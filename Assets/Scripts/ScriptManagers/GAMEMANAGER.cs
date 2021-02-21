using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Renomear Esta classe de CIRCLESMANAGER
public class GAMEMANAGER : MonoBehaviour
{
    public static GAMEMANAGER instance;

    public int ativosTemp = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //GameObject com Script CircleManager trabalhando aqui***
    public CircleManager circleManager;
    //Variáveis de Win
    private bool win;

    private void Start()
    {
        //trabalhando aqui***
        circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();
        //***trabahando aqui
        win = false;
    }

    //trabalhando aqui****
    //mudar nome para... 
    public void YouWin(int canhoes, int ativos)
    {
        if (ativos == 1)
        {
            ativosTemp++;
        }
        else if (ativos == 0)
        {
            if (ativosTemp == 0)
            {
                ativosTemp = 0;
            }
            else if (ativosTemp > 0)
            {
                ativosTemp--;
            }
        }

        if (canhoes == ativosTemp)
        {
            win = true;
        }
        //testando***
        if(win == true)
        {
            circleManager.ScoreFinal();
            DesabClicks();
        }        
    }

    void StartGame()
    {

    }

    //Desabilita clicks quando o jogo chega ao fim*****testando
    void DesabClicks()
    {
        for (int i = 0; i < circleManager.circles.Length; i++)
        {
           circleManager.circles[i].ativa = false;
        }
    }
}


