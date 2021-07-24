using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimeMoedaZ : MonoBehaviour
{
    Rigidbody2D rb;
    public float f;

    public TextMeshProUGUI txt_prefabAnimeMoeda;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        txt_prefabAnimeMoeda = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.up * f);
        Destroy(gameObject, 1.5f);
    }
}
