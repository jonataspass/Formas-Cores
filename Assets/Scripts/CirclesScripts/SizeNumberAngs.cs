using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeNumberAngs : MonoBehaviour
{
    public SpriteRenderer number;

    private void Start()
    {
        number = GetComponent<SpriteRenderer>();
        number.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("collReceptLazer"))
        {
            transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, 1);
            number.enabled = true;
            //transform.position = new Vector2(posMod.transform.position.x, posMod.transform.position.y);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("collReceptLazer"))
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1);
            number.enabled = false;
            //transform.position = new Vector2(transform.position.x, transform.position.y);
        }
    }
}
