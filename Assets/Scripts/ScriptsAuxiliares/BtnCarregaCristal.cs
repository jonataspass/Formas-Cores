using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnCarregaCristal : MonoBehaviour
{
    public Image bCrs1, bCrs2, bCrs3, bCrs4, bCrs5;
    public Button btnCargaCrs;
    public bool AdsOnceTime;
   
    //objeto controlado por outras variáveis no Scrip canvasObjsCircles
    public GameObject animeMaoCrs;

    public int cont;

    private void Start()
    {
        btnCargaCrs = GetComponent<Button>();        
        animeMaoCrs = GameObject.FindWithTag("animeMaoCrs");
        animeMaoCrs.SetActive(false);
        AdsOnceTime = false;
    }

    private void Update()
    {
        if (GAMEMANAGER.instance.lose == true && cont == 0)
        {
            cont = 1;
            DecrementaCrs();
            //btnCargaCrs.enabled = false;
            //anuncio
            if (AdsOnceTime == false && GAMEMANAGER.instance.num_tentativas > 0)
            {
                print("meteoro colidiu");
                UnityAds.instance.ShowAds();
                AdsOnceTime = true;
            }
        }
        else if (GAMEMANAGER.instance.lose == false && cont == 1)
        {
            cont = 0;
            btnCargaCrs.enabled = true;
        }

        AtualizaCrs();

        //trava iteração do btnCargaCrs
        if (GAMEMANAGER.instance.num_tentativas == 0)
        {
            //btnCargaCrs.enabled = false;
        }
        else if (GAMEMANAGER.instance.num_tentativas > 0 && GAMEMANAGER.instance.getExtra == true)
        {
            btnCargaCrs.enabled = true;
        }
    }    

    public void CarregaCrs()
    {
        //A carga ativa de cristais acabou e possui cristais suficientes...
        //para carregar totalmente e reiniciar o jogo;
        if (GAMEMANAGER.instance.CrsCargaAtiva == 0 && GAMEMANAGER.instance.cristalGreen >= 5)
        {

            GAMEMANAGER.instance.destTxtCanvas = false;
            GAMEMANAGER.instance.liberaCargaCrs = true;
            GAMEMANAGER.instance.DecrementaCristal(5);
            GAMEMANAGER.instance.CrsCargaAtiva = 5;
            GAMEMANAGER.instance.SalveCargaCrs(5);

            UIManager.instance.txt_Informativo.enabled = false;
            StartCoroutine(PegaMaoCrs());
            //reiniciar o jogo
            UIManager.instance.RestartLevel();
        }
        //A carga ativa de cristais acabou porém possui cristais suficientes...
        //para carregar abaixo da carga total e reiniciar o jogo;
        else if (GAMEMANAGER.instance.CrsCargaAtiva == 0 && GAMEMANAGER.instance.cristalGreen > 0
            && GAMEMANAGER.instance.cristalGreen < 5)
        {
            GAMEMANAGER.instance.CrsCargaAtiva = GAMEMANAGER.instance.cristalGreen;
            GAMEMANAGER.instance.DecrementaCristal(GAMEMANAGER.instance.cristalGreen);
            GAMEMANAGER.instance.SalveCargaCrs(GAMEMANAGER.instance.CrsCargaAtiva);
            
            UIManager.instance.txt_Informativo.enabled = false;
            StartCoroutine(PegaMaoCrs());
            //reiniciar o jogo
            UIManager.instance.RestartLevel();
        }
        //módulos ainda carregados
        else if (GAMEMANAGER.instance.CrsCargaAtiva > 0 && GAMEMANAGER.instance.cristalGreen >= 0)
        {
            GAMEMANAGER.instance.HabTex_Informativo("Sistema ainda com " + GAMEMANAGER.instance.CrsCargaAtiva
                                                     + " de carga" + "\n apenas possível carregar quando estiver com 0 de carga");
        }
        //A carga ativa de cristais acabou porém não possui cristais suficientes...
        //para carregar e reiniciar o jogo;
        else if (GAMEMANAGER.instance.CrsCargaAtiva == 0 && GAMEMANAGER.instance.cristalGreen == 0)
        {
            GAMEMANAGER.instance.destTxtCanvas = true;
            //GAMEMANAGER.instance.travaBtnReompensa = false;
            GAMEMANAGER.instance.HabTex_Informativo("Você não possui cristais suficientes" +
                "\n ganhe 30 cristais clicando no botão abaixo");
            //recompensa
            UIManager.instance.painel_Recompensa.SetActive(true);
            UIManager.instance.crs.enabled = true;
        }
    }

    void DecrementaCrs()
    {
        if (GAMEMANAGER.instance.CrsCargaAtiva > 0)
        {
            GAMEMANAGER.instance.CrsCargaAtiva -= 1;
            GAMEMANAGER.instance.SalveCargaCrs(GAMEMANAGER.instance.CrsCargaAtiva);
        }
    }

    void AtualizaCrs()
    {
        if (GAMEMANAGER.instance.CrsCargaAtiva == 5)
        {
            bCrs1.enabled = true;
            bCrs2.enabled = true;
            bCrs3.enabled = true;
            bCrs4.enabled = true;
            bCrs5.enabled = true;
        }
        else if (GAMEMANAGER.instance.CrsCargaAtiva == 4)
        {
            bCrs1.enabled = true;
            bCrs2.enabled = true;
            bCrs3.enabled = true;
            bCrs4.enabled = true;
            bCrs5.enabled = false;
        }
        else if (GAMEMANAGER.instance.CrsCargaAtiva == 3)
        {
            bCrs1.enabled = true;
            bCrs2.enabled = true;
            bCrs3.enabled = true;
            bCrs4.enabled = false;
            bCrs5.enabled = false;
        }
        else if (GAMEMANAGER.instance.CrsCargaAtiva == 2)
        {
            bCrs1.enabled = true;
            bCrs2.enabled = true;
            bCrs3.enabled = false;
            bCrs4.enabled = false;
            bCrs5.enabled = false;
        }
        else if (GAMEMANAGER.instance.CrsCargaAtiva == 1)
        {
            bCrs1.enabled = true;
            bCrs2.enabled = false;
            bCrs3.enabled = false;
            bCrs4.enabled = false;
            bCrs5.enabled = false;
        }
        else if (GAMEMANAGER.instance.CrsCargaAtiva == 0)
        {
            bCrs1.enabled = false;
            bCrs2.enabled = false;
            bCrs3.enabled = false;
            bCrs4.enabled = false;
            bCrs5.enabled = false;
        }
    }

    IEnumerator PegaMaoCrs()
    {
        yield return new WaitForSeconds(0.1f);
        animeMaoCrs.SetActive(false);
    }
}
