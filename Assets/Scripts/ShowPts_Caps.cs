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

    public LevelManager levelManager;

    private int[] ptsVal;
    private int[] capsB, capsP, capsO;

    private void Update()
    {
        txtPts_MCS.text = ptsVal[0].ToString();
        txtPts_MCH.text = ptsVal[1].ToString();
        txtPts_MCAH.text = ptsVal[2].ToString();

        //repassa total de cada tipo de capacete para o script RecompensaManager
        GAMEMANAGER.instance.recompensaCapaceteB = capsB[0];
    }

    private void Awake()
    {
        ZPlayerPrefs.Initialize("157JONATAS", "157157157");

        //txt Pts Mestra
        txtPts_MCS = GameObject.FindWithTag("txtPts_MCS").GetComponent<TextMeshProUGUI>();
        txtPts_MCH = GameObject.FindWithTag("txtPts_MCH").GetComponent<TextMeshProUGUI>();
        txtPts_MCAH = GameObject.FindWithTag("txtPts_MCAH").GetComponent<TextMeshProUGUI>();

        //txt Capacetes Mestra
        txt_capBronze_MCS = GameObject.FindWithTag("txtCapsB_MCS").GetComponent<TextMeshProUGUI>();
        txt_capPrata_MCS = GameObject.FindWithTag("txtCapsP_MCS").GetComponent<TextMeshProUGUI>();
        txt_capOuro_MCS = GameObject.FindWithTag("txtCapsO_MCS").GetComponent<TextMeshProUGUI>();
        txt_capBronze_MCH = GameObject.FindWithTag("txtCapsB_MCH").GetComponent<TextMeshProUGUI>();
        txt_capPrata_MCH = GameObject.FindWithTag("txtCapsP_MCH").GetComponent<TextMeshProUGUI>();
        txt_capOuro_MCH = GameObject.FindWithTag("txtCapsO_MCH").GetComponent<TextMeshProUGUI>();
        txt_capBronze_MCAH = GameObject.FindWithTag("txtCapsB_MCAH").GetComponent<TextMeshProUGUI>();
        txt_capPrata_MCAH = GameObject.FindWithTag("txtCapsP_MCAH").GetComponent<TextMeshProUGUI>();
        txt_capOuro_MCAH = GameObject.FindWithTag("txtCapsO_MCAH").GetComponent<TextMeshProUGUI>();

        ptsVal = new int[3];
        capsB = new int[3];
        capsP = new int[3];
        capsO = new int[3];

        //Laço qu percorre os levels de cada Mestra
        for (int i = 0; i < 10; i++)//i < 2 levels por mestra por enquanto
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

        txt_capBronze_MCS.SetText(capsB[0].ToString());
        txt_capPrata_MCS.SetText(capsP[0].ToString());
        txt_capOuro_MCS.SetText(capsO[0].ToString());
        txt_capBronze_MCH.SetText(capsB[1].ToString());
        txt_capPrata_MCH.SetText(capsP[1].ToString());
        txt_capOuro_MCH.SetText(capsO[1].ToString());
        txt_capBronze_MCAH.SetText(capsB[2].ToString());
        txt_capPrata_MCAH.SetText(capsP[2].ToString());
        txt_capOuro_MCAH.SetText(capsO[2].ToString());

        //ZPlayerPrefs.DeleteAll();
    }
}
