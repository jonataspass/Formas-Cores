using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleManager : MonoBehaviour
{
    public static CircleManager instance;

    //Atributos das circles
    public Circles[] circles;

    //teste rotações**
    //public float vel;
    //public float limit;

    private void Awake()
    {
        IniCirclesAng();
    }

    private void Start()
    {
       /// IniCirclesAng();
    }

    private void Update()
    {
        //AtualizaAngs();
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(3);
        }

    }

    //Atualiza ângulos dos objs
    //Desativado***
    void AtualizaAngs()
    {
        for (int i = 0; i < circles.Length; i++)
        {
            for (int j = 0; j < circles[i].circle.Length; j++)
            {
                if (circles[i].circle[j] != null && circles[i].circle[j].tipo != "CCS_Gray")
                {
                    //circles[i].circle[j].circleTransform.transform.rotation = Quaternion.Euler(0, 0, circles[i].circle[j].angCircles);
                    //teste**
                    //if (limit <= circles[i].circle[j].angCircles)
                    //{
                    //    limit += vel * Time.deltaTime;
                    //    circles[i].circle[j].circleTransform.transform.rotation = Quaternion.Euler(0, 0, limit);
                    //}
                }
            }
        }
    }

    //NÍVEL DE ENERGIA; CONTROLA A QUANTIDADE DE CLICKS POR OBJ
    public void NivelEnergy(int indexCircles, int indexCircle)
    {
        //O cáculo do enery_Y é uma regra de 3
        Vector3 energy_Y = new Vector3(7, circles[indexCircles].circle[indexCircle].currentlife
                                         * 7 / circles[indexCircles].circle[indexCircle].maxLife, 1);

        circles[indexCircles].circle[indexCircle].currentlife = (int)energy_Y.y;
    }

    //Inicializa os aângulos das Circles
    void IniCirclesAng()
    {
        for (int i = 0; i < circles.Length; i++)
        {
            for (int j = 0; j < circles[i].circle.Length; j++)
            {
                if (circles[i].circle[j].ativa == true)
                {
                    circles[i].circle[j].angCircles += circles[i].circle[j].StartAngCircles;

                    for (int a = 0; a < circles[i].circle[j].clicksR.Length; a++)
                    {
                        circles[i].circle[j].angCircles += circles[i].circle[j].clicksR[a].clicks * 45;
                    }
                }
            }
        }
    }

}
