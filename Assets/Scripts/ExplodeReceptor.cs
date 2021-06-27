using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeReceptor : MonoBehaviour
{
    public Animator exploRecepto;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("meteoro"))
        {
            Destroy(gameObject, 1.5f);
            exploRecepto.Play("Animeexplod");
        }
    }
}
