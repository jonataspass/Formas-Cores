using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelAtual : MonoBehaviour
{
    public int level = -1;
    public string cenaAtual;

    [SerializeField]
    public static LevelAtual instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += VerificaFase;
    }

    void VerificaFase(Scene cena, LoadSceneMode modo)
    {
        level = SceneManager.GetActiveScene().buildIndex;
    }

    ////método utilizado na cena FaseMestra para entrar nos mundos
    //public void CarregaMundo(string s)
    //{
    //    mundoAtual = s;
    //    SceneManager.LoadScene(mundoAtual);
    //}
}
