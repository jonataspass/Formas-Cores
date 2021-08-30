using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

//Script inserido no obj Dica e btnCompra Dica
public class Dicas : MonoBehaviour
{
    [System.Serializable]
    public class DicasAtributos
    {
        public GameObject dicas;
        public bool dicaAtiva;
        //Qtda de clicksIni é usado para diminuir a currentlife
        //e apresentar a qtda de clicks exatas necessárias
        //public int qtdClickIni_Dica;
        //public int dicaClick;
        //public TextMeshProUGUI txtDica;//texto atribuído manualmente no inspector
        //testando//preço de cada dica
        public int priceDica;
        public TextMeshProUGUI textPriceDica;
        public Button btnAtiv;
        //public TextMeshProUGUI txt_dicaUtilizada;

        //testando
        //public bool dicaUtilizada;
    }

    public DicasAtributos[] objDica;

    public CircleManager circleManager;

    [SerializeField]
    private TextMeshProUGUI textCrsG_Insufic;

    //[SerializeField]
    //private FechaDica closeDica;

    private void Update()
    {
        for (int i = 0; i < objDica.Length; i++)
        {
            //atualiza text Dica
            //objDica[i].txtDica.text = objDica[i].dicaClick.ToString();
        }
    }

    void Start()
    {
        circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();
        textCrsG_Insufic.enabled = false;

        //inicializa Dicas
        for (int i = 0; i < objDica.Length; i++)
        {
            //objDica[i].txtDica.text = objDica[i].dicaClick.ToString();
            objDica[i].dicas.SetActive(false);
            objDica[i].textPriceDica.text = objDica[i].priceDica.ToString();
            //objDica[i].dicaClick = circleManager.circles[i].currentlife - objDica[i].qtdClickIni_Dica;
            //testando
            //objDica[i].dicaUtilizada = false;
            //objDica[i].txt_dicaUtilizada.enabled = false;
        }
    }

    void StartDicas()
    {

    }

    public void LiberaDica(int index)
    {
        //mudar para receber circleManager.circles[index].currentlife
        //objDica[index].dicaClick = objDica[index].qtdClickIni_Dica;
        //objDica[index].dicaClick = circleManager.circles[index].currentlife - objDica[index].qtdClickIni_Dica;

        //testando****
        //for (int i = 0; i <= index; i++)
        //{
        if (GAMEMANAGER.instance.cristalGreen >= objDica[index].priceDica
            /*&& circleManager.circles[index].currentlife >= objDica[index].dicaClick
            && objDica[index].dicaClick > 0*/)
        {
            print("index " + index);
            GAMEMANAGER.instance.DecrementaCristal(objDica[index].priceDica);
            objDica[index].dicas.SetActive(true);
            objDica[index].dicaAtiva = true;
            //desabilita btnDica
            objDica[index].btnAtiv.enabled = false;
            objDica[index].btnAtiv.interactable = false;
            //
            UIManager.instance.FechaPainel_Dica();
            //testando
            //objDica[index].dicaUtilizada = true;
            //objDica[index].txt_dicaUtilizada.enabled = true;
        }
        else if (GAMEMANAGER.instance.cristalGreen < objDica[index].priceDica)//cristais insufucientes para comprar a dica
        {
            textCrsG_Insufic.enabled = true;
            StartCoroutine(AlertaCristalInsufic());
        }
        //else if( objDica[index].dicaClick <= 0)//módulo com energia insuficiente para acessar a dica
        //{
        //    textCrsG_Insufic.text = "Módulo com energia insuficiente para acessar esta dica";
        //    textCrsG_Insufic.enabled = true;
        //    StartCoroutine(AlertaCristalInsufic());                
        //}
        //}
    }

    public void Desat_Dica(int index)
    {
        //Desativa Dica
        objDica[index].dicas.SetActive(false);
        objDica[index].dicaAtiva = false;
        //Habilita btnDica
        //if(objDica[index].dicaUtilizada == false)
        //{
        //    objDica[index].btnAtiv.enabled = true;
        //    objDica[index].btnAtiv.interactable = true;
        //}        
    }

    IEnumerator AlertaCristalInsufic()
    {
        yield return new WaitForSeconds(2);
        textCrsG_Insufic.enabled = false;
    }
}