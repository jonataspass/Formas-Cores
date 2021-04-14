using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Objetivo deste script é repassar as informações add ao levelManager para os botões...
//como: Level e se o btn foi desbloqueado. 
public class BtnLevels : MonoBehaviour
{
    public Text textLevel_Btn;
    public int desbloq_Btn;

    //Capacetes
    public Image capacete_Bronze, capacete_Prata, capacete_Ouro;
    //informação interna utilizada na lógica
    public string realLevel;
}
