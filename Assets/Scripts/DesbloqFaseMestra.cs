using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesbloqFaseMestra : MonoBehaviour
{
    public Button btnFaseMS_2, btnFaseMS_3;
    public GameObject itensBtnMS2, itensBtnMS3;

    private void Start()
    {
        DesblMestras();
    }

    //chave de desbloqueio é criada aqui pela primeira vez
    void DesblMestras()
    {
        //desbloqueia MCH        
        if (!ZPlayerPrefs.HasKey("DesbloqMCH"))
        {
            ZPlayerPrefs.SetInt("DesbloqMCH", 0);
        }
        else if (ZPlayerPrefs.HasKey("DesbloqMCH") && ZPlayerPrefs.GetInt("DesbloqMCH") == 1)
        {
            //desbloqueia MCH
                btnFaseMS_2.interactable = true;
                itensBtnMS2.SetActive(true);
        }        
    }
}
