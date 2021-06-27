using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraExtrameteor : MonoBehaviour
{
    public GameObject extraPrefab_meteor;
    GameObject extranew_meteor;

    public int numExtra_meteor;

    public float setPosMeteorX, setPosMeteorY;

    private void Update()
    {
        GeraextraMeteor();
    }

    void GeraextraMeteor()
    {
        //print("1");
        if (GAMEMANAGER.instance.cargaMissel > 0)
        {
            //print("2");
            if (GAMEMANAGER.instance.numextrameteor < GAMEMANAGER.instance.cargaMissel)
            {
                //print("3");
                extranew_meteor = Instantiate(extraPrefab_meteor) as GameObject;

                extranew_meteor.transform.position = new Vector2(gameObject.transform.position.x * setPosMeteorX, gameObject.transform.position.y * setPosMeteorY) ;
                GAMEMANAGER.instance.numextrameteor ++;
                setPosMeteorX += 0.5f;
                setPosMeteorY += 0.5f;
            }
        }
    }
}
