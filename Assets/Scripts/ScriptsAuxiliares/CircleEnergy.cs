using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnergy : MonoBehaviour
{
    public SpriteRenderer Energy;
    public Color alphaEnergy;
    public float alphaAjuste;
    public CircleManager circleManager;

    public float alphaEnergyTemp;
    public float vel;

    private void Start()
    {
        circleManager = GameObject.FindWithTag("circleManager").GetComponent<CircleManager>();
        Energy = GetComponent<SpriteRenderer>();
    }

    public void AtualizaCircleEnergy(int indexVetCircles)
    {
        if(alphaEnergyTemp > (float)circleManager.circles[indexVetCircles].currentlife / 10 + alphaAjuste)
        {
            alphaEnergyTemp -= 0.01f * Time.deltaTime * vel;
            alphaEnergy.a = alphaEnergyTemp;
            Energy.color = new Color(alphaEnergy.r, alphaEnergy.g, alphaEnergy.b, alphaEnergy.a);
        }
        else if(alphaEnergyTemp < (float)circleManager.circles[indexVetCircles].currentlife / 10 + alphaAjuste)
        {
            alphaEnergyTemp += 0.01f * Time.deltaTime * vel;
            alphaEnergy.a = alphaEnergyTemp;
            Energy.color = new Color(alphaEnergy.r, alphaEnergy.g, alphaEnergy.b, alphaEnergy.a);
        }
    }
}