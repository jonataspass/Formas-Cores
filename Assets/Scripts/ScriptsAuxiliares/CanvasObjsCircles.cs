using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CanvasObjsCircles : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textCurrentLife = null, textCurrentClicks = null;

    public int indexCircle;
    [SerializeField]
    private CircleManager circleManager;

    public float currentLifeTemp;
    public float velCont;
    //public GameObject Panel_InitEnergy;
    public float contInitGame;

    //testando****atribuir esses objetos em todos os módulos
    public Image linhaEnerg, iconeEnerg;
    public Image iconeCentralinfinito;
    //public CircleEnergy circleEC;

    int currentLife_temp;

    public GameObject animeMaoCrs;
    int tutorialAnimeMaoCrs;//controla para que apareça apenas uma vez

    public bool modCentral;
    //trabalhando aqui****
    private void Start()
    {
        circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();
        //circleEC = GameObject.FindWithTag("circleEnergyCentral").GetComponent<CircleEnergy>();
        //teste        
        currentLife_temp = circleManager.circles[indexCircle].currentlife;
        linhaEnerg.color = new Color(255, 255, 255, 150);
        iconeEnerg.color = new Color(255, 255, 255, 150);
        animeMaoCrs = GameObject.FindWithTag("animeMaoCrs");;

        StartCoroutine(PegaMaoCrs());

        if (modCentral == true)
        {
            iconeCentralinfinito.color = new Color(255, 255, 255, 150);
        }

    }

    private void Update()
    {
        AtualizaTextsCanvas();
    }

    void AtualizaTextsCanvas()
    {
        if(GAMEMANAGER.instance.CrsCargaAtiva == 0)
        {
            animeMaoCrs.SetActive(true);
        }
        if (GAMEMANAGER.instance.CrsCargaAtiva > 0 && contInitGame <= 10)
        {
            //print("0");
            if (currentLifeTemp < circleManager.circles[indexCircle].currentlife)
            {
                //Sprint("1");
                currentLifeTemp += Time.deltaTime * velCont;
            }
            else if (currentLifeTemp > circleManager.circles[indexCircle].currentlife)
            {
                //print("2");
                currentLifeTemp -= Time.deltaTime * velCont;
            }

            GAMEMANAGER.instance.Panel_InitEnergy.SetActive(true);

            if (contInitGame <= 10)
            {
                contInitGame += Time.deltaTime * velCont;

                if (contInitGame >= 10)
                {
                    //GAMEMANAGER.instance.startGame = true;
                    //testando****//trabalhando aqui
                    GAMEMANAGER.instance.startGame = true;
                    GAMEMANAGER.instance.Panel_InitEnergy.SetActive(false);
                    UIManager.instance.liberaMetodo_Painel_Guia = true;

                    if(GAMEMANAGER.instance.lose == false || GAMEMANAGER.instance.win == true)
                    {
                        UIManager.instance.habilitabBtnsCena = true;
                        UIManager.instance.habilitaBtnRestart = true;
                    }                    

                    if(contInitGame > 10)
                    {
                        contInitGame = 10;
                    }
                }
            }
        }
        else if (GAMEMANAGER.instance.CrsCargaAtiva == 0 && GAMEMANAGER.instance.lose == true
            && GAMEMANAGER.instance.cristalGreen > 0)
        {
            GAMEMANAGER.instance.HabTex_Infor_NoCrs("Sem energia para inicializar os módulos\n carregue com cristais");

            //if (ZPlayerPrefs.GetInt("tutorialAnimeMaoCrs") < 1)
            //{
            //    animeMaoCrs.SetActive(true);

            //    ZPlayerPrefs.SetInt("tutorialAnimeMaoCrs", 1);
            //}

            UIManager.instance.painel_Recompensa.SetActive(false);
        }
        else if (GAMEMANAGER.instance.CrsCargaAtiva == 0 && GAMEMANAGER.instance.destTxtCanvas == false
            && GAMEMANAGER.instance.cristalGreen > 0)
        {
            //GAMEMANAGER.instance.travaBtnReompensa = true;
            GAMEMANAGER.instance.HabTex_Infor_NoCrs("Sem energia para inicializar os módulos\n carregue com cristais");

            //if (ZPlayerPrefs.GetInt("tutorialAnimeMaoCrs") < 1)
            //{
            //    animeMaoCrs.SetActive(true);

            //    ZPlayerPrefs.SetInt("tutorialAnimeMaoCrs", 1);
            //}

            UIManager.instance.painel_Recompensa.SetActive(false);

        }//tem queliberar recompensa
        else if (GAMEMANAGER.instance.CrsCargaAtiva == 0 && GAMEMANAGER.instance.destTxtCanvas == false
            && GAMEMANAGER.instance.cristalGreen == 0 && GAMEMANAGER.instance.travaBtnReompensa == false)
        {
            GAMEMANAGER.instance.HabTex_Infor_NoCrs("Sem energia para inicializar os módulos\n ganhe 30 cristais clicando no botão abaixo");

            //if (ZPlayerPrefs.GetInt("tutorialAnimeMaoCrs") < 1)
            //{
            //    animeMaoCrs.SetActive(true);

            //    ZPlayerPrefs.SetInt("tutorialAnimeMaoCrs", 1);
            //}

            //recompensa cristal
            UIManager.instance.painel_Recompensa.SetActive(true);
            UIManager.instance.crs.enabled = true;
            // GAMEMANAGER.instance.travaBtnReompensa = true;
        }

        textCurrentLife.text = currentLifeTemp.ToString("F0");
        //aplicar a todos os módulos
        if (GAMEMANAGER.instance.CrsCargaAtiva <= 0)
        {

            linhaEnerg.color = new Color(255, 0, 0, 150);
            iconeEnerg.color = new Color(255, 0, 0, 150);
            if (modCentral == true)
            {
                iconeCentralinfinito.color = new Color(255, 0, 0, 150);
            }

            circleManager.circles[indexCircle].currentlife = 0;
        }
        else
        {
            linhaEnerg.color = new Color(0, 255, 0, 150);
            iconeEnerg.color = new Color(0, 255, 0, 150);
            if (modCentral == true)
            {
                iconeCentralinfinito.color = new Color(0, 255, 0, 150);
            }

            //trabalhar nessa linha, currentlife não está atualizando
            //circleManager.circles[indexCircle].currentlife = currentLife_temp;
            //print("Aqu  " + currentLifeTemp);
        }
    }

    IEnumerator PegaMaoCrs()
    {
        yield return new WaitForSeconds(0.1f);
        animeMaoCrs.SetActive(false);
    }
}
