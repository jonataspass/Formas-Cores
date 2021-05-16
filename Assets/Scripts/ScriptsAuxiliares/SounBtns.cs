using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TRABALHANDO AQUI*****
public class SounBtns : MonoBehaviour
{
    public Button btnClick_sound;   

    private void Start()
    {
        btnClick_sound.onClick.AddListener(() => AudioManager.instance.SoudBtn());
    }
}
