using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Renomear Esta classe de CIRCLESMANAGER
public class GAMEMANAGER : MonoBehaviour
{
    public static GAMEMANAGER instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Circles[] circles;

    private void Start()
    {
        InicializaAngs();       
    }

    private void Update()
    {
        //Atualiza ângulos dos objs
        AtualizaAngs();
    }

    //Inicializa os ângulos dos objs circles
    void InicializaAngs()
    {
        for (int i = 0; i < circles.Length; i++)
        {
            for(int j = 0; j < circles[i].circle.Length; j++)
            {
                if(circles[i].circle[j].ativa == true)
                {
                    circles[i].circle[j].angCircles = circles[i].circle[j].StartAngCircles;                      
                }
            }            
        }
    }

    //Atualiza ângulos dos objs
    void AtualizaAngs()
    {
        for(int i = 0; i < circles.Length; i++)
        {
            for(int j = 0; j < circles[i].circle.Length; j++)
            {
                if(circles[i].circle[j] != null && circles[i].circle[j].tipo != "CircleCAntH_Gray")
                {
                    circles[i].circle[j].circleTransform.transform.rotation = Quaternion.Euler(0, 0, circles[i].circle[j].angCircles);
                }
            }
        }
    }

    //NÍVEL DE ENERGIA CONTROLA A QUANTIDADE DE CLICKS POR OBJ
    public void NivelEnergy(int indexCircles, int indexCircle)
    {
        ////o cáculo do enery_Y é uma regra de 3
        Vector3 energy_Y = new Vector3(7, circles[indexCircles].circle[indexCircle].currentlife
                                         * 7 / circles[indexCircles].circle[indexCircle].maxLife, 1);

        circles[indexCircles].circle[indexCircle].currentlife = (int)energy_Y.y;
    }

    
}


