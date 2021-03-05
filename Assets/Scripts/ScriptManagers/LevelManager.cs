using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    //Classe com os atributos de cada btn gerado
    [System.Serializable]
    public class Level
    {
        public string levelText;
        public bool habilitado;
        public int desbloq;
        //Verificar funçao na aula FaseMestra
        public string level_Real;        
    }

    private void Start()
    {        
        AddBtn();        
        PlayerPrefs.SetInt("Level1_RedSC", 1);
        
        //PlayerPrefs.DeleteAll();
    }

    //Variáveis para geração dos btns
    public GameObject btnPrefab;
    public Transform localBtn;
    public List<Level> levelList;

    //Cria e add os btns ao painel
    void AddBtn()
    {
        foreach(Level lv in levelList)
        {
            //Instancia um novo btn
            GameObject newBtn = Instantiate(btnPrefab) as GameObject;
            //Variável que recebe o componente "Script BtnLevel" do newBtn
            BtnLevels newBtnTemp = newBtn.GetComponent<BtnLevels>();
            newBtnTemp.textLevel_Btn.text = lv.levelText;
            //VERIFICAR FUNÇÂO desta variável na aula faseMestra do projeto angry birds
            newBtnTemp.realLevel = lv.level_Real;
            //Aula 339 Udemy
            if (PlayerPrefs.GetInt(newBtnTemp.textLevel_Btn.text + "_" + LevelAtual.instance.cenaAtual) == 1)
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
            newBtnTemp.GetComponent<Button>().onClick.AddListener(() => ClickLevel(newBtnTemp.textLevel_Btn.text + "_" + LevelAtual.instance.cenaAtual));
        }

        
    }

    public void ClickLevel(string s)
    {
        LevelAtual.instance.cenaAtual = s;
        SceneManager.LoadScene(s);        
    }
}
