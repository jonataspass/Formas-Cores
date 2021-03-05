using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeNumberAngs : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("collReceptLazer"))
        {
            transform.localScale = new Vector3(transform.localScale.x * 3, transform.localScale.y * 3, 1);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("collReceptLazer"))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
