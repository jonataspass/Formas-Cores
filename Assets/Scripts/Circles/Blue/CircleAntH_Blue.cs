using UnityEngine;

public class CircleAntH_Blue : MonoBehaviour
{
    //tipo de shape
    public string tipo;
    //Index do vetor do obj
    public int indexVetCircles, indexVetCircle;
    //GameObject com Script Energy
    public Energy energCAntH_Gray;

    private void Start()
    {
        energCAntH_Gray.AtualizaEnergy(indexVetCircles, indexVetCircle);
    }

    //comportamento: quando o valos desta variável for diferente ao valor de uma variável... 
    //shapeCircles[i].atRot[x], significa que este obj rotaciona ao ser clicado.
    public int autoRot;

    private void OnMouseDown()
    {
        if (tipo == "CircleAntH_Blue")
        {
            //Teste                    //indexVet aqui
            GAMEMANAGER.instance.circles[indexVetCircles].circle[indexVetCircle].currentlife--;

            ////teste
            GAMEMANAGER.instance.NivelEnergy(indexVetCircles, indexVetCircle);

            energCAntH_Gray.AtualizaEnergy(indexVetCircles, indexVetCircle);

            for (int i = 0; i < GAMEMANAGER.instance.circles.Length; i++)
            {
                for (int j = 0; j < GAMEMANAGER.instance.circles[i].circle.Length; j++)
                {
                    if (GAMEMANAGER.instance.circles[i].circle[j].cor == "Blue")
                    {
                        if (GAMEMANAGER.instance.circles[i].circle[j].autoRot != autoRot)
                        {
                            if (GAMEMANAGER.instance.circles[indexVetCircles].circle[indexVetCircle].currentlife >= 0)
                                GAMEMANAGER.instance.circles[i].circle[j].angCircles += 45;
                        }
                    }
                }
            }
        }
    }    
}
