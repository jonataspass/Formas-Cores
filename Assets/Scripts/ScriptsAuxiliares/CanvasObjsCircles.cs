using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class CanvasObjsCircles : MonoBehaviour
{
    //void Awake()
    //{
    //    SceneManager.sceneLoaded += Carrega;
    //}

    [SerializeField]
    private TextMeshProUGUI textCurrentLife = null, textCurrentClicks = null;

    public int indexCircle;
    [SerializeField]
    private CircleManager circleManager;

    //testando****
    public float currentLifeTemp;
    public float velCont;
    public GameObject Panel_InitEnergy;
    private float contInitGame;

    private void Start()
    {
        circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();
        Panel_InitEnergy = GameObject.FindWithTag("PanelInitEnergy");
        StartCanvas();
        //circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();
        //Panel_InitEnergy = GameObject.FindWithTag("PanelInitEnergy");
    }

    private void Update()
    {
        Desativa_PainelInitEnergy();
    }

    private void FixedUpdate()
    {
        AtualizaTextsCanvas();
    }
  //testando****
    //void Carrega(Scene cena, LoadSceneMode modo)
    //{
    //    if(LevelAtual.instance.level >= 5)
    //    circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();
    //    Panel_InitEnergy = GameObject.FindWithTag("PanelInitEnergy");
    //    StartCanvas();
    //}

    void AtualizaTextsCanvas()
    {
        if (currentLifeTemp < circleManager.circles[indexCircle].currentlife)
        {
            currentLifeTemp += Time.deltaTime * velCont;
        }
        else if (currentLifeTemp > circleManager.circles[indexCircle].currentlife)
        {
            currentLifeTemp -= Time.deltaTime * velCont;
        }
        //testando****
        if(contInitGame < 10)
        {
            contInitGame += Time.deltaTime * velCont;
            if (contInitGame >= 10)
            {
                GAMEMANAGER.instance.startGame = true;
                UIManager.instance.liberaMetodo_Painel_Guia = true;
                UIManager.instance.desabBtnsCena = true;
            }            
        }

        textCurrentLife.text = currentLifeTemp.ToString("F0");
        textCurrentClicks.text = circleManager.circles[indexCircle].currentClicks.ToString();
    }

    void Desativa_PainelInitEnergy()
    {
        if(GAMEMANAGER.instance.startGame == true)
        {
            Panel_InitEnergy.SetActive(false);
        }
    }

    void StartCanvas()
    {
        AtualizaTextsCanvas();
        Desativa_PainelInitEnergy();
        Panel_InitEnergy.SetActive(true);
    }
}
