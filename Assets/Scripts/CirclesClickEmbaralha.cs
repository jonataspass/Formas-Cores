using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CirclesClickEmbaralha : MonoBehaviour
{
    public int[] circCenHGray_ClicksEmbaralha, circCenAntHGray_ClicksEmbaralha, circCenCSGray_ClicksEmbaralha;
    public int[] circHRed_ClicksEmbaralha, circAntHRed_ClicksEmbaralha, circHRotAloneRed_ClicksEmbaralha, circAntHRotAloneRed_ClicksEmbaralha;
    public int[] circHBlue_ClicksEmbaralha, circAntHBlue_ClicksEmbaralha, circHRotAloneBlue_ClicksEmbaralha, circAntHRotAloneBlue_ClicksEmbaralha;
    public int[] circHOrange_ClicksEmbaralha, circAntHOrange_ClicksEmbaralha, circHRotAloneOrange_ClicksEmbaralha, circAntHRotAloneOrange_ClicksEmbaralha;
    
    public static int EmbaralhaCircles(string tipo, CirclesClickEmbaralha clicks)
    {
        for (int i = 0; i < tipo.Length; i++)
        {            
            //Red
            if (tipo == "CircleH_Red0")
            {
               
            }
            //Red
            //if (tipo == "CircleS_Red")
            //{             
            ////   Obs: criar um vetor com as variáveis de cclick que cada tipo pode receber
            ////     ou passar o método EmbaralhaCircle para o Script de cada tipo
            //    return clicks.circCenHGray_ClicksEmbaralha[i] * 45
            //          + clicks.circCenAntHGray_ClicksEmbaralha[i] * -45
            //          + clicks.circHRed_ClicksEmbaralha[i] * 45
            //          + clicks.circAntHRed_ClicksEmbaralha[i] * -45;                
            
            //}
            //if (tipo == "CircleH_Red" || tipo == "CircleAntH_Red")
            //{
            //    return clicks.circCenCSGray_ClicksEmbaralha[i] * 45
            //          + clicks.circCenHGray_ClicksEmbaralha[i] * 45
            //          + clicks.circCenAntHGray_ClicksEmbaralha[i] * -45;
            //}
            //if (tipo == "CircleHRotAlone_Red")
            //{
            //    return clicks.circCenHGray_ClicksEmbaralha[i] * 45
            //          + clicks.circCenAntHGray_ClicksEmbaralha[i] * -45
            //          + clicks.circHRed_ClicksEmbaralha[i] * 45
            //          + clicks.circAntHRed_ClicksEmbaralha[i] * -45
            //          + clicks.circHRotAloneRed_ClicksEmbaralha[i] * 45;
            //}
            //if (tipo == "CircleAntHRotAlone_Red")
            //{
            //    return clicks.circCenHGray_ClicksEmbaralha[i] * 45
            //          + clicks.circCenAntHGray_ClicksEmbaralha[i] * -45
            //          + clicks.circHRed_ClicksEmbaralha[i] * 45
            //          + clicks.circAntHRed_ClicksEmbaralha[i] * -45
            //          + clicks.circAntHRotAloneRed_ClicksEmbaralha[i] * -45;
            //}
            ////Blue
            //if (tipo == "CircleS_Blue")
            //{
            //    return clicks.circCenHGray_ClicksEmbaralha[i] * 45
            //          + clicks.circCenAntHGray_ClicksEmbaralha[i] * -45
            //          + clicks.circHBlue_ClicksEmbaralha[i] * 45
            //          + clicks.circAntHBlue_ClicksEmbaralha[i] * -45;
            //}
            //if (tipo == "CircleH_Blue" || tipo == "CircleAntH_Blue")
            //{
            //    return clicks.circCenHGray_ClicksEmbaralha[i] * 45
            //          + clicks.circCenAntHGray_ClicksEmbaralha[i] * -45;
            //}
            //if (tipo == "CircleHRotAlone_Blue")
            //{
            //    return clicks.circCenHGray_ClicksEmbaralha[i] * 45
            //          + clicks.circCenAntHGray_ClicksEmbaralha[i] * -45
            //          + clicks.circHBlue_ClicksEmbaralha[i] * 45
            //          + clicks.circAntHBlue_ClicksEmbaralha[i] * -45
            //          + clicks.circHRotAloneBlue_ClicksEmbaralha[i] * 45;
            //}
            //if (tipo == "CircleAntHRotAlone_Blue")
            //{
            //    return clicks.circCenHGray_ClicksEmbaralha[i] * 45
            //          + clicks.circCenAntHGray_ClicksEmbaralha[i] * -45
            //          + clicks.circHBlue_ClicksEmbaralha[i] * 45
            //          + clicks.circAntHBlue_ClicksEmbaralha[i] * -45
            //          + clicks.circHRotAloneBlue_ClicksEmbaralha[i] * -45;
            //}
            ////Orange
        }

        return 0;
    }
}
