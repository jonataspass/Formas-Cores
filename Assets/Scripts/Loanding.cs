using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Loanding : MonoBehaviour
{
    public string cenaACarregar;
    public TextMeshProUGUI txt_porcentagemDeCarregamento;
    public Animator animeLoading;

    private void Start()
    {
        animeLoading = GetComponent<Animator>();
        txt_porcentagemDeCarregamento = GetComponentInChildren<TextMeshProUGUI>();
        animeLoading.gameObject.SetActive(false);
    }

    public void Loading(string cena)
    {
        GAMEMANAGER.instance.win = false;
        animeLoading.gameObject.SetActive(true);
        StartCoroutine(CenaDeCarregamento(cena));
    }
    //testandoBtnProxioLevel
    public void LoadingBtnProximo(string cena)
    {
        GAMEMANAGER.instance.win = false;
        animeLoading.gameObject.SetActive(true);
        StartCoroutine(CenaDeCarregamento_BtnProximo(cena));
    }

    IEnumerator CenaDeCarregamento(string cena)
    {
        yield return null;

        AsyncOperation carregamento = SceneManager.LoadSceneAsync(cena);

        carregamento.allowSceneActivation = false;

        while (!carregamento.isDone)
        {
            LevelAtual.instance.cenaAtual = cena;
            txt_porcentagemDeCarregamento.text = "Loading " + (carregamento.progress * 100).ToString("N0") + "%";
            animeLoading.Play("AnimeLoading");

            if(carregamento.progress >= 0.9f)
            {
                txt_porcentagemDeCarregamento.text = "Loading 100%";
                carregamento.allowSceneActivation = true;
            }            

            yield return null;
        }
        
        
    }
    //testando****
    IEnumerator CenaDeCarregamento_BtnProximo(string codLevel)
    {
        yield return null;
        //GAMEMANAGER.instance.win = false;
        LevelAtual.instance.cenaAtual = "Level" + (LevelAtual.instance.level - 4) + codLevel;
        AsyncOperation carregamento = SceneManager.LoadSceneAsync(LevelAtual.instance.cenaAtual);

        carregamento.allowSceneActivation = false;

        while (!carregamento.isDone)
        {
            LevelAtual.instance.cenaAtual = "Level" + (LevelAtual.instance.level - 4) + codLevel;
            txt_porcentagemDeCarregamento.text = "Loading " + (carregamento.progress * 100).ToString("N0") + "%";
            animeLoading.Play("AnimeLoading");

            if (carregamento.progress >= 0.9f)
            {
                txt_porcentagemDeCarregamento.text = "Loading 100%";
                carregamento.allowSceneActivation = true;
            }

            yield return null;
        }


    }

}
