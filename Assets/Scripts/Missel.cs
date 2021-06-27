using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missel : MonoBehaviour
{
    Rigidbody2D rb;

    public float rotateSpeed;

    public Vector2 currentposition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //soundExplod = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        DisparaMissel();
        Destroy(gameObject, 3);
    }

    void DisparaMissel()
    {         
        Vector2 direction = GAMEMANAGER.instance.positioMeteor - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        //missel recebe força
        rb.velocity = transform.up * GAMEMANAGER.instance.speedMissel; 
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {       
        if (coll.CompareTag("meteoro"))
        {            
            Destroy(gameObject);
        }
    }
}