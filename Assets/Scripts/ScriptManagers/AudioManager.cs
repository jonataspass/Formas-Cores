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

    //Música de fundo
    public AudioClip[] clips;
    public AudioSource backGround_Sound;
    public bool libera_BG_Sound;

    //testando clickBtn****TRABALHANDO AQUI
    public AudioSource clickBtn;

    //testando
    public Sprite Mute, Ative;

    //btn click sound
    //public Button btn_ClickSound;

    

    //btn Play cena Inicial
    public Button btn_Mute;

    private void Start()
    {
        libera_BG_Sound = true;
       // btn_ClickSound.onClick.AddListener(() => SoudBtn());
    }

    private void Update()
    {
        Play_backGround_Sound(libera_BG_Sound);
    }

    void Carrega(Scene cena, LoadSceneMode modo)
    {
        btn_Mute = GameObject.FindWithTag("btn_AtivaDesativa_cenaInicial").GetComponent<Button>();
        btn_Mute.onClick.AddListener(() => AtivaDesativa_backGround_Sound(libera_BG_Sound));
    }

    void Play_backGround_Sound(bool pl)
    {
        if (pl == true)
        {
            if (!backGround_Sound.isPlaying)
            {
                backGround_Sound.clip = clips[0];
                backGround_Sound.Play();
                btn_Mute.image.sprite = Ative;
            }
        }
        else if (pl == false)
        {
            backGround_Sound.Pause();
            btn_Mute.image.sprite = Mute;
        }
    }

    //Muta musica de fundo
    public void AtivaDesativa_backGround_Sound(bool pl)
    {

        if (pl == false)
        {
            libera_BG_Sound = true;
        }
        else if (pl == true)
        {
            libera_BG_Sound = false;
        }
    }

    //sound click btns
    public void SoudBtn()
    {
        clickBtn.Play();
    }
}
