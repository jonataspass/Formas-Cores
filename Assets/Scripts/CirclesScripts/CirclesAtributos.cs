using UnityEngine;

[System.Serializable]
public class CirclesAtributos
{
    public string tipo;
    public bool ativa;
    public string cor;
    public int autoRot;
    public Transform circleTransform;
    public int StartAngCircles;
    public int angCircles;
    public int maxLife;
    public int currentlife;
    public int totalCurrentEnergy_H;
    public int totalCurrentEnergy_AH;
    public int sentRot;
    public int currentClicks;
    public ClicksCircles[] clicksR;    
}
