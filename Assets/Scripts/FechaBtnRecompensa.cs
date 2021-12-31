using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FechaBtnRecompensa : MonoBehaviour
{
    [SerializeField]
    Button fechaBtnRecompensa;

    void Start()
    {
        fechaBtnRecompensa = gameObject.GetComponent<Button>();
        fechaBtnRecompensa.onClick.AddListener(() => FechaRecompensa());
    } 
    
    void FechaRecompensa()
    {
        //destrava click
        for (int i = 0; i < GAMEMANAGER.instance.circleManager.circles.Length; i++)
        {
            GAMEMANAGER.instance.circleManager.circles[i].trava_Click = false;
        }

        UIManager.instance.painel_Recompensa.SetActive(false);
        UIManager.instance.crs.enabled = false;
        UnityAds.instance.rewardedAtivo = false;
    }
}
