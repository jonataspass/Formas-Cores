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
        string gameId = "4238821";

        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId/*, Debug.isDebugBuild*/);

        ShowBanner();
    }

    void BtnRecompensa()
    {
        //if (Advertisement.IsReady("MyFirtAds_Recompensado"))
        //{   
        //    //atualizar essa linha, resultCallback obsoleto
        //    Advertisement.Show("MyFirtAds_Recompensado", new ShowOptions() { resultCallback = AdsAnalise });
        //    GAMEMANAGER.instance.liberaCristal = true;

        //    //recompensa cristal
        //    UIManager.instance.painel_Recompensa.SetActive(false);
        //    UIManager.instance.crs.enabled = false;

        //    GAMEMANAGER.instance.travaBtnReompensa = true;
        //}
        if (RewardedIsReady())
        {
            ShowRewarded();
            GAMEMANAGER.instance.liberaCristal = true;

            //recompensa cristal
            UIManager.instance.painel_Recompensa.SetActive(false);
            UIManager.instance.crs.enabled = false;

            GAMEMANAGER.instance.travaBtnReompensa = true;
        }

    }

    //void AdsAnalise(ShowResult result)
    //{
    //    if (result == ShowResult.Finished)
    //    {
    //        GAMEMANAGER.instance.cristalGreen += 30;
    //        GAMEMANAGER.instance.SalvaCristais(GAMEMANAGER.instance.cristalGreen);

    //        //Se tentativas extras == 0 e libera para ganhar tentativas extras == true
    //        //trabalhando aqui****
    //        if (GAMEMANAGER.instance.num_tentativas == 0)
    //        {
    //            GAMEMANAGER.instance.num_tentativas = GAMEMANAGER.instance.extraTry;
    //            UIManager.instance.painel_Recompensa.SetActive(false);
    //            UIManager.instance.txt_Informativo.enabled = false;
    //            GAMEMANAGER.instance.travaPainelExtras = true;
    //            GAMEMANAGER.instance.liberaExtras = 2;
    //            //libera click nos módulos
    //            GAMEMANAGER.instance.getExtra = true;
    //        }
    //    }
    //    else if (GAMEMANAGER.instance.num_tentativas == 0)
    //    {
    //        UIManager.instance.txt_Informativo.enabled = false;
    //        //GAMEMANAGER.instance.liberalose = true;
    //        //GAMEMANAGER.instance.liberaExtras = 2;
    //        GAMEMANAGER.instance.VerificaLose();
    //    }
            
    //}

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
        //    GAMEMANAGER.instance.liberaCristal = true;

        //    //recompensa cristal
        //    UIManager.instance.painel_Recompensa.SetActive(false);
        //    UIManager.instance.crs.enabled = false;

        //    GAMEMANAGER.instance.travaBtnReompensa = true;
    }


    //-------------------------------------------------------------------------------------------


    IEnumerator WaitToShowAds()
    {
        yield return new WaitForSeconds(5);
        //INTERSTITIAL
        if (PlayerPrefs.HasKey("AdsUnity"))
        {
            print("Interstitial " + PlayerPrefs.GetInt("AdsUnityRewarded"));
            if (PlayerPrefs.GetInt("AdsUnity") == 3)
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
        //----------------------------------------------------------------
        //REWARDEDCristais
        if (PlayerPrefs.HasKey("AdsUnityRewarded"))
        {
            print("Rewarded "+PlayerPrefs.GetInt("AdsUnityRewarded"));
            if (PlayerPrefs.GetInt("AdsUnityRewarded") >= 2 && PlayerPrefs.GetInt("AdsUnity") != 5)
            {
                GAMEMANAGER.instance.HabTex_Informativo("Assista um vídeo e ganhe 30 cristais clicando no botão abaixo");
                //recompensa
                UIManager.instance.painel_Recompensa.SetActive(true);
                UIManager.instance.crs.enabled = true;

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
        if(placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            GAMEMANAGER.instance.cristalGreen += 30;
            GAMEMANAGER.instance.SalvaCristais(GAMEMANAGER.instance.cristalGreen);

            //Se tentativas extras == 0 e libera para ganhar tentativas extras == true
            //trabalhando aqui****
            //if (GAMEMANAGER.instance.num_tentativas == 0)
            //{
            //    GAMEMANAGER.instance.num_tentativas = GAMEMANAGER.instance.extraTry;
            //    UIManager.instance.painel_Recompensa.SetActive(false);
            //    UIManager.instance.txt_Informativo.enabled = false;
            //    GAMEMANAGER.instance.travaPainelExtras = true;
            //    GAMEMANAGER.instance.liberaExtras = 2;
            //    //libera click nos módulos
            //    GAMEMANAGER.instance.getExtra = true;
            //}
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
