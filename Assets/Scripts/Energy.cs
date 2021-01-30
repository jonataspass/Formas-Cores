using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//aumentar o nivel de energia
public class Energy : MonoBehaviour
{
    public static Energy energY;
    public CircleManager circleManager;

    public int y;

    void Update()
    {
        if(y >= 0)
        transform.localScale = new Vector3(transform.localScale.x, y, transform.localScale.z );        
    }

    public void AtualizaEnergy(int a, int b)
    {
        y = circleManager.circles[a].circle[b].currentlife;
    }

}
