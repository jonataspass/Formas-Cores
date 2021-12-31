using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecompensaManager : MonoBehaviour
{
    //[0]CAPACETE DE BRONZE, [1]CAPACETE DE PRATA, [2]CAPACETE DE OURO, [3]ZR ROOKIE, [4]ZR INTERMEDIATE
    //[5]ZR VETERAN, [6]ZR EXPERT, [7]ZR MASTER, [8]ZR DESTROYER, [9]MSONE 100%COMPLETO, [10]MSTWO...

    [System.Serializable]
    public class RecompensasAtributes
    {
        public string tipoDe_recompensa;
        public GameObject newRecompensa;
        public int totalRecompensas;
        public TextMeshProUGUI txtTotal_caps;
    }

    public RecompensasAtributes[] recompensasAtributes;
    //RecompensaSuporte[] newRecompensaSuporte;

    private void Start()
    {        
        InicializaRecompensa();        
    }

    void InicializaRecompensa()
    {
        //CAP BRONZE
        recompensasAtributes[0].totalRecompensas = GAMEMANAGER.instance.recompensaCapaceteB;
        recompensasAtributes[0].txtTotal_caps.text = GAMEMANAGER.instance.recompensaCapaceteB.ToString() + "/41";
        //CAP PRATA
        recompensasAtributes[1].totalRecompensas = GAMEMANAGER.instance.recompensaCapaceteP;
        recompensasAtributes[1].txtTotal_caps.text = GAMEMANAGER.instance.recompensaCapaceteP.ToString() + "/41";
        //CAP OURO
        recompensasAtributes[2].totalRecompensas = GAMEMANAGER.instance.recompensaCapaceteO;
        recompensasAtributes[2].txtTotal_caps.text = GAMEMANAGER.instance.recompensaCapaceteO.ToString() + "/41";

        //rookie
        if(GAMEMANAGER.instance.totalScore_recompensas <= 150000)
        {
            recompensasAtributes[3].totalRecompensas = GAMEMANAGER.instance.totalScore_recompensas;
        }
        else if(GAMEMANAGER.instance.totalScore_recompensas > 150000)
        {
            recompensasAtributes[3].totalRecompensas = 150000;
        }
        
        recompensasAtributes[3].txtTotal_caps.text = ((100 * recompensasAtributes[3].totalRecompensas) / 150000).ToString() + "%";

        //intermediate
        if (GAMEMANAGER.instance.totalScore_recompensas < 400000)
        {
            recompensasAtributes[4].totalRecompensas = GAMEMANAGER.instance.totalScore_recompensas;
        }
        else if (GAMEMANAGER.instance.totalScore_recompensas > 400000)
        {
            recompensasAtributes[4].totalRecompensas = 400000;
        }

        recompensasAtributes[4].txtTotal_caps.text = ((100 * recompensasAtributes[4].totalRecompensas) / 400000).ToString() + "%";

        //veteran
        if (GAMEMANAGER.instance.totalScore_recompensas < 700000)
        {
            recompensasAtributes[5].totalRecompensas = GAMEMANAGER.instance.totalScore_recompensas;
        }
        else if (GAMEMANAGER.instance.totalScore_recompensas > 700000)
        {
            recompensasAtributes[5].totalRecompensas = 700000;
        }

        recompensasAtributes[5].txtTotal_caps.text = ((100 * recompensasAtributes[5].totalRecompensas) / 700000).ToString() + "%";

        //destroyer
        recompensasAtributes[6].totalRecompensas = GAMEMANAGER.instance.totalMeteorDestuidos;
        recompensasAtributes[6].txtTotal_caps.text = GAMEMANAGER.instance.totalMeteorDestuidos.ToString() + "/10000";

        //msOne
        if (/*GAMEMANAGER.instance.recompensaCapaceteO*/GAMEMANAGER.instance.capsOuro_msOne <= 25)
        {
            print(GAMEMANAGER.instance.capsOuro_msOne);
            recompensasAtributes[7].totalRecompensas = GAMEMANAGER.instance.capsOuro_msOne;
        }

        recompensasAtributes[7].txtTotal_caps.text = ((100 * recompensasAtributes[7].totalRecompensas) / 25).ToString() + "%";

        //msTwo
        if (GAMEMANAGER.instance.capsOuro_msTwo <= 16)
        {
            print(GAMEMANAGER.instance.capsOuro_msTwo);
            recompensasAtributes[8].totalRecompensas = GAMEMANAGER.instance.capsOuro_msTwo;
        }

        recompensasAtributes[8].txtTotal_caps.text = ((100 * recompensasAtributes[8].totalRecompensas) / 16).ToString() + "%";

        RecompensaCapacetes();
        RecompensaExperiencia();
        RecompensasEspeciais();
        NiveisDetonados();
    }

    void RecompensaCapacetes()
    {
        //bronze
        RecompensaSuporte newRecompensaSuporte_capaceteB = recompensasAtributes[0].newRecompensa.GetComponent<RecompensaSuporte>();

        if (recompensasAtributes[0].totalRecompensas == 0)
        {
            newRecompensaSuporte_capaceteB.backgroundBloq.enabled = true;
            newRecompensaSuporte_capaceteB.backgroundAtivo.enabled = false;
        }
        else if (recompensasAtributes[0].totalRecompensas > 0)
        {
            newRecompensaSuporte_capaceteB.backgroundBloq.enabled = false;
            newRecompensaSuporte_capaceteB.backgroundAtivo.enabled = true;

            if (recompensasAtributes[0].totalRecompensas >= 25)
            {
                newRecompensaSuporte_capaceteB.star1.color = new Color(newRecompensaSuporte_capaceteB.star1.color.r, newRecompensaSuporte_capaceteB.star1.color.g, newRecompensaSuporte_capaceteB.star1.color.b, 1);
            }
            if (recompensasAtributes[0].totalRecompensas >= 41)
            {
                newRecompensaSuporte_capaceteB.star2.color = new Color(newRecompensaSuporte_capaceteB.star1.color.r, newRecompensaSuporte_capaceteB.star1.color.g, newRecompensaSuporte_capaceteB.star1.color.b, 1);
            }
            //if (recompensasAtributes[0].totalRecompensas >= 100)
            //{
            //    newRecompensaSuporte_capaceteB.star3.color = new Color(newRecompensaSuporte_capaceteB.star1.color.r, newRecompensaSuporte_capaceteB.star1.color.g, newRecompensaSuporte_capaceteB.star1.color.b, 1);
            //}
            //if (recompensasAtributes[0].totalRecompensas >= 200)
            //{
            //    newRecompensaSuporte_capaceteB.star4.color = new Color(newRecompensaSuporte_capaceteB.star1.color.r, newRecompensaSuporte_capaceteB.star1.color.g, newRecompensaSuporte_capaceteB.star1.color.b, 1);
            //}
            //if (recompensasAtributes[0].totalRecompensas >= 300)
            //{
            //    newRecompensaSuporte_capaceteB.star5.color = new Color(newRecompensaSuporte_capaceteB.star1.color.r, newRecompensaSuporte_capaceteB.star1.color.g, newRecompensaSuporte_capaceteB.star1.color.b, 1);
            //}
        }

        //prata
        RecompensaSuporte newRecompensaSuporte_capaceteP = recompensasAtributes[1].newRecompensa.GetComponent<RecompensaSuporte>();

        if (recompensasAtributes[1].totalRecompensas == 0)
        {
            newRecompensaSuporte_capaceteP.backgroundBloq.enabled = true;
            newRecompensaSuporte_capaceteP.backgroundAtivo.enabled = false;
        }
        else if (recompensasAtributes[1].totalRecompensas > 0)
        {
            newRecompensaSuporte_capaceteP.backgroundBloq.enabled = false;
            newRecompensaSuporte_capaceteP.backgroundAtivo.enabled = true;

            if (recompensasAtributes[1].totalRecompensas >= 25)
            {
                newRecompensaSuporte_capaceteP.star1.color = new Color(newRecompensaSuporte_capaceteP.star1.color.r, newRecompensaSuporte_capaceteP.star1.color.g, newRecompensaSuporte_capaceteP.star1.color.b, 1);
            }
            if (recompensasAtributes[1].totalRecompensas >= 41)
            {
                newRecompensaSuporte_capaceteP.star2.color = new Color(newRecompensaSuporte_capaceteP.star1.color.r, newRecompensaSuporte_capaceteP.star1.color.g, newRecompensaSuporte_capaceteP.star1.color.b, 1);
            }
            //if (recompensasAtributes[1].totalRecompensas >= 100)
            //{
            //    newRecompensaSuporte_capaceteP.star3.color = new Color(newRecompensaSuporte_capaceteP.star1.color.r, newRecompensaSuporte_capaceteP.star1.color.g, newRecompensaSuporte_capaceteP.star1.color.b, 1);
            //}
            //if (recompensasAtributes[1].totalRecompensas >= 200)
            //{
            //    newRecompensaSuporte_capaceteP.star4.color = new Color(newRecompensaSuporte_capaceteP.star1.color.r, newRecompensaSuporte_capaceteP.star1.color.g, newRecompensaSuporte_capaceteP.star1.color.b, 1);
            //}
            //if (recompensasAtributes[1].totalRecompensas >= 300)
            //{
            //    newRecompensaSuporte_capaceteP.star5.color = new Color(newRecompensaSuporte_capaceteP.star1.color.r, newRecompensaSuporte_capaceteP.star1.color.g, newRecompensaSuporte_capaceteP.star1.color.b, 1);
            //}
        }

        //ouro
        RecompensaSuporte newRecompensaSuporte_capaceteO = recompensasAtributes[2].newRecompensa.GetComponent<RecompensaSuporte>();

        if (recompensasAtributes[2].totalRecompensas == 0)
        {
            newRecompensaSuporte_capaceteO.backgroundBloq.enabled = true;
            newRecompensaSuporte_capaceteO.backgroundAtivo.enabled = false;
        }
        else if (recompensasAtributes[2].totalRecompensas > 0)
        {
            newRecompensaSuporte_capaceteO.backgroundBloq.enabled = false;
            newRecompensaSuporte_capaceteO.backgroundAtivo.enabled = true;

            if (recompensasAtributes[2].totalRecompensas >= 25)
            {
                newRecompensaSuporte_capaceteO.star1.color = new Color(newRecompensaSuporte_capaceteO.star1.color.r, newRecompensaSuporte_capaceteO.star1.color.g, newRecompensaSuporte_capaceteO.star1.color.b, 1);
            }
            if (recompensasAtributes[2].totalRecompensas >= 41)
            {
                newRecompensaSuporte_capaceteO.star2.color = new Color(newRecompensaSuporte_capaceteO.star1.color.r, newRecompensaSuporte_capaceteO.star1.color.g, newRecompensaSuporte_capaceteO.star1.color.b, 1);
            }
            //if (recompensasAtributes[2].totalRecompensas >= 100)
            //{
            //    newRecompensaSuporte_capaceteO.star3.color = new Color(newRecompensaSuporte_capaceteO.star1.color.r, newRecompensaSuporte_capaceteO.star1.color.g, newRecompensaSuporte_capaceteO.star1.color.b, 1);
            //}
            //if (recompensasAtributes[2].totalRecompensas >= 200)
            //{
            //    newRecompensaSuporte_capaceteO.star4.color = new Color(newRecompensaSuporte_capaceteO.star1.color.r, newRecompensaSuporte_capaceteO.star1.color.g, newRecompensaSuporte_capaceteO.star1.color.b, 1);
            //}
            //if (recompensasAtributes[2].totalRecompensas >= 300)
            //{
            //    newRecompensaSuporte_capaceteO.star5.color = new Color(newRecompensaSuporte_capaceteO.star1.color.r, newRecompensaSuporte_capaceteO.star1.color.g, newRecompensaSuporte_capaceteO.star1.color.b, 1);
            //}
        }
    }

    void RecompensaExperiencia()
    {
        //rookie
        RecompensaSuporte newRecompensaSuporte_rookie = recompensasAtributes[3].newRecompensa.GetComponent<RecompensaSuporte>();

        if (recompensasAtributes[3].totalRecompensas < 10500)
        {
            newRecompensaSuporte_rookie.backgroundBloq.enabled = true;
            newRecompensaSuporte_rookie.backgroundAtivo.enabled = false;
        }
        else if (recompensasAtributes[3].totalRecompensas >= 10500)
        {
            newRecompensaSuporte_rookie.backgroundBloq.enabled = false;
            newRecompensaSuporte_rookie.backgroundAtivo.enabled = true;

            if (recompensasAtributes[3].totalRecompensas >= 75000)
            {
                newRecompensaSuporte_rookie.star1.color = new Color(newRecompensaSuporte_rookie.star1.color.r, newRecompensaSuporte_rookie.star1.color.g, newRecompensaSuporte_rookie.star1.color.b, 1);
            }
            if (recompensasAtributes[3].totalRecompensas >= 150000)
            {
                newRecompensaSuporte_rookie.star2.color = new Color(newRecompensaSuporte_rookie.star1.color.r, newRecompensaSuporte_rookie.star1.color.g, newRecompensaSuporte_rookie.star1.color.b, 1);
            }
            //if (recompensasAtributes[3].totalRecompensas >= 2700000)
            //{
            //    newRecompensaSuporte_rookie.star3.color = new Color(newRecompensaSuporte_rookie.star1.color.r, newRecompensaSuporte_rookie.star1.color.g, newRecompensaSuporte_rookie.star1.color.b, 1);
            //}
            //if (recompensasAtributes[3].totalRecompensas >= 4200000)
            //{
            //    newRecompensaSuporte_rookie.star4.color = new Color(newRecompensaSuporte_rookie.star1.color.r, newRecompensaSuporte_rookie.star1.color.g, newRecompensaSuporte_rookie.star1.color.b, 1);
            //}
            //if (recompensasAtributes[3].totalRecompensas >= 6000000)
            //{
            //    newRecompensaSuporte_rookie.star5.color = new Color(newRecompensaSuporte_rookie.star1.color.r, newRecompensaSuporte_rookie.star1.color.g, newRecompensaSuporte_rookie.star1.color.b, 1);
            //}
        }

        //intermediate
        RecompensaSuporte newRecompensaSuporte_intermediate = recompensasAtributes[4].newRecompensa.GetComponent<RecompensaSuporte>();

        if (recompensasAtributes[4].totalRecompensas < 200000)
        {
            newRecompensaSuporte_intermediate.backgroundBloq.enabled = true;
            newRecompensaSuporte_intermediate.backgroundAtivo.enabled = false;
        }
        else if (recompensasAtributes[4].totalRecompensas >= 200000)
        {
            newRecompensaSuporte_intermediate.backgroundBloq.enabled = false;
            newRecompensaSuporte_intermediate.backgroundAtivo.enabled = true;

            if (recompensasAtributes[4].totalRecompensas >= 300000)
            {
                newRecompensaSuporte_intermediate.star1.color = new Color(newRecompensaSuporte_intermediate.star1.color.r, newRecompensaSuporte_intermediate.star1.color.g, newRecompensaSuporte_intermediate.star1.color.b, 1);
            }
            if (recompensasAtributes[4].totalRecompensas >= 400000)
            {
                newRecompensaSuporte_intermediate.star2.color = new Color(newRecompensaSuporte_intermediate.star1.color.r, newRecompensaSuporte_intermediate.star1.color.g, newRecompensaSuporte_intermediate.star1.color.b, 1);
            }
            //if (recompensasAtributes[4].totalRecompensas >= 400000)
            //{
            //    newRecompensaSuporte_intermediate.star3.color = new Color(newRecompensaSuporte_intermediate.star1.color.r, newRecompensaSuporte_intermediate.star1.color.g, newRecompensaSuporte_intermediate.star1.color.b, 1);
            //}
            //if (recompensasAtributes[4].totalRecompensas >= 4200000)
            //{
            //    newRecompensaSuporte_intermediate.star4.color = new Color(newRecompensaSuporte_intermediate.star1.color.r, newRecompensaSuporte_intermediate.star1.color.g, newRecompensaSuporte_intermediate.star1.color.b, 1);
            //}
            //if (recompensasAtributes[4].totalRecompensas >= 6000000)
            //{
            //    newRecompensaSuporte_intermediate.star5.color = new Color(newRecompensaSuporte_intermediate.star1.color.r, newRecompensaSuporte_intermediate.star1.color.g, newRecompensaSuporte_intermediate.star1.color.b, 1);
            //}
        }

        //veteran
        RecompensaSuporte newRecompensaSuporte_veteran = recompensasAtributes[5].newRecompensa.GetComponent<RecompensaSuporte>();

        if (recompensasAtributes[5].totalRecompensas < 500000)
        {
            newRecompensaSuporte_veteran.backgroundBloq.enabled = true;
            newRecompensaSuporte_veteran.backgroundAtivo.enabled = false;
        }
        else if (recompensasAtributes[5].totalRecompensas >= 500000)
        {
            newRecompensaSuporte_veteran.backgroundBloq.enabled = false;
            newRecompensaSuporte_veteran.backgroundAtivo.enabled = true;

            if (recompensasAtributes[5].totalRecompensas >= 600000)
            {
                newRecompensaSuporte_veteran.star1.color = new Color(newRecompensaSuporte_intermediate.star1.color.r, newRecompensaSuporte_veteran.star1.color.g, newRecompensaSuporte_veteran.star1.color.b, 1);
            }
            if (recompensasAtributes[5].totalRecompensas >= 725000)
            {
                newRecompensaSuporte_veteran.star2.color = new Color(newRecompensaSuporte_intermediate.star1.color.r, newRecompensaSuporte_veteran.star1.color.g, newRecompensaSuporte_veteran.star1.color.b, 1);
            }
            //if (recompensasAtributes[4].totalRecompensas >= 400000)
            //{
            //    newRecompensaSuporte_intermediate.star3.color = new Color(newRecompensaSuporte_intermediate.star1.color.r, newRecompensaSuporte_intermediate.star1.color.g, newRecompensaSuporte_intermediate.star1.color.b, 1);
            //}
            //if (recompensasAtributes[4].totalRecompensas >= 4200000)
            //{
            //    newRecompensaSuporte_intermediate.star4.color = new Color(newRecompensaSuporte_intermediate.star1.color.r, newRecompensaSuporte_intermediate.star1.color.g, newRecompensaSuporte_intermediate.star1.color.b, 1);
            //}
            //if (recompensasAtributes[4].totalRecompensas >= 6000000)
            //{
            //    newRecompensaSuporte_intermediate.star5.color = new Color(newRecompensaSuporte_intermediate.star1.color.r, newRecompensaSuporte_intermediate.star1.color.g, newRecompensaSuporte_intermediate.star1.color.b, 1);
            //}
        }
    }

    void RecompensasEspeciais()
    {
        //destroyer
        RecompensaSuporte newRecompensaSuporte_destroyer = recompensasAtributes[6].newRecompensa.GetComponent<RecompensaSuporte>();

        if (recompensasAtributes[6].totalRecompensas < 100)
        {
            newRecompensaSuporte_destroyer.backgroundAtivo.enabled = false;
            newRecompensaSuporte_destroyer.backgroundBloq.enabled = true;
        }
        else if (recompensasAtributes[6].totalRecompensas >= 100)
        {
            newRecompensaSuporte_destroyer.backgroundBloq.enabled = false;
            newRecompensaSuporte_destroyer.backgroundAtivo.enabled = true;

            if (recompensasAtributes[6].totalRecompensas >= 5000)
            {
                newRecompensaSuporte_destroyer.star1.color = new Color(newRecompensaSuporte_destroyer.star1.color.r, newRecompensaSuporte_destroyer.star1.color.g, newRecompensaSuporte_destroyer.star1.color.b, 1);
            }
            if (recompensasAtributes[6].totalRecompensas >= 10000)
            {
                newRecompensaSuporte_destroyer.star2.color = new Color(newRecompensaSuporte_destroyer.star1.color.r, newRecompensaSuporte_destroyer.star1.color.g, newRecompensaSuporte_destroyer.star1.color.b, 1);
            }
            //if (recompensasAtributes[3].totalRecompensas >= 2700000)
            //{
            //    newRecompensaSuporte_rookie.star3.color = new Color(newRecompensaSuporte_rookie.star1.color.r, newRecompensaSuporte_rookie.star1.color.g, newRecompensaSuporte_rookie.star1.color.b, 1);
            //}
            //if (recompensasAtributes[3].totalRecompensas >= 4200000)
            //{
            //    newRecompensaSuporte_rookie.star4.color = new Color(newRecompensaSuporte_rookie.star1.color.r, newRecompensaSuporte_rookie.star1.color.g, newRecompensaSuporte_rookie.star1.color.b, 1);
            //}
            //if (recompensasAtributes[3].totalRecompensas >= 6000000)
            //{
            //    newRecompensaSuporte_rookie.star5.color = new Color(newRecompensaSuporte_rookie.star1.color.r, newRecompensaSuporte_rookie.star1.color.g, newRecompensaSuporte_rookie.star1.color.b, 1);
            //}
        }
    }

    void NiveisDetonados()
    {
        //msOne
        RecompensaSuporte newRecompensaSuporte_msOne = recompensasAtributes[7].newRecompensa.GetComponent<RecompensaSuporte>();

        if (recompensasAtributes[7].totalRecompensas < 1)
        {
            newRecompensaSuporte_msOne.backgroundAtivo.enabled = false;
            newRecompensaSuporte_msOne.backgroundBloq.enabled = true;
        }
        else if (recompensasAtributes[7].totalRecompensas >= 1)
        {
            newRecompensaSuporte_msOne.backgroundBloq.enabled = false;
            newRecompensaSuporte_msOne.backgroundAtivo.enabled = true;
        }
        if (recompensasAtributes[7].totalRecompensas >= 25)
        {
            newRecompensaSuporte_msOne.star1.color = new Color(newRecompensaSuporte_msOne.star1.color.r, newRecompensaSuporte_msOne.star1.color.g, newRecompensaSuporte_msOne.star1.color.b, 1);
        }

        //msTwo
        RecompensaSuporte newRecompensaSuporte_msTwo = recompensasAtributes[8].newRecompensa.GetComponent<RecompensaSuporte>();

        if (recompensasAtributes[8].totalRecompensas < 1)
        {
            newRecompensaSuporte_msTwo.backgroundBloq.enabled = true;
            newRecompensaSuporte_msTwo.backgroundAtivo.enabled = false;
        }
        else if (recompensasAtributes[8].totalRecompensas >= 1)
        {
            newRecompensaSuporte_msTwo.backgroundBloq.enabled = false;
            newRecompensaSuporte_msTwo.backgroundAtivo.enabled = true;
        }
        if (recompensasAtributes[8].totalRecompensas >= 16)
        {
            newRecompensaSuporte_msTwo.star1.color = new Color(newRecompensaSuporte_msTwo.star1.color.r, newRecompensaSuporte_msOne.star1.color.g, newRecompensaSuporte_msTwo.star1.color.b, 1);
        }
    }
}
