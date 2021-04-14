using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Dicas : MonoBehaviour
{
    [System.Serializable]
    public class DicasAtributos
    {
        public GameObject dicas;
        public bool dicaAtiva;
        //Qtda de clicks que o usuário deve dar
        public int qtdClickIni_Dica;
        public int dicaClick;
        public TextMeshProUGUI txtDica;//texto atribuído manualmente no inspector
        //testando//preço de cada dica
        public int priceDica;
        public TextMeshProUGUI textPriceDica;
        public Button btnAtiv;        
    }

    public DicasAtributos[] objDica;

    public CircleManager circleManager;

    private void Update()
    {
        for (int i = 0; i < objDica.Length; i++)
        {
            //atualiza text Dica
            objDica[i].txtDica.text = objDica[i].dicaClick.ToString();
        }
    }

    void Start()
    {
        //inicializa Dicas
        for (int i = 0; i < objDica.Length; i++)
        {
            objDica[i].txtDica.text = objDica[i].dicaClick.ToString();
            objDica[i].dicas.SetActive(false);
            objDica[i].textPriceDica.text = objDica[i].priceDica.ToString();
            objDica[i].dicaClick = objDica[i].qtdClickIni_Dica;
        }

        circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();
    }

    void StartDicas()
    {

    }

    public void LiberaDica(int index)
    {
        objDica[index].dicaClick = objDica[index].qtdClickIni_Dica; 

        //testando****
        if (GAMEMANAGER.instance.cristalGreen >= objDica[index].priceDica 
            && circleManager.circles[index].currentlife >= objDica[index].dicaClick )
        {            
            print(objDica[index].priceDica);
            GAMEMANAGER.instance.DecrementaCristal(objDica[index].priceDica);
            objDica[index].dicas.SetActive(true);
            objDica[index].dicaAtiva = true;
            //desabilita btnDica
            objDica[index].btnAtiv.enabled = false;
            objDica[index].btnAtiv.interactable = false;
        }
    }

    public void Desat_Dica(int index)
    {
        //Desativa Dica
        objDica[index].dicas.SetActive(false);
        objDica[index].dicaAtiva = false;
        //Habilita btnDica
        objDica[index].btnAtiv.enabled = true;
        objDica[index].btnAtiv.interactable = true;
    }
}