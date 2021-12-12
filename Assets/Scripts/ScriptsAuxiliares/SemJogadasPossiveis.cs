using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemJogadasPossiveis : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("collReceptLazer"))
        {
            GAMEMANAGER.instance.lose = true;
            GAMEMANAGER.instance.canhaoAtivo = false;
            UIManager.instance.txt_Painel_WL.text = "You Lose!!!";
            UIManager.instance.txt_Painel_info_WL.text = "Você estava sem jogadas possíveis";
            UIManager.instance.UI_Win();
            UIManager.instance.habilitabBtnsCena = false;
            UIManager.instance.habilitaBtnRestart = false;
        }
    }
}
