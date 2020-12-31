using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicksEmbaralha_RedCircles
{
    public string Tipo;
    public int Clicks_CentralAntHRed;
    public int Clicks_HRed;
    public int Clicks_AntHRotAloneRed;

    public ClicksEmbaralha_RedCircles(string tipo, int clicks_CentralH, int clicks_HRed)
    {
        Tipo = tipo;
        Clicks_CentralAntHRed = clicks_CentralH;
        Clicks_HRed = clicks_HRed;
    }

    public ClicksEmbaralha_RedCircles(string tipo, int clicks_CentralH, int clicks_HRed, int clicks_AntHRotAloneRed)
    {
        Tipo = tipo;
        Clicks_CentralAntHRed = clicks_CentralH;
        Clicks_HRed = clicks_HRed;
        Clicks_AntHRotAloneRed = clicks_AntHRotAloneRed;
    }
}
