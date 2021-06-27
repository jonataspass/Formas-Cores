using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarcaPostions : MonoBehaviour
{
    public Text marcaPos;
    int numPos;
    Collider2D collThis;
    
    void Start()
    {
        marcaPos = GetComponent<Text>();
        collThis = GetComponent<Collider2D>();
        collThis.enabled = false;
        StartCoroutine(ligaColl());
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("collReceptLazer"))
        {
            numPos++;
            marcaPos.text = numPos.ToString();
        }
            
    }

    IEnumerator ligaColl()
    {
        yield return new WaitForSeconds(1);
        collThis.enabled = true;
    }
}
