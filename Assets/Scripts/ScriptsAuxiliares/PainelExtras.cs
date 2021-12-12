using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PainelExtras : MonoBehaviour
{    
    public TextMeshProUGUI precoTentarNovamente;
    //[SerializeField]
    //bool ativaExtra;

    //add ao btnDesistir no inspector da unity
    public void BtnDesistir()
    {
        GAMEMANAGER.instance.travaPainelExtras = false;
        GAMEMANAGER.instance.liberalose = true;
        UIManager.instance.painel_CompraExtra.SetActive(false);
        GAMEMANAGER.instance.VerificaLose();
    }

    //compra item tentativas Extras
    public void BuyTryExtra()
    {
        if (GAMEMANAGER.instance.qtd_moedaSalvas >= GAMEMANAGER.instance.extraTry * 100)
        {            
            GAMEMANAGER.instance.num_tentativas = GAMEMANAGER.instance.extraTry;
            GAMEMANAGER.instance.qtd_moedaSalvas -= (GAMEMANAGER.instance.extraTry * 100);
            GAMEMANAGER.instance.SalvaMoedasZ(GAMEMANAGER.instance.qtd_moedaSalvas);
            UIManager.instance.painel_CompraExtra.SetActive(false);
            UIManager.instance.txtTipoItem.enabled = false;
            UIManager.instance.imgExtra.enabled = false;
            UIManager.instance.txtExtra.enabled = false;            

            //randon recebe 2 para que não seja ofertado a opção de compra de tentativas extras novamente
            GAMEMANAGER.instance.liberaExtras = 2;

            //usou tentativas extras
            GAMEMANAGER.instance.getExtra = true;
            RepeteLevel.instance.SaveRepetLevel();
            RepeteLevel.instance.HabilitaDica_R();
            GAMEMANAGER.instance.numTentativasExtras += GAMEMANAGER.instance.extraTry;

            if (GAMEMANAGER.instance.numTotalmeteor > 0)
            {
                GAMEMANAGER.instance.cargaMissel = GAMEMANAGER.instance.numTotalmeteor;
            }
        }
        else
        {
            GAMEMANAGER.instance.HabTex_Informativo("Voçê não possui moedas Z suficientes");
            GAMEMANAGER.instance.travaPainelExtras = false;
            UIManager.instance.painel_CompraExtra.SetActive(false);
            UIManager.instance.txtTipoItem.enabled = false;
            UIManager.instance.imgExtra.enabled = false;
            UIManager.instance.txtExtra.enabled = false;
        }
    }
}
