using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script nao utilizado
public class AtivaCollReceptor : MonoBehaviour
{    
    void Start()
    {
        StartCoroutine(LigaCollMoeda());
    }

    IEnumerator LigaCollMoeda()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(true);
    }
}
