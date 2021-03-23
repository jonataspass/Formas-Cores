using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += Carrega;
    }

    public AudioClip[] clips;
    public AudioSource backGround_Sound;
    public bool libera_BG_Sound;

    //btn Play cena Inicial
    public Button btn_AtivaDesativa_CenaInicial;

    private void Start()
    {
        libera_BG_Sound = true;
    }

    private void Update()
    {
        Play_backGround_Sound(libera_BG_Sound);
    }

    void Carrega(Scene cena, LoadSceneMode modo)
    {
        btn_AtivaDesativa_CenaInicial = GameObject.FindWithTag("btn_AtivaDesativa_cenaInicial").GetComponent<Button>();
        btn_AtivaDesativa_CenaInicial.onClick.AddListener(() => AtivaDesativa_backGround_Sound(libera_BG_Sound));
    }

    void Play_backGround_Sound(bool pl)
    {
        if (pl == true)
        {
            if (!backGround_Sound.isPlaying)
            {
                backGround_Sound.clip = clips[0];
                backGround_Sound.Play();
            }
        }
        else if(pl == false)
        {
            backGround_Sound.Pause();
        }
    }

    public void AtivaDesativa_backGround_Sound(bool pl)
    {
        
        if (pl == false)
        {
            //pl = true;
            libera_BG_Sound = true;
        }
        else if (pl == true)
        {
            //pl = false;
            libera_BG_Sound = false;
        }
    }
}
