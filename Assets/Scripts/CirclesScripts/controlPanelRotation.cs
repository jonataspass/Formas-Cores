using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlPanelRotation : MonoBehaviour
{
    //ângulo do painel de orientaão de rotação
    private SpriteRenderer angPanel;
    //cor do ângulo de rotação
    public Color colorAngPanel;
    public Color tempAngPanel;

    private void Start()
    {
        angPanel = GetComponentInChildren<SpriteRenderer>();
        
        //DesativaColl(gameObject.GetComponent<Collider2D>());
        //StartCoroutine(AtivaColl(gameObject.GetComponent<Collider2D>()));
    }

    private void Update()
    {
        //print(angPanel.color);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("collReceptLazer"))
        {
            tempAngPanel = angPanel.color;            
            angPanel.color = new Color(colorAngPanel.r, colorAngPanel.g, colorAngPanel.b, colorAngPanel.a + 135);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("collReceptLazer"))
        {
            angPanel.color = tempAngPanel;
        }
    }
}
