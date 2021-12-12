using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecompensaSuporte : MonoBehaviour
{    
    //Imagens recopensa bloqueada e desbloqueada
    public Image backgroundBloq, backgroundAtivo;
    //Stars
    public Image star1, star2, star3, star4, star5;
    //text como adquirir recompensa
    public GameObject txtRecompensa;
    public TextMeshProUGUI txtAtivo;

    public RecompensaManager recompensaManager;

    Collider2D collRecompensa;

    private void Start()
    {
        collRecompensa = GetComponent<Collider2D>();
        txtAtivo.enabled = false;
    }

    private void OnMouseOver()
    {
        //Mostra txt capacete de bronze
        if (collRecompensa.CompareTag("b"))
        {
            if (recompensaManager.recompensasAtributes[0].totalRecompensas == 0)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.enabled = true;
                txtAtivo.text = "BRONZE ZR HELMET \n Libere essa recompensa com 01 capacete de bronze";
            }
            else if (recompensaManager.recompensasAtributes[0].totalRecompensas > 0)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.text = "BRONZE ZR HELMET";
                txtAtivo.enabled = true;
            }                
        }
        //Mostra txt capacete de prata
        else if (collRecompensa.CompareTag("p"))
        {
            if (recompensaManager.recompensasAtributes[1].totalRecompensas == 0)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.enabled = true;
                txtAtivo.text = "SILVER ZR HELMET \n Libere essa recompensa com 01 capacete de prata";
            }
            else if (recompensaManager.recompensasAtributes[1].totalRecompensas > 0)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.text = "SILVER ZR HELMET";
                txtAtivo.enabled = true;
            }
        }
        //Mostra txt capacete de ouro
        else if (collRecompensa.CompareTag("o"))
        {
            if (recompensaManager.recompensasAtributes[2].totalRecompensas == 0)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.enabled = true;
                txtAtivo.text = "GOLD ZR HELMET \n Libere essa recompensa com 01 capacete de gold";
            }
            else if (recompensaManager.recompensasAtributes[2].totalRecompensas > 0)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.text = "GOLD ZR HELMET";
                txtAtivo.enabled = true;
            }
        }
        //Mostra txt rookie
        else if (collRecompensa.CompareTag("rookie"))
        {
            if (recompensaManager.recompensasAtributes[3].totalRecompensas < 10500)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.enabled = true;
                txtAtivo.text = "ZR Rookie \n Libere essa recompensa fazendo 10500 pontos";
            }
            else if (recompensaManager.recompensasAtributes[3].totalRecompensas >= 10500)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.text = "ZR Rookie";
                txtAtivo.enabled = true;
            }
        }
        //Mostra txt intermediate
        else if (collRecompensa.CompareTag("intermediate"))
        {
            if (recompensaManager.recompensasAtributes[4].totalRecompensas < 200000)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.enabled = true;
                txtAtivo.text = "ZR Intermediate \n Libere essa recompensa fazendo 200000 pontos";
            }
            else if (recompensaManager.recompensasAtributes[4].totalRecompensas >= 200000)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.text = "ZR Intermediate";
                txtAtivo.enabled = true;
            }
        }
        //Mostra txt veteran
        else if (collRecompensa.CompareTag("veteran"))
        {
            if (recompensaManager.recompensasAtributes[5].totalRecompensas < 500000)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.enabled = true;
                txtAtivo.text = "ZR Veteran \n Libere essa recompensa fazendo 500000 pontos";
            }
            else if (recompensaManager.recompensasAtributes[5].totalRecompensas >= 500000)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.text = "ZR Veteran";
                txtAtivo.enabled = true;
            }
        }
        //Mostra txt destroyer
        else if (collRecompensa.CompareTag("destroyer"))
        {
            if (recompensaManager.recompensasAtributes[6].totalRecompensas < 100)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.enabled = true;
                txtAtivo.text = "ZR Destroyer \n Libere essa recompensa destruindo 100 meteoros";
            }
            else if (recompensaManager.recompensasAtributes[6].totalRecompensas >= 100)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.text = "ZR Destroyer";
                txtAtivo.enabled = true;
            }
        }
        //Mostra txt msOne
        else if (collRecompensa.CompareTag("msOne"))
        {
            if (recompensaManager.recompensasAtributes[7].totalRecompensas == 0)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.enabled = true;
                txtAtivo.text = "MSOne \n Libere essa recompensa concluindo um level do nivel MSOne";
            }
            else if (recompensaManager.recompensasAtributes[7].totalRecompensas >= 1)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.text = "MSOne";
                txtAtivo.enabled = true;
            }
        }
        //Mostra txt msTwo
        else if (collRecompensa.CompareTag("msTwo"))
        {
            if (recompensaManager.recompensasAtributes[8].totalRecompensas == 0)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.enabled = true;
                txtAtivo.text = "MSTwo \n Libere essa recompensa concluindo um level do nivel MSTwo";
            }
            else if (recompensaManager.recompensasAtributes[8].totalRecompensas >= 1)
            {
                txtRecompensa.SetActive(true);
                txtAtivo.text = "MSTwo";
                txtAtivo.enabled = true;
            }
        }
    }

    private void OnMouseExit()
    {
        txtRecompensa.SetActive(false);
        txtAtivo.enabled = false;
    }
}
