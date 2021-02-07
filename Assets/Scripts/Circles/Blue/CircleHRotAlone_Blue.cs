using UnityEngine;

public class CircleHRotAlone_Blue : MonoBehaviour
{
    //tipo de shape
    public string tipo;

    //comportamento: quando o valos desta variável é igual ao valor de uma variável... 
    //shapeCircles[i].atRot[x], significa que este obj rotaciona ao ser clicado.
    public int autoRot;

    private void OnMouseDown()
    {
        if (tipo == "CircleHRotAlone_Blue")
        {
            //for (int i = 0; i < GAMEMANAGER.instance.circles.Length; i++)
            //{
            //    for (int j = 0; j < GAMEMANAGER.instance.circles[i].circle.Length; j++)
            //    {
            //        if (GAMEMANAGER.instance.circles[i].circle[j].cor == "Blue")
            //        {
            //            if (GAMEMANAGER.instance.circles[i].circle[j].autoRot == autoRot)
            //            {
            //                GAMEMANAGER.instance.circles[i].circle[j].angCircles -= 45;
            //            }
            //        }
            //    }
            //}
        }
    }
}
