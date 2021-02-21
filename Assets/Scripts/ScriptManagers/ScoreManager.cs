using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

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
    }

    //pontuação máxima possível de atingir "objetivo 100%"
    public int maxScore;
    //variáveis de pontuação
    public int ptsMarcados;
    public float sentPts;
    //pontuação apresentada como text
    public Text currentScore;
    //variável que incrementa a barra de score
    public float xScale;
    //Barra de score
    public Image scoreBar;

    private void Start()
    {
        scoreBar.rectTransform.localScale = new Vector3(ptsMarcados, transform.localScale.y, transform.localScale.z);
    }

    private void Update()
    {
        ShowScore();
    }

    //Atualiza a pontuação a barra de score
    void ShowScore()
    {
        if (sentPts < ptsMarcados)
        {
            if (sentPts < 100)
            {
                sentPts++;
                xScale = sentPts / 100 / maxScore;
                currentScore.text = sentPts.ToString();

                if (xScale > 1)
                {
                    xScale = 1;
                    scoreBar.rectTransform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
                }

                scoreBar.rectTransform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                sentPts += 10;
                xScale = sentPts / 100 / maxScore;
                currentScore.text = sentPts.ToString();

                if (xScale > 1)
                {
                    xScale = 1;
                    scoreBar.rectTransform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
                }

                scoreBar.rectTransform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
