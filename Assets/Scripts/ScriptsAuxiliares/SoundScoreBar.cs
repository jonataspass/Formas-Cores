using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScoreBar : MonoBehaviour
{
    //audios
    public AudioClip[] clips;
    public AudioSource effectsObjs;

    private void Start()
    {
        //testando****
        GameObject.FindWithTag("scoreBar").GetComponent<Collider2D>();
        //audio
        effectsObjs = GetComponent<AudioSource>();
    }


    //testando****
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("soundCapacete"))
        {
            //effect sound
            effectsObjs.clip = clips[0];
            effectsObjs.Play();
        }
    }
}
