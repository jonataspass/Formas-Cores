using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        SceneManager.sceneLoaded += Carrega;
    }

    //GameObject com Script CircleManager
    public CircleManager circleManager;

    //*******criar outros circleManagers para gerenciar estações interdependentes****
    public CircleManager circleManager1;
    
    //Variáveis de Win
    public bool win, lose;   
    
    //testando****variável que destrava inicialização do jogo
    public bool startGame;

    private void Update()
    {
             
    }

    //Carrega cena
    void Carrega(Scene cena, LoadSceneMode modo)
    {
        win = false;

        if (LevelAtual.instance.level >= 5)
        {
            circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();

            StartGame();
        }
    }

    void StartGame()
    {
        //pontuação
        ScoreManager.instance.ptsMarcados_Total = 0;
        ScoreManager.instance.conta_ptsMarcados = 0;
        

        //canhões
        ativosTemp = 0;
        
        //PlayerPrefs.DeleteAll();
    }

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
        
        if (win == true)
        {
            circleManager.ScoreFinal();
            DesabClicks();
            DesbloqueiaLevel();

            //testando****  
            UIManager.instance.txt_Painel_WL.text = "You Win!!!";
            UIManager.instance.txt_Painel_info_WL.text = "";
            UIManager.instance.UI_Win();
            UIManager.instance.desabBtnsCena = false;//testando****
            startGame = false;
        }
    }

    //testando****
    public void YouLose(int canhoes, int ativados)
    {
        if (ativados < canhoes)
        {
            lose = true;
            //testando****  
            UIManager.instance.txt_Painel_WL.text = "You Lose!!!";
            UIManager.instance.txt_Painel_info_WL.text = "não haviam mais jogadas possíveis";
            UIManager.instance.UI_Win();
            UIManager.instance.desabBtnsCena = false;//testando****
            print("LOSE");
        }
    }    

    //Desabilita clicks quando o jogo chega ao fim
    void DesabClicks()
    {
        for (int i = 0; i < circleManager.circles.Length; i++)
        {
            circleManager.circles[i].ativa = false;
        }
    }

    //Desbloqueia uma nova fase quando um level é concluído
    void DesbloqueiaLevel()
    {
        int temp = LevelAtual.instance.level - 4;
        temp++;
        PlayerPrefs.SetInt("Level" + temp + "_RedSC", 1);
    }

    //testando****
    public void ShowTextEnergy(int indexVet)
    {
        UIManager.instance.textEnergy.text = circleManager.circles[indexVet].currentlife.ToString();
    }
}


