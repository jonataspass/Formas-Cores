using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMeteor : MonoBehaviour
{
    public Animator meteor;
    public Animator prefab_misselExplod;

    //public Animator anime_GeraMeteor;

    AudioSource soundExplod;
    public float vel;
    //Random velMeteor;
    public GameObject prefab_missel;
    GameObject new_Missel;

    public bool misselAtivo;

    public Collider2D collMeteor;


    private void Awake()
    {
        meteor = GetComponent<Animator>();
        meteor.Play("AnimeGera-meteor");
    }

    //public Transform[] meteoros_explodir;

    private void Start()
    {
        meteor = GetComponent<Animator>();

        //anime_GeraMeteor = GetComponent<Animator>();

        soundExplod = GetComponent<AudioSource>();

        collMeteor = GetComponent<Collider2D>();
        //collMeteor.enabled = false;
        StartCoroutine(LigaColl());

        int _vel = Random.Range(-10, -8);
        int _vel1 = Random.Range(8, 10);

        if (_vel == -10)
        {
            vel = _vel;
        }
        else
        {
            vel = _vel1;
        }
    }

    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * vel);
    }

    void explodMeteor()
    {
        meteor.Play("meteoroExplo");
        soundExplod.Play();
        Destroy(gameObject, 1.5f);
    }

    void ExplodMissel()
    {
        prefab_misselExplod.Play("Animeexplod");
        GAMEMANAGER.instance.misselAtivo = false;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("collReceptLazer") && GAMEMANAGER.instance.startGame == true)
        {
            explodMeteor();
            GAMEMANAGER.instance.lose = true;
            GAMEMANAGER.instance.canhaoAtivo = false;
            UIManager.instance.txt_Painel_WL.text = "You Lose!!!";
            UIManager.instance.txt_Painel_info_WL.text = "O módulo colidiu com um meteóro";
            UIManager.instance.UI_Win();
            UIManager.instance.habilitabBtnsCena = false;
            UIManager.instance.habilitaBtnRestart = false;
        }
        if (coll.CompareTag("missel"))
        {
            collMeteor.enabled = false;
            ExplodMissel();
            explodMeteor();
            Destroy(new_Missel);
        }
    }

    //testando****
    //dispara missel - relacionado com script Missel
    private void OnMouseDown()
    {
        if (GAMEMANAGER.instance.cargaMissel > 0 && GAMEMANAGER.instance.misselAtivo == false)
        {
            GAMEMANAGER.instance.misselAtivo = true;
            new_Missel = Instantiate(prefab_missel) as GameObject;
            GAMEMANAGER.instance.positioMeteor = transform.position;
            GAMEMANAGER.instance.speedMissel = GAMEMANAGER.instance.powerMissel;

            if (GAMEMANAGER.instance.cargaMissel > 0)
            {
                GAMEMANAGER.instance.cargaMissel--;
            }
        }
        else
            GAMEMANAGER.instance.HabTex_SemMissel("Sem mísseis");  
    }

    void Ligacoll()
    {
        if (GAMEMANAGER.instance.startGame == true)
        {
            collMeteor.enabled = true;
        }
    }

    IEnumerator LigaColl()
    {
        yield return new WaitForSeconds(5);
        collMeteor = GetComponent<Collider2D>();
        collMeteor.enabled = true;
    }
}
