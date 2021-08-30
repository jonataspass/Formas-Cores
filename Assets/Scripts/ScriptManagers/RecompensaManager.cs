using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecompensaManager : MonoBehaviour
{

    [System.Serializable]
    public class RecompensasAtributes
    {
        public GameObject newRecompensa;
        //public int desbloq;
        public int totalCapacetesB, totalCapacetesP, totalCapacetesO;
        public int totalPts;
    }

    public RecompensasAtributes[] recompensasAtributes;
    //RecompensaSuporte[] newRecompensaSuporte;

    private void Start()
    {        
        InicializaRecompensa();
    }

    void InicializaRecompensa()
    {
        recompensasAtributes[0].totalCapacetesB = capB;//GAMEMANAGER.instance.recompensaCapaceteB;
        recompensasAtributes[1].totalCapacetesP = capP;//GAMEMANAGER.instance.recompensaCapaceteP;
        recompensasAtributes[2].totalCapacetesO = capO;//GAMEMANAGER.instance.recompensaCapaceteO;
        RecompensaCapacetes();
    }

    //variáveis de teste
    public int capB;
    public int capP;
    public int capO;
    void RecompensaCapacetes()
    {
        //bronze
        RecompensaSuporte newRecompensaSuporte_capaceteB = recompensasAtributes[0].newRecompensa.GetComponent<RecompensaSuporte>();

        if (recompensasAtributes[0].totalCapacetesB == 0)
        {
            newRecompensaSuporte_capaceteB.backgroundBloq.enabled = true;
            newRecompensaSuporte_capaceteB.backgroundAtivo.enabled = false;
        }
        else if (recompensasAtributes[0].totalCapacetesB > 0)
        {
            newRecompensaSuporte_capaceteB.backgroundBloq.enabled = false;
            newRecompensaSuporte_capaceteB.backgroundAtivo.enabled = true;

            if (recompensasAtributes[0].totalCapacetesB >= 25)
            {
                newRecompensaSuporte_capaceteB.star1.color = new Color(newRecompensaSuporte_capaceteB.star1.color.r, newRecompensaSuporte_capaceteB.star1.color.g, newRecompensaSuporte_capaceteB.star1.color.b, 1);
            }
            if (recompensasAtributes[0].totalCapacetesB >= 50)
            {
                newRecompensaSuporte_capaceteB.star2.color = new Color(newRecompensaSuporte_capaceteB.star1.color.r, newRecompensaSuporte_capaceteB.star1.color.g, newRecompensaSuporte_capaceteB.star1.color.b, 1);
            }
            if (recompensasAtributes[0].totalCapacetesB >= 100)
            {
                newRecompensaSuporte_capaceteB.star3.color = new Color(newRecompensaSuporte_capaceteB.star1.color.r, newRecompensaSuporte_capaceteB.star1.color.g, newRecompensaSuporte_capaceteB.star1.color.b, 1);
            }
            if (recompensasAtributes[0].totalCapacetesB >= 200)
            {
                newRecompensaSuporte_capaceteB.star4.color = new Color(newRecompensaSuporte_capaceteB.star1.color.r, newRecompensaSuporte_capaceteB.star1.color.g, newRecompensaSuporte_capaceteB.star1.color.b, 1);
            }
            if (recompensasAtributes[0].totalCapacetesB >= 300)
            {
                newRecompensaSuporte_capaceteB.star5.color = new Color(newRecompensaSuporte_capaceteB.star1.color.r, newRecompensaSuporte_capaceteB.star1.color.g, newRecompensaSuporte_capaceteB.star1.color.b, 1);
            }
        }

        //prata
        RecompensaSuporte newRecompensaSuporte_capaceteP = recompensasAtributes[1].newRecompensa.GetComponent<RecompensaSuporte>();

        if (recompensasAtributes[1].totalCapacetesP == 0)
        {
            newRecompensaSuporte_capaceteP.backgroundBloq.enabled = true;
            newRecompensaSuporte_capaceteP.backgroundAtivo.enabled = false;
        }
        else if (recompensasAtributes[1].totalCapacetesP > 0)
        {
            newRecompensaSuporte_capaceteP.backgroundBloq.enabled = false;
            newRecompensaSuporte_capaceteP.backgroundAtivo.enabled = true;

            if (recompensasAtributes[1].totalCapacetesP >= 25)
            {
                newRecompensaSuporte_capaceteP.star1.color = new Color(newRecompensaSuporte_capaceteP.star1.color.r, newRecompensaSuporte_capaceteP.star1.color.g, newRecompensaSuporte_capaceteP.star1.color.b, 1);
            }
            if (recompensasAtributes[1].totalCapacetesP >= 50)
            {
                newRecompensaSuporte_capaceteP.star2.color = new Color(newRecompensaSuporte_capaceteP.star1.color.r, newRecompensaSuporte_capaceteP.star1.color.g, newRecompensaSuporte_capaceteP.star1.color.b, 1);
            }
            if (recompensasAtributes[1].totalCapacetesP >= 100)
            {
                newRecompensaSuporte_capaceteP.star3.color = new Color(newRecompensaSuporte_capaceteP.star1.color.r, newRecompensaSuporte_capaceteP.star1.color.g, newRecompensaSuporte_capaceteP.star1.color.b, 1);
            }
            if (recompensasAtributes[1].totalCapacetesP >= 200)
            {
                newRecompensaSuporte_capaceteP.star4.color = new Color(newRecompensaSuporte_capaceteP.star1.color.r, newRecompensaSuporte_capaceteP.star1.color.g, newRecompensaSuporte_capaceteP.star1.color.b, 1);
            }
            if (recompensasAtributes[1].totalCapacetesP >= 300)
            {
                newRecompensaSuporte_capaceteP.star5.color = new Color(newRecompensaSuporte_capaceteP.star1.color.r, newRecompensaSuporte_capaceteP.star1.color.g, newRecompensaSuporte_capaceteP.star1.color.b, 1);
            }
        }

        //ouro
        RecompensaSuporte newRecompensaSuporte_capaceteO = recompensasAtributes[2].newRecompensa.GetComponent<RecompensaSuporte>();

        if (recompensasAtributes[2].totalCapacetesO == 0)
        {
            newRecompensaSuporte_capaceteO.backgroundBloq.enabled = true;
            newRecompensaSuporte_capaceteO.backgroundAtivo.enabled = false;
        }
        else if (recompensasAtributes[2].totalCapacetesO > 0)
        {
            newRecompensaSuporte_capaceteO.backgroundBloq.enabled = false;
            newRecompensaSuporte_capaceteO.backgroundAtivo.enabled = true;

            if (recompensasAtributes[2].totalCapacetesO >= 25)
            {
                newRecompensaSuporte_capaceteO.star1.color = new Color(newRecompensaSuporte_capaceteO.star1.color.r, newRecompensaSuporte_capaceteO.star1.color.g, newRecompensaSuporte_capaceteO.star1.color.b, 1);
            }
            if (recompensasAtributes[2].totalCapacetesO >= 50)
            {
                newRecompensaSuporte_capaceteO.star2.color = new Color(newRecompensaSuporte_capaceteO.star1.color.r, newRecompensaSuporte_capaceteO.star1.color.g, newRecompensaSuporte_capaceteO.star1.color.b, 1);
            }
            if (recompensasAtributes[2].totalCapacetesO >= 100)
            {
                newRecompensaSuporte_capaceteO.star3.color = new Color(newRecompensaSuporte_capaceteO.star1.color.r, newRecompensaSuporte_capaceteO.star1.color.g, newRecompensaSuporte_capaceteO.star1.color.b, 1);
            }
            if (recompensasAtributes[2].totalCapacetesO >= 200)
            {
                newRecompensaSuporte_capaceteO.star4.color = new Color(newRecompensaSuporte_capaceteO.star1.color.r, newRecompensaSuporte_capaceteO.star1.color.g, newRecompensaSuporte_capaceteO.star1.color.b, 1);
            }
            if (recompensasAtributes[2].totalCapacetesO >= 300)
            {
                newRecompensaSuporte_capaceteO.star5.color = new Color(newRecompensaSuporte_capaceteO.star1.color.r, newRecompensaSuporte_capaceteO.star1.color.g, newRecompensaSuporte_capaceteO.star1.color.b, 1);
            }
        }
    }

    void RecompensaExperiencia()
    {
        //rookie
        RecompensaSuporte newRecompensaSuporte_rookie = recompensasAtributes[3].newRecompensa.GetComponent<RecompensaSuporte>();

        if (recompensasAtributes[3].totalPts == 0)
        {
            newRecompensaSuporte_rookie.backgroundBloq.enabled = true;
            newRecompensaSuporte_rookie.backgroundAtivo.enabled = false;
        }
        else if (recompensasAtributes[3].totalPts > 0)
        {
            newRecompensaSuporte_rookie.backgroundBloq.enabled = false;
            newRecompensaSuporte_rookie.backgroundAtivo.enabled = true;

            if (recompensasAtributes[3].totalPts >= 60000)
            {
                newRecompensaSuporte_rookie.star1.color = new Color(newRecompensaSuporte_rookie.star1.color.r, newRecompensaSuporte_rookie.star1.color.g, newRecompensaSuporte_rookie.star1.color.b, 1);
            }
            if (recompensasAtributes[3].totalPts >= 1500000)
            {
                newRecompensaSuporte_rookie.star2.color = new Color(newRecompensaSuporte_rookie.star1.color.r, newRecompensaSuporte_rookie.star1.color.g, newRecompensaSuporte_rookie.star1.color.b, 1);
            }
            if (recompensasAtributes[3].totalPts >= 2700000)
            {
                newRecompensaSuporte_rookie.star3.color = new Color(newRecompensaSuporte_rookie.star1.color.r, newRecompensaSuporte_rookie.star1.color.g, newRecompensaSuporte_rookie.star1.color.b, 1);
            }
            if (recompensasAtributes[3].totalPts >= 4200000)
            {
                newRecompensaSuporte_rookie.star4.color = new Color(newRecompensaSuporte_rookie.star1.color.r, newRecompensaSuporte_rookie.star1.color.g, newRecompensaSuporte_rookie.star1.color.b, 1);
            }
            if (recompensasAtributes[3].totalPts >= 6000000)
            {
                newRecompensaSuporte_rookie.star5.color = new Color(newRecompensaSuporte_rookie.star1.color.r, newRecompensaSuporte_rookie.star1.color.g, newRecompensaSuporte_rookie.star1.color.b, 1);
            }
        }
    }
}
