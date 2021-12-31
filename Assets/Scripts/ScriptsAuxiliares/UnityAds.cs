using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnityAds : MonoBehaviour, IUnityAdsListener
{
    public static UnityAds instance;

    public Button btn_Recompensa;

    public bool rewardedAtivo;
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
            rewardedAtivo = false;
        }

        ShowBanner();
    }

    private void Start()
    {
        string gameId = "4238821";

        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId/*, Debug.isDebugBuild*/);

        ShowBanner();
        rewardedAtivo = false;
    }

    void BtnRecompensa()
    {
        //destrava click
        for (int i = 0; i < GAMEMANAGER.instance.circleManager.circles.Length; i++)
        {
            GAMEMANAGER.instance.circleManager.circles[i].trava_Click = false;
        }


        if (RewardedIsReady())
        {
            ShowRewarded();
            GAMEMANAGER.instance.liberaCristal = true;

            //recompensa cristal
            UIManager.instance.painel_Recompensa.SetActive(false);
            UIManager.instance.crs.enabled = false;

            GAMEMANAGER.instance.travaBtnReompensa = true;
        }

        rewardedAtivo = false;

    }

    //Interstial
    public void ShowAds()
    {
        StartCoroutine(WaitToShowAds());
    }

    //Banner
    void ShowBanner()
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_LEFT);
        Advertisement.Banner.Show("Banner_Android");
    }

    //-------------------------------------------------------------------------------------------

    //Rewarded
    public void ShowRewarded()
    {
        Advertisement.Show("Rewarded_Android");
    }

    public bool RewardedIsReady()
    {
        return Advertisement.IsReady("Rewarded_Android");
    }


    //-------------------------------------------------------------------------------------------


    IEnumerator WaitToShowAds()
    {
        yield return new WaitForSeconds(5);
        //INTERSTITIAL
        if (PlayerPrefs.HasKey("AdsUnity"))
        {
            if (PlayerPrefs.GetInt("AdsUnity") == 5 && PlayerPrefs.GetInt("AdsUnityRewarded") != 3)
            {
                if (Advertisement.IsReady("MyFirtAds_Recompensado"))
                {
                    Advertisement.Show("MyFirtAds_Recompensado");
                }

                PlayerPrefs.SetInt("AdsUnity", 1);
            }
            else if (PlayerPrefs.GetInt("AdsUnity") == 5 && PlayerPrefs.GetInt("AdsUnityRewarded") == 3)
            {
                PlayerPrefs.SetInt("AdsUnity", 4);
            }
            else if (PlayerPrefs.GetInt("AdsUnity") > 5)
            {
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

        //----------------------------------------------------------------

        //REWARDEDCristais
        if (PlayerPrefs.HasKey("AdsUnityRewarded"))
        {
            if (PlayerPrefs.GetInt("AdsUnityRewarded") == 3 && PlayerPrefs.GetInt("AdsUnity") != 5)
            {
                GAMEMANAGER.instance.HabTex_Informativo("Assista um vídeo e ganhe 30 cristais clicando no botão abaixo");
                //recompensa
                UIManager.instance.painel_Recompensa.SetActive(true);
                UIManager.instance.crs.enabled = true;

                rewardedAtivo = true;

                PlayerPrefs.SetInt("AdsUnityRewarded", 1);
            }
            else if (PlayerPrefs.GetInt("AdsUnityRewarded") == 3 && PlayerPrefs.GetInt("AdsUnity") == 5)
            {
                PlayerPrefs.SetInt("AdsUnityRewarded", 2);
            }
            else if (PlayerPrefs.GetInt("AdsUnityRewarded") > 3)
            {
                PlayerPrefs.SetInt("AdsUnityRewarded", 1);
            }
            else
            {
                PlayerPrefs.SetInt("AdsUnityRewarded", PlayerPrefs.GetInt("AdsUnityRewarded") + 1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("AdsUnityRewarded", 1);
        }
    }



    //------------------------------------------------------------------------------------------

    //interfaces dos Ads
    public void OnUnityAdsReady(string placementId)
    {
        //executa quando um placementId está pronto para ser mostrado na tela
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError("Unity ERROR: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //executa quando um video começa a ser mostrado na tela
        //exemplo: pode ser usado para pausar o jogo quando um video aparecer, já pausa automáticamente 
        //ou pode ser criada uma programação prória
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //executa quando uma propaganda finaliza
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            GAMEMANAGER.instance.cristalGreen += 30;
            GAMEMANAGER.instance.SalvaCristais(GAMEMANAGER.instance.cristalGreen);
        }
        else if (GAMEMANAGER.instance.num_tentativas == 0)
        {
            UIManager.instance.txt_Informativo.enabled = false;
            //GAMEMANAGER.instance.liberalose = true;
            //GAMEMANAGER.instance.liberaExtras = 2;
            GAMEMANAGER.instance.VerificaLose();
        }
    }
}
