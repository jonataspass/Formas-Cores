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

    //testando***trabalhando aqui
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
            print("Você venceu!");
        }
    }
}


