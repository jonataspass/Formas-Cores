using UnityEngine;

//script adicionado ao obj CirclesAntH_Gray.
//rotaciona todos os shapes tipo Circle com a parte externa em cinza no sentido anti-horário.
public class CircleCAntH_Gray : MonoBehaviour
{
    //tipo de shape
    public string tipo;
    //Index do vetor do obj
    public int indexVetCircles;
    //GameObject com Script Energy
    public Energy energCAntH_Gray;

    private void Start()
    {
        energCAntH_Gray.AtualizaEnergy(indexVetCircles);
    }

    private void OnMouseDown()
    {
        if (tipo == "CircleCAntH_Gray")
        {
            //    //Teste                    //indexVet aqui
            //    GAMEMANAGER.instance.circles[indexVetCircles].circle[indexVetCircle].currentlife--;

            //    ////teste
            //    GAMEMANAGER.instance.NivelEnergy(indexVetCircles, indexVetCircle);


            //    energCAntH_Gray.AtualizaEnergy(indexVetCircles, indexVetCircle);

            //    for (int i = 0; i < GAMEMANAGER.instance.circles.Length; i++)
            //    {
            //        for (int j = 0; j < GAMEMANAGER.instance.circles[i].circle.Length; j++)
            //        {
            //            //Se ainda tiver energia rotaciona objs
            //            if (GAMEMANAGER.instance.circles[indexVetCircles].circle[indexVetCircle].currentlife >= 0)
            //            {
            //                GAMEMANAGER.instance.circles[i].circle[j].angCircles += 45;
            //            }
            //        }
            //    }
        }
    }
}
