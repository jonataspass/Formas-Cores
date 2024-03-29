﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraMeteor : MonoBehaviour
{
    public GameObject prefab_meteor;
    GameObject new_meteor;
    public bool tocando;
    int num_Meteors;
    public int num_MaxMeteor;
    int randMeteor;

    //new adiction
    public bool portalMeteorAtivo;

    void Start()
    {
       // num_MaxMeteor = Random.Range(1, 7);

        if(tocando == false)
        Gera_Meteor();
    }

    void Gera_Meteor()
    {
        if ((num_Meteors < num_MaxMeteor && tocando == false) || portalMeteorAtivo == true)
        {
            new_meteor = Instantiate(prefab_meteor) as GameObject;

            new_meteor.transform.position = gameObject.transform.position;
            num_Meteors += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("collReceptLazer") && GAMEMANAGER.instance.startGame == true)
        {
            //randMeteor = Random.Range(0, 7);
            tocando = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("collReceptLazer") && GAMEMANAGER.instance.startGame == true)
        {
            tocando = false;

            //if (randMeteor != 0)
            //{
                Gera_Meteor();
            //}
        }
    }
}
