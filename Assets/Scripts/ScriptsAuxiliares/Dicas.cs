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
        //preço de cada dica
        public int priceDica;
        public TextMeshProUGUI textPriceDica;
        public Button btnAtiv;
    }

    public DicasAtributos[] objDica;

    public CircleManager circleManager;

    [SerializeField]
    private TextMeshProUGUI textCrsG_Insufic;

    [SerializeField]
    private TextMeshProUGUI txtBtnReiniciar;
    [SerializeField]
    GameObject btnMoedaReiniciar;

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
        }
    }

    public void LiberaDica(int index)
    {
        if (GAMEMANAGER.instance.cristalGreen >= objDica[index].priceDica)
        {
            GAMEMANAGER.instance.DecrementaCristal(objDica[index].priceDica);
            objDica[index].dicas.SetActive(true);
            objDica[index].dicaAtiva = true;
            objDica[index].btnAtiv.enabled = false;
            objDica[index].btnAtiv.interactable = false;

            UIManager.instance.FechaPainel_Dica();

            UIManager.instance.btn_restart.interactable = true;
            UIManager.instance.dicaComprada = true;
            btnMoedaReiniciar.SetActive(false);
            txtBtnReiniciar.text = "Usar dica";
            
        }
        else if (GAMEMANAGER.instance.cristalGreen < objDica[index].priceDica)//cristais insufucientes para comprar a dica
        {
            textCrsG_Insufic.enabled = true;
            StartCoroutine(AlertaCristalInsufic());
        }
    }

    public void Desat_Dica(int index)
    {
        //Desativa Dica
        objDica[index].dicas.SetActive(false);
        objDica[index].dicaAtiva = false;
    }

    IEnumerator AlertaCristalInsufic()
    {
        yield return new WaitForSeconds(2);
        textCrsG_Insufic.enabled = false;
    }
}