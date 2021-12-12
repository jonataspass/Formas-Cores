using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FechaBtnRecompensa : MonoBehaviour
{
    [SerializeField]
    Button fechaBtnRecompensa;

    void Start()
    {
        fechaBtnRecompensa = gameObject.GetComponent<Button>();
        fechaBtnRecompensa.onClick.AddListener(() => FechaRecompensa());
    } 
    
    void FechaRecompensa()
    {
        UIManager.instance.painel_Recompensa.SetActive(false);
        UIManager.instance.crs.enabled = false;
    }
}
