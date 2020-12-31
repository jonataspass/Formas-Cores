using UnityEngine;

public class CirclesRotation : MonoBehaviour
{
    public void RotacionaAllCircles(string tipo)
    {
        for (int i = 0; i < GAMEMANAGER.instance.shapeCircles.Length; i++)
        {
            //Passar para a classe Gray_CircleCH
            //Rotacionadas CircleCH_Gray
            if (tipo == "CircleCH_Gray")
            {
                //Circle Simples Vermelha
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleS_Red")
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                //Circle Simples Blue
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleS_Blue")
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                //Circle Simples Orange
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleS_Orange")
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                //CircleH_Red
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleH_Red" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                //CircleAntH_Red
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntH_Red" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                //CircleH_Blue
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleH_Blue" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                //CircleAntH_blue
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntH_Blue" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                //CircleH_Orange
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleH_Orange" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                //CircleAntH_Orange
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntH_Orange" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                //CircleHRotAlone_Red
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleHRotAlone_Red" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                //CircleAntHRotAlone_Red
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntHRotAlone_Red" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                //CircleHRotAlone_Blue
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleHRotAlone_Blue" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                //CircleAntHRotAlone_Blue
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntHRotAlone_Blue" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                //CircleHRotAlone_Orange
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleHRotAlone_Orange" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                //CircleAntHRotAlone_Orange
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntHRotAlone_Orange" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
            }
            //*****************Fim Rotações Gray_Central**********************************************

            //*****************Início Rotações Red****************************************************
            //Rotacionadas por CircleH_Red
            if (tipo == "CircleH_Red")
            {
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleS_Red" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 0)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] -= 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntH_Red" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] -= 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleHRotAlone_Red" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] -= 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntHRotAlone_Red" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] -= 45;
                    }
                }
            }
            //Circles rotacionadas por CircleAntH_Red
            if (tipo == "CircleAntH_Red")
            {
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleS_Red" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 0)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleH_Red" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleHRotAlone_Red" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntHRotAlone_Red" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
            }
            if (tipo == "CircleHRotAlone_Red")
            {
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleHRotAlone_Red" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] -= 45;
                    }
                }

            }
            if (tipo == "CircleAntHRotAlone_Red")
            {
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntHRotAlone_Red" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }

            }
            //*****************Fim Rotações Red********************************************************

            //*****************Início Rotações Blue****************************************************
            //Circles rotacionadas por CirclesH_Blue
            if (tipo == "CircleH_Blue")
            {
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleS_Blue" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 0)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] -= 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntH_Blue" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] -= 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleHRotAlone_Blue" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] -= 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntHRotAlone_Blue" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] -= 45;
                    }
                }
            }
            if (tipo == "CircleAntH_Blue")
            {
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleS_Blue" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 0)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleH_Blue" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleHRotAlone_Blue" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntHRotAlone_Blue" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
            }
            if (tipo == "CircleHRotAlone_Blue")
            {
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleHRotAlone_Blue" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] -= 45;
                    }
                }

            }
            if (tipo == "CircleAntHRotAlone_Blue")
            {
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntHRotAlone_Blue" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }

            }
            //*****************Fim Rotações Blue****************************************************

            //*****************Início Rotações Orange****************************************************
            
            //Circles rotacionadas por CircleH_Orange
            if (tipo == "CircleH_Orange")
            {
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleS_Orange" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 0)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] -= 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntH_Orange" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] -= 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleHRotAlone_Orange" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] -= 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntHRotAlone_Orange" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] -= 45;
                    }
                }
            }
            //Circles rotacionadas por CircleAntH_Orange
            if (tipo == "CircleAntH_Orange")
            {
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleS_Orange" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 0)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleH_Orange" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleHRotAlone_Orange" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntHRotAlone_Orange" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }
            }
            if (tipo == "CircleHRotAlone_Orange")
            {
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleHRotAlone_Orange" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == 1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] -= 45;
                    }
                }

            }
            if (tipo == "CircleAntHRotAlone_Orange")
            {
                if (GAMEMANAGER.instance.shapeCircles[i].tipo == "CircleAntHRotAlone_Orange" && GAMEMANAGER.instance.shapeCircles[i].sentidoRot == -1)
                {
                    for (int j = 0; j < GAMEMANAGER.instance.shapeCircles[i].angCircles.Length; j++)
                    {
                        GAMEMANAGER.instance.shapeCircles[i].angCircles[j] += 45;
                    }
                }

            }
            //*****************Fim Rotações Orange********************************************************
        }
    }
}
