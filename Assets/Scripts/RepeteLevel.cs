using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ESSE SCRIPT CONTROLA A QUANTIDADE DE VEZEZ QUE O PLAYER REPETIU UM LEVEL AO PERDER
//QUANDO O PLAYER PERDER 3 VEZEZ O GAME OFERECE AO PLAYER: ASSISTIR ANÚNCIO PARA GANHAR...
//UMA DICA OU COMPRAR UMA DICA COM CRISTAIS
public class RepeteLevel : MonoBehaviour
{
    public static RepeteLevel instance;
    public bool dica_R;
    public GameObject animaMao_Dica;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        SceneManager.sceneLoaded += Carrega;
    }

    void Carrega(Scene cena, LoadSceneMode modo)
    {
        StartRepete_Level();
    }

    void StartRepete_Level()
    {
        if(LevelAtual.instance.level >= 6)
        {
            animaMao_Dica = GameObject.FindWithTag("animeMao_Dica");
            animaMao_Dica.SetActive(false);
        }

        if (!ZPlayerPrefs.HasKey("tutorialAnimeMaoDica"))
        {
            ZPlayerPrefs.SetInt("tutorialAnimeMaoDica", 0);
        }
    } 

    //SAVE CONTROLA LEVEL REPETIDO
    public void SaveRepetLevel()
    {
        if (GAMEMANAGER.instance.lose == true || GAMEMANAGER.instance.getExtra == true)
        {
            if (!ZPlayerPrefs.HasKey("repeteLevel_" + LevelAtual.instance.level))
            {
                ZPlayerPrefs.SetInt("repeteLevel_" + LevelAtual.instance.level, 1);
            }
            else if (ZPlayerPrefs.GetInt("repeteLevel_" + LevelAtual.instance.level) < 3 && PlayerPrefs.GetInt("AdsUnity") != 5
                       && GAMEMANAGER.instance.CrsCargaAtiva > 1)
            {
                ZPlayerPrefs.SetInt("repeteLevel_" + LevelAtual.instance.level, ZPlayerPrefs.GetInt("repeteLevel_" + LevelAtual.instance.level) + 1);
            }


            print("dica" + ZPlayerPrefs.GetInt("repeteLevel_" + LevelAtual.instance.level));
            print("adsUnity" + PlayerPrefs.GetInt("AdsUnity"));
        }
    }

    //CHAMA ADS AO PERDER TRÊS VEZEZ NO MESMO LEVEL
    public void HabilitaDica_R()
    {
        if (ZPlayerPrefs.GetInt("repeteLevel_" + LevelAtual.instance.level) == 3 && PlayerPrefs.GetInt("AdsUnity") != 5
                && GAMEMANAGER.instance.CrsCargaAtiva > 0)
        {
            GAMEMANAGER.instance.HabTex_Infor_NoCrs("Com dificuldades?\ncompre uma dica");
            UIManager.instance.crs.enabled = false;

            if(ZPlayerPrefs.GetInt("tutorialAnimeMaoDica") < 1)
            {
                animaMao_Dica.SetActive(true);
                ZPlayerPrefs.SetInt("tutorialAnimeMaoDica", 1);
            }

            ZPlayerPrefs.SetInt("repeteLevel_" + LevelAtual.instance.level, 0);
            print("habilitadicaR");
        }
    }
}
