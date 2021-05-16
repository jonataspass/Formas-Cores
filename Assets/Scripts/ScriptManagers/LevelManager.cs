using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Loanding loanding;

    private void Awake()
    {
        ZPlayerPrefs.Initialize("157JONATAS", "157157157");

        if (instance == null)
        {
            instance = this;
        }
    }

    //Classe com os atributos de cada btn gerado
    [System.Serializable]
    public class Level
    {
        public string levelText;
        public bool habilitado;
        public int desbloq;
        public string level_Real;
    }

    private void Start()
    {
        AddBtn();
        //if (LevelAtual.instance.level >= 6)
        //    loanding = GameObject.FindWithTag("animeLoading").GetComponent<Loanding>();
    }

    //Variáveis para geração dos btns
    public GameObject btnPrefab;
    public Transform localBtn;
    public List<Level> levelList;

    //variáveis pts fases mestras MCS, MCH, MCAH
    public int mestraMCS, mestraMCH, mestraMCAH;//testando****

    //Cria e add os btns ao painel
    void AddBtn()
    {
        foreach (Level lv in levelList)
        {
            //Instancia um btn prefab que possui o script BtnLevels
            GameObject newBtn = Instantiate(btnPrefab) as GameObject;
            //Variável que recebe o componente "Script BtnLevel" do newBtn
            BtnLevels newBtnTemp = newBtn.GetComponent<BtnLevels>();
            newBtnTemp.textLevel_Btn.text = lv.levelText;
            //levelReal possui o index que é salvo em Zplayerprefs
            newBtnTemp.realLevel = lv.level_Real;

            //Inicia o Level1 desbloquedo
            if (ZPlayerPrefs.GetInt(newBtnTemp.textLevel_Btn.text + "_" + LevelAtual.instance.cenaAtual) == 1)
            {
                lv.desbloq = 1;
                lv.habilitado = true;
            }

            //desbloqueia btn
            newBtnTemp.desbloq_Btn = lv.desbloq;
            //Habilita btn
            newBtnTemp.GetComponent<Button>().interactable = lv.habilitado;
            //Add o novo btn ao painel
            newBtn.transform.SetParent(localBtn, false);

            //newBtnTemp.GetComponent<Button>().onClick.AddListener(() => ClickLevel(newBtnTemp.textLevel_Btn.text + "_" + LevelAtual.instance.cenaAtual));
            //testando****
            newBtnTemp.GetComponent<Button>().onClick.AddListener(() => loanding.Loading(newBtnTemp.textLevel_Btn.text + "_" + LevelAtual.instance.cenaAtual));
            //loanding.Loading(newBtnTemp.textLevel_Btn.text + "_" + LevelAtual.instance.cenaAtual);

            //mostra os capacetes em cada btn
            if (ZPlayerPrefs.GetInt("Level" + newBtnTemp.realLevel + "_" + LevelAtual.instance.cenaAtual + "capacete") == 1)
            {
                newBtnTemp.capacete_Bronze.enabled = true;
            }
            else if (ZPlayerPrefs.GetInt("Level" + newBtnTemp.realLevel + "_" + LevelAtual.instance.cenaAtual + "capacete") == 2)
            {
                newBtnTemp.capacete_Bronze.enabled = true;
                newBtnTemp.capacete_Prata.enabled = true;
            }
            else if (ZPlayerPrefs.GetInt("Level" + newBtnTemp.realLevel + "_" + LevelAtual.instance.cenaAtual + "capacete") == 3)
            {
                newBtnTemp.capacete_Bronze.enabled = true;
                newBtnTemp.capacete_Prata.enabled = true;
                newBtnTemp.capacete_Ouro.enabled = true;
            }
            else
            {
                newBtnTemp.capacete_Bronze.enabled = false;
                newBtnTemp.capacete_Prata.enabled = false;
                newBtnTemp.capacete_Ouro.enabled = false;
            }

            //Percorre os levels de cada fase mestra
            if(LevelAtual.instance.cenaAtual == "MCS")
            {
                mestraMCS++;
                ZPlayerPrefs.SetInt("LevelsMCS", mestraMCS);
            }
            else if(LevelAtual.instance.cenaAtual == "MCH")
            {
                mestraMCH++;
                ZPlayerPrefs.SetInt("LevelsMCH", mestraMCH);
            }
            else if (LevelAtual.instance.cenaAtual == "MCAH")
            {
                mestraMCAH++;
                ZPlayerPrefs.SetInt("LevelsMCAH", mestraMCAH);
            }
        }
    }

    //carrega cena pelo btnLevel
    public void ClickLevel(string s)
    {
        //StartCoroutine(WaitSoundClick(s));
        LevelAtual.instance.cenaAtual = s;
        SceneManager.LoadScene(s);
    }

    //carrega próxima cena pelo brnProximo
    public void BtnCarrega_ProximoLevel(string codLevel)
    {
        //StartCoroutine(WaitSoundClick_BtnProximo(codLevel));
        //GAMEMANAGER.instance.win = false;
        //LevelAtual.instance.cenaAtual = "Level" + (LevelAtual.instance.level - 4) + codLevel;
        //SceneManager.LoadScene(LevelAtual.instance.cenaAtual);
        //print("Level" + (LevelAtual.instance.level - 4) + codLevel);
    }

    IEnumerator WaitSoundClick(string s)
    {
        yield return new WaitForSeconds(0.4f);
        LevelAtual.instance.cenaAtual = s;
        SceneManager.LoadScene(s);
    }

    //IEnumerator WaitSoundClick_BtnProximo(string codLevel)
    //{
    //    yield return new WaitForSeconds(0.4f);
    //    GAMEMANAGER.instance.win = false;
    //    LevelAtual.instance.cenaAtual = "Level" + (LevelAtual.instance.level - 4) + codLevel;
    //    SceneManager.LoadScene(LevelAtual.instance.cenaAtual);
    //    //print("Level" + (LevelAtual.instance.level - 4) + codLevel);
    //}
}
