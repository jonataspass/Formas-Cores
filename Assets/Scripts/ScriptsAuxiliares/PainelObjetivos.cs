using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PainelObjetivos : MonoBehaviour
{
    public GameObject painelObjetivos;
    public TextMeshProUGUI txtObjetivos;

    private void Start()
    {
        painelObjetivos = GameObject.FindWithTag("painelObjetivos");
        txtObjetivos = GameObject.FindWithTag("txtClicksObjetivo").GetComponent<TextMeshProUGUI>();

        //inicializa text de objetivo
        txtObjetivos.text = "  Alinhe os módulos e colete " + GAMEMANAGER.instance.circleManager.totalMoedasLevel
            + " moedasZ em " + GAMEMANAGER.instance.circleManager.totalClicks + " clicks!";
        StartCoroutine(Desabilitaobjetivos());
    }

    IEnumerator Desabilitaobjetivos()
    {
        yield return new WaitForSeconds(5);
        painelObjetivos.SetActive(false);
    }
}
