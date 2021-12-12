using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPts_Caps : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI txtPts_MCS, txtPts_MCH, txtPts_MCAH;

    [SerializeField]
    private TextMeshProUGUI txt_capBronze_MCS, txt_capPrata_MCS, txt_capOuro_MCS;

    [SerializeField]
    private TextMeshProUGUI txt_capBronze_MCH, txt_capPrata_MCH, txt_capOuro_MCH;

    [SerializeField]
    private TextMeshProUGUI txt_capBronze_MCAH, txt_capPrata_MCAH, txt_capOuro_MCAH;

    [SerializeField]
    TextMeshProUGUI totalScore, totalCristais, totalMoedas, totalMeteors;

    public LevelManager levelManager;

    private int[] ptsVal;
    public int[] capsB, capsP, capsO;
    int totalCapsB, totalCapsP, totalCapsO;
    int totalPts_recompensas;

    private void Update()
    {
        txtPts_MCS.text = ptsVal[0].ToString();

        if (GAMEMANAGER.instance.desbloMS2 == 1)
            txtPts_MCH.text = ptsVal[1].ToString();

        if (GAMEMANAGER.instance.desbloMS3 == 1)
            txtPts_MCAH.text = ptsVal[2].ToString();

        //repassa total de cada tipo de capacete para o script RecompensaManager
        GAMEMANAGER.instance.recompensaCapaceteB = totalCapsB;
        GAMEMANAGER.instance.recompensaCapaceteP = totalCapsP;
        GAMEMANAGER.instance.recompensaCapaceteO = totalCapsO;
        //repassa total de pts de todas as fases mestras
        GAMEMANAGER.instance.totalScore_recompensas = totalPts_recompensas;
        totalScore.text = totalPts_recompensas.ToString();
        totalCristais.text = ZPlayerPrefs.GetInt("cristaisGreen_Total").ToString();
        totalMoedas.text = ZPlayerPrefs.GetInt("qtdMoedas").ToString();
        totalMeteors.text = ZPlayerPrefs.GetInt("meteorsDestruidos").ToString();
    }

    private void Awake()
    {
        ZPlayerPrefs.Initialize("157JONATAS", "157157157");           

        ptsVal = new int[3];
        capsB = new int[3];
        capsP = new int[3];
        capsO = new int[3];

        //Laço qu percorre os levels de cada Mestra
        for (int i = 0; i < 25; i++)//i < 25 pois cada mestra  possui apenas 25 leveis 
        {
            //Pts do score Mestra
            ptsVal[0] += ZPlayerPrefs.GetInt("Level" + (i + 1) + "_MCSscore");
            ptsVal[1] += ZPlayerPrefs.GetInt("Level" + (i + 1) + "_MCHscore");
            ptsVal[2] += ZPlayerPrefs.GetInt("Level" + (i + 1) + "_MCAHscore");

            //Capacetes Mestra
            capsB[0] += ZPlayerPrefs.GetInt("Level" + (i + 1) + "_MCScapaceteBronze");
            capsP[0] += ZPlayerPrefs.GetInt("Level" + (i + 1) + "_MCScapacetePrata");
            capsO[0] += ZPlayerPrefs.GetInt("Level" + (i + 1) + "_MCScapaceteOuro");
            capsB[1] += ZPlayerPrefs.GetInt("Level" + (i + 1) + "_MCHcapaceteBronze");
            capsP[1] += ZPlayerPrefs.GetInt("Level" + (i + 1) + "_MCHcapacetePrata");
            capsO[1] += ZPlayerPrefs.GetInt("Level" + (i + 1) + "_MCHcapaceteOuro");
            capsB[2] += ZPlayerPrefs.GetInt("Level" + (i + 1) + "_MCAHcapaceteBronze");
            capsP[2] += ZPlayerPrefs.GetInt("Level" + (i + 1) + "_MCAHcapacetePrata");
            capsO[2] += ZPlayerPrefs.GetInt("Level" + (i + 1) + "_MCAHcapaceteOuro");            
        }

        //total capacetes
        totalCapsB += capsB[0] + capsB[1] + capsB[2];
        totalCapsP += capsP[0] + capsP[1] + capsP[2];
        totalCapsO += capsO[0] + capsO[1] + capsO[2];

        //total pontos
        totalPts_recompensas += ptsVal[0] + ptsVal[1] + ptsVal[2];

        //inicia desbloqueada fase mestra1 
        txt_capBronze_MCS.SetText(capsB[0].ToString());
        txt_capPrata_MCS.SetText(capsP[0].ToString());
        txt_capOuro_MCS.SetText(capsO[0].ToString());

        //desbloqueia fase mestra2
        if (GAMEMANAGER.instance.desbloMS2 == 1)
        {
            txt_capBronze_MCH.SetText(capsB[1].ToString());
            txt_capPrata_MCH.SetText(capsP[1].ToString());
            txt_capOuro_MCH.SetText(capsO[1].ToString());
        }
        //desbloqueia fase mestra3
        if (GAMEMANAGER.instance.desbloMS3 == 1)
        {
            txt_capBronze_MCAH.SetText(capsB[2].ToString());
            txt_capPrata_MCAH.SetText(capsP[2].ToString());
            txt_capOuro_MCAH.SetText(capsO[2].ToString());
        }

        //carrega capacetes de ouro no script recompensaManager
        GAMEMANAGER.instance.capsOuro_msOne = capsO[0];
        GAMEMANAGER.instance.capsOuro_msTwo = capsO[1];

        //ZPlayerPrefs.DeleteAll();

        //AtualizaTxt_ptsMestas();
    }
}
