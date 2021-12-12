using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetaCrsG : MonoBehaviour
{
    public Animator coletaCrs;
    public AudioSource audio_coletaCrsG;
    public int id_crs;

    private void Start()
    {
        if (ZPlayerPrefs.HasKey(LevelAtual.instance.level + id_crs + "cristalRecolhido"))
        {
            Destroy(gameObject);
        }            
    }

    //Coleta cristais de energia
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("collReceptLazer") && GAMEMANAGER.instance.startGame == true)
        {
            GAMEMANAGER.instance.id_Crs_gameManager = id_crs;
            GAMEMANAGER.instance.coletouCrs = true;
            GAMEMANAGER.instance.ColetaCristalGreen(10);
            UIManager.instance.AtualizaCristalGreen(GAMEMANAGER.instance.cristalGreen);
            audio_coletaCrsG.Play();
            coletaCrs.Play("animeColetaCrsG");

            Destroy(gameObject, 1);
        }
    }
}
