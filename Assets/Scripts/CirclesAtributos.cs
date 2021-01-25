using UnityEngine;

[System.Serializable]
public class CirclesAtributos
{
    public string tipo;
    public bool ativa;
    public string cor;
    //melhorar lógica de autoRot
    public int autoRot;
    public Transform circleTransform;
    public int StartAngCircles;
    public int angCircles;
    public int maxLife;
    public int currentlife;    

    //teste
    public int sentRot;
    public ClicksCircles[] clicksR;
}
