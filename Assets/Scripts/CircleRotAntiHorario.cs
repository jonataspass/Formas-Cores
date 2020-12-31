using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotAntiHorario : MonoBehaviour
{
    public float limit;
    public float vel;

    private void Start()
    {
        //GAMEMANAGER.instance.angCircle[0] = 
    }

    void Update()
    {
        //Baixar na Asset store o Dotween para criar movimentos
        //teste
        //if (limit <= GAMEMANAGER.instance.angRot)
        //{
        //    limit += vel * Time.deltaTime;
        //    GAMEMANAGER.instance.circle[0].transform.rotation = Quaternion.Euler(0, 0, limit);
        //}

        //print(GAMEMANAGER.instance.circle[0].transform.rotation.z + "angCircle" + GAMEMANAGER.instance.angCircle[0]);


        ////testar este
        //if (limit <= GAMEMANAGER.instance.angRot)
        //{
        //    limit += vel * Time.deltaTime;
        //    GAMEMANAGER.instance.circle[0].transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler());
        //}
    }
}
