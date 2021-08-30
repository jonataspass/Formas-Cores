using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnityAds : MonoBehaviour
{
    public static UnityAds instance;

    public Button btn_Recompensa;
    //public Image crs, missel, dica, extras;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }

        SceneManager.sceneLoaded += Carrega;
    }

    void Carrega(Scene cena, LoadSceneMode modo)
    {
        if (LevelAtual.instance.level >= 6)
        {
            btn_Recompensa = GameObject.FindWithTag("btnRecompensa").GetComponent<Button>();
            btn_Recompensa.onClick.AddListener(BtnRecompensa);
        }

        ShowBanner();
    }

    private void Start()
    {
        Advertisement.Initialize("4238821");
        ShowBanner();
    }

    void BtnRecompensa()
    {
        if (Advertisement.IsReady("MyFirtAds_Recompensado"))
        {   
            //atualizar essa linha, resultCallback obsoleto
            Advertisement.Show("MyFirtAds_Recompensado", new ShowOptions() { resultCallback = AdsAnalise });
            GAMEMANAGER.instance.liberaCristal = true;

            //recompensa cristal
            UIManager.instance.painel_Recompensa.SetActive(false);
            UIManager.instance.crs.enabled = false;

            GAMEMANAGER.instance.travaBtnReompensa = true;
        }
    }

    void AdsAnalise(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            GAMEMANAGER.instance.cristalGreen += 1;
            GAMEMANAGER.instance.SalvaCristais(GAMEMANAGER.instance.cristalGreen);

            //Se tentativas extras == 0 e libera para ganhar tentativas extras == true
            //trabalhando aqui****
            if (GAMEMANAGER.instance.num_tentativas == 0)
            {
                GAMEMANAGER.instance.num_tentativas = GAMEMANAGER.instance.extraTry;
                UIManager.instance.painel_Recompensa.SetActive(false);
                UIManager.instance.txt_Informativo.enabled = false;
                GAMEMANAGER.instance.travaPainelExtras = true;
                GAMEMANAGER.instance.liberaExtras = 2;
                //libera click nos módulos
                GAMEMANAGER.instance.getExtra = true;
            }
        }
        else if (GAMEMANAGER.instance.num_tentativas == 0)
        {
            UIManager.instance.txt_Informativo.enabled = false;
            //GAMEMANAGER.instance.liberalose = true;
            //GAMEMANAGER.instance.liberaExtras = 2;
            GAMEMANAGER.instance.VerificaLose();
        }
            
    }
    public void ShowAds()
    {
        if (PlayerPrefs.HasKey("AdsUnity"))
        {
            if (PlayerPrefs.GetInt("AdsUnity") == 5)
            {
                if (Advertisement.IsReady("MyFirtAds_Recompensado"))
                {
                    Advertisement.Show("MyFirtAds_Recompensado");
                }

                PlayerPrefs.SetInt("AdsUnity", 1);
            }
            else
            {
                PlayerPrefs.SetInt("AdsUnity", PlayerPrefs.GetInt("AdsUnity") + 1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("AdsUnity", 1);
        }

    }

    void ShowBanner()
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show("Banner_Android");
    }
}
