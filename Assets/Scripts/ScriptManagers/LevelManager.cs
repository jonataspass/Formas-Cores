using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Loanding loanding;
    public RectTransform positionPanelBtns;
    public float posBtnsL;

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

        if (ZPlayerPrefs.HasKey(LevelAtual.instance.cenaAtual + "salvaPos"))
        {
            posBtnsL = ZPlayerPrefs.GetFloat(LevelAtual.instance.cenaAtual +"salvaPos");
            positionPanelBtns.position = new Vector2(positionPanelBtns.position.x, posBtnsL);
        }
        else
        {
            positionPanelBtns.position = new Vector2(positionPanelBtns.position.x, positionPanelBtns.position.y);
        }

        //ZPlayerPrefs.DeleteKey("Level3_MCS");
    }

    private void Update()
    {
        if (posBtnsL != positionPanelBtns.position.y)
        {
            posBtnsL = positionPanelBtns.position.y;
            SavaPositionBtnLv(posBtnsL);
        }
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

            //TESTANDO DESBLOQUEIO DE FASE MESTRA
            VerificaUltimoLv(lv.level_Real, lv.habilitado);

            //desbloqueia btn
            newBtnTemp.desbloq_Btn = lv.desbloq;
            //Habilita btn
            newBtnTemp.GetComponent<Button>().interactable = lv.habilitado;
            //Add o novo btn ao painel
            newBtn.transform.SetParent(localBtn, false);

            //testando****
            newBtnTemp.GetComponent<Button>().onClick.AddListener(() => loanding.Loading(newBtnTemp.textLevel_Btn.text + "_" + LevelAtual.instance.cenaAtual));

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
            if (LevelAtual.instance.cenaAtual == "MCS")
            {
                mestraMCS++;
                ZPlayerPrefs.SetInt("LevelsMCS", mestraMCS);
            }
            else if (LevelAtual.instance.cenaAtual == "MCH")
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

    //salva posição do content de btnslevel
    void SavaPositionBtnLv(float pos)
    {
        ZPlayerPrefs.SetFloat(LevelAtual.instance.cenaAtual + "salvaPos", pos);
    }

    //metodo verifica se útimo level da fase mestra está desbloqueada
    void VerificaUltimoLv(string ultimolv, bool habilitado)
    {
        if (LevelAtual.instance.level == 3)
        {
            string nomeNivel = LevelAtual.instance.cenaAtual;            
        }

        //desbloqueio próximo nivel "MCH/MCAH..."
        if (LevelAtual.instance.cenaAtual == "MCS" && ultimolv == "25")
        {
            if (habilitado == true)
            {
                ZPlayerPrefs.SetInt("DesbloqMCH", 1);
                GAMEMANAGER.instance.desbloMS2 = 1;
            }
        }
    }
}
