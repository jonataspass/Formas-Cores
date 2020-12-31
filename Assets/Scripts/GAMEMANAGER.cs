using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GAMEMANAGER : MonoBehaviour
{
    public static GAMEMANAGER instance;

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

    //variáveis de rotação
    public CirclesAtributos[] shapeCircles;

    //variáveis UI
    //public Text cliksTextCircleCentral;
    //public Text cliksTextCircleH;
    //public int clicksCircleCentral, clicksCircleH, clicksCircleAntH, clicksCircleAlone;

    //variáveis para embaralhar os objs
    public int circleCentralClicksEmbaralha;
    public int circleHRedclicksEmbaralha;
    public int circleAntHRotAlone_Red;

    private void Start()
    {
        InicializaAngs();           

        //passar este para UImanager
        //Pega objs Text de quantidade de clicks (Nível de energia)
        //textCircleCentralClicks = GameObject.FindWithTag("textCircleCentral").GetComponent<Text>();
        //textCircleHClicks = GameObject.FindWithTag("textCircleH").GetComponent<Text>();
    }

    private void Update()
    {
        //Atualiza ângulos dos objs
        AtualizaAngs();

        //Atualiza níveis de energia dos objs 
        //cliksTextCircleCentral.text = clicksCircleCentral.ToString();
        //cliksTextCircleH.text = clicksCircleH.ToString();
    }

    //Inicializa os ângulos dos objs circles
    void InicializaAngs()
    {
        ClicksEmbaralha_RedCircles embCircle;

        for (int i = 0; i < shapeCircles.Length; i++)
        {
            //Verifica se o obj está ativo na cena
            if(shapeCircles[i].ativa == true)
            {
                //Circle Simples Vermelha; rotação neutra = 0 -> rotaciona nos dois sentidos
                if (shapeCircles[i].tipo == "CircleS_Red")
                {
                    for (int j = 0; j < shapeCircles[i].angCircles.Length; j++)
                    {
                        shapeCircles[i].angCircles[j] = shapeCircles[i].StartAngCircles[j] + 
                            EmbaralhaObjs( embCircle = new ClicksEmbaralha_RedCircles(shapeCircles[i].tipo, circleCentralClicksEmbaralha, circleHRedclicksEmbaralha));
                    }
                }


                //Circle Simples Azul; rotação neutra = 0 -> rotaciona nos dois sentidos
                if (shapeCircles[i].tipo == "CircleS_Blue")
                {
                    for (int j = 0; j < shapeCircles[i].angCircles.Length; j++)
                    {
                        shapeCircles[i].angCircles[j] = shapeCircles[i].StartAngCircles[j];
                    }
                }
                //Circle Simples Laranja; 
                if (shapeCircles[i].tipo == "CircleS_Orange")
                {
                    for (int j = 0; j < shapeCircles[i].angCircles.Length; j++)
                    {
                        shapeCircles[i].angCircles[j] = shapeCircles[i].StartAngCircles[j];
                    }
                }
                //Circle Horário Vermelha; rotação horário = 1 
                if (shapeCircles[i].tipo == "CircleH_Red")
                {
                    for (int j = 0; j < shapeCircles[i].angCircles.Length; j++)
                    {
                        shapeCircles[i].angCircles[j] = shapeCircles[i].StartAngCircles[j];
                    }
                }
                //Circle Anti-Horário Vermelha; rotação horário = -1 
                if (shapeCircles[i].tipo == "CircleAntH_Red")
                {
                    for (int j = 0; j < shapeCircles[i].angCircles.Length; j++)
                    {
                        shapeCircles[i].angCircles[j] = shapeCircles[i].StartAngCircles[j];
                    }
                }
                //Circle Horário Azul; rotação horário = 1 
                if (shapeCircles[i].tipo == "CircleH_Blue")
                {
                    for (int j = 0; j < shapeCircles[i].angCircles.Length; j++)
                    {
                        shapeCircles[i].angCircles[j] = shapeCircles[i].StartAngCircles[j];
                    }
                }
                //Circle Anti-Horário Azul; rotação horário = -1 
                if (shapeCircles[i].tipo == "CircleAntH_Blue")
                {
                    for (int j = 0; j < shapeCircles[i].angCircles.Length; j++)
                    {
                        shapeCircles[i].angCircles[j] = shapeCircles[i].StartAngCircles[j];
                    }
                }
                //Circle Horário Laranja; rotação horário = 1 
                if (shapeCircles[i].tipo == "CircleH_Orange")
                {
                    for (int j = 0; j < shapeCircles[i].angCircles.Length; j++)
                    {
                        shapeCircles[i].angCircles[j] = shapeCircles[i].StartAngCircles[j];
                    }
                }
                //Circle Anti-Horário Laranja; rotação horário = -1 
                if (shapeCircles[i].tipo == "CircleAntH_Orange")
                {
                    for (int j = 0; j < shapeCircles[i].angCircles.Length; j++)
                    {
                        shapeCircles[i].angCircles[j] = shapeCircles[i].StartAngCircles[j];
                    }
                }
                //Circle Horário Rotaciona Sozinha Vermelha; rotação horário = 1 
                if (shapeCircles[i].tipo == "CircleHRotAlone_Red")
                {
                    for (int j = 0; j < shapeCircles[i].angCircles.Length; j++)
                    {
                        shapeCircles[i].angCircles[j] = shapeCircles[i].StartAngCircles[j];
                    }
                }
                //Circle Anti-Horário Rotaciona Sozinha Vermelha; rotação horário = -1 
                if (shapeCircles[i].tipo == "CircleAntHRotAlone_Red")
                {
                    for (int j = 0; j < shapeCircles[i].angCircles.Length; j++)
                    {
                        shapeCircles[i].angCircles[j] = shapeCircles[i].StartAngCircles[j];
                    }
                }
                //Circle Horário Rotaciona Sozinha Blue; rotação horário = 1 
                if (shapeCircles[i].tipo == "CircleHRotAlone_Blue")
                {
                    for (int j = 0; j < shapeCircles[i].angCircles.Length; j++)
                    {
                        shapeCircles[i].angCircles[j] = shapeCircles[i].StartAngCircles[j];
                    }
                }
                //Circle Anti-Horário Rotaciona Sozinha Azul; rotação horário = -1 
                if (shapeCircles[i].tipo == "CircleAntHRotAlone_Blue")
                {
                    for (int j = 0; j < shapeCircles[i].angCircles.Length; j++)
                    {
                        shapeCircles[i].angCircles[j] = shapeCircles[i].StartAngCircles[j];
                    }
                }
                //Circle Horário Rotaciona Sozinha Laranja; rotação horário = 1 
                if (shapeCircles[i].tipo == "CircleHRotAlone_Orange")
                {
                    for (int j = 0; j < shapeCircles[i].angCircles.Length; j++)
                    {
                        shapeCircles[i].angCircles[j] = shapeCircles[i].StartAngCircles[j];
                    }
                }
                //Circle Anti-Horário Rotaciona Sozinha Laranja; rotação horário = -1 
                if (shapeCircles[i].tipo == "CircleAntHRotAlone_Orange")
                {
                    for (int j = 0; j < shapeCircles[i].angCircles.Length; j++)
                    {
                        shapeCircles[i].angCircles[j] = shapeCircles[i].StartAngCircles[j];
                    }
                }
            }            
        }
    }

    //Atualiza ângulos dos objs
    void AtualizaAngs()
    {
        for (int i = 0; i < shapeCircles.Length; i++)
        {
            //CircSimple_Red; rotação neutra = 0 -> rotaciona nos dois sentidos
            if (shapeCircles[i].tipo == "CircleS_Red")
            {
                for (int j = 0; j < shapeCircles[i].circles.Length; j++)
                {
                    if (shapeCircles[i].circles[j] != null)
                        shapeCircles[i].circles[j].transform.rotation = Quaternion.Euler(0, 0, shapeCircles[i].angCircles[j]);
                }
            }
            //CircSimple_Blue; rotação neutra = 0 -> rotaciona nos dois sentidos
            if (shapeCircles[i].tipo == "CircleS_Blue")
            {
                for (int j = 0; j < shapeCircles[i].circles.Length; j++)
                {
                    if (shapeCircles[i].circles[j] != null)
                        shapeCircles[i].circles[j].transform.rotation = Quaternion.Euler(0, 0, shapeCircles[i].angCircles[j]);
                }
            }
            //CircSimple_Orange; rotação neutra = 0 -> rotaciona nos dois sentidos
            if (shapeCircles[i].tipo == "CircleS_Orange")
            {
                for (int j = 0; j < shapeCircles[i].circles.Length; j++)
                {
                    if (shapeCircles[i].circles[j] != null)
                        shapeCircles[i].circles[j].transform.rotation = Quaternion.Euler(0, 0, shapeCircles[i].angCircles[j]);
                }
            }
            //CircleH_Red
            if (shapeCircles[i].tipo == "CircleH_Red")
            {
                for (int j = 0; j < shapeCircles[i].circles.Length; j++)
                {
                    if (shapeCircles[i].circles[j] != null)
                        shapeCircles[i].circles[j].transform.rotation = Quaternion.Euler(0, 0, shapeCircles[i].angCircles[j]);
                }
            }
            //CircleAntH_Red
            if (shapeCircles[i].tipo == "CircleAntH_Red")
            {
                for (int j = 0; j < shapeCircles[i].circles.Length; j++)
                {
                    if (shapeCircles[i].circles[j] != null)
                        shapeCircles[i].circles[j].transform.rotation = Quaternion.Euler(0, 0, shapeCircles[i].angCircles[j]);
                }
            }
            //CircleH_Blue 
            if (shapeCircles[i].tipo == "CircleH_Blue")
            {
                for (int j = 0; j < shapeCircles[i].circles.Length; j++)
                {
                    if (shapeCircles[i].circles[j] != null)
                        shapeCircles[i].circles[j].transform.rotation = Quaternion.Euler(0, 0, shapeCircles[i].angCircles[j]);
                }
            }
            //CircleAntH_Blue 
            if (shapeCircles[i].tipo == "CircleAntH_Blue")
            {
                for (int j = 0; j < shapeCircles[i].circles.Length; j++)
                {
                    if (shapeCircles[i].circles[j] != null)
                        shapeCircles[i].circles[j].transform.rotation = Quaternion.Euler(0, 0, shapeCircles[i].angCircles[j]);
                }
            }
            //CircleH_Orange 
            if (shapeCircles[i].tipo == "CircleH_Orange")
            {
                for (int j = 0; j < shapeCircles[i].circles.Length; j++)
                {
                    if (shapeCircles[i].circles[j] != null)
                        shapeCircles[i].circles[j].transform.rotation = Quaternion.Euler(0, 0, shapeCircles[i].angCircles[j]);
                }
            }
            //CircleAntH_Orange 
            if (shapeCircles[i].tipo == "CircleAntH_Orange")
            {
                for (int j = 0; j < shapeCircles[i].circles.Length; j++)
                {
                    if (shapeCircles[i].circles[j] != null)
                        shapeCircles[i].circles[j].transform.rotation = Quaternion.Euler(0, 0, shapeCircles[i].angCircles[j]);
                }
            }
            //CircleHRotAlone_Red
            if (shapeCircles[i].tipo == "CircleHRotAlone_Red")
            {
                for (int j = 0; j < shapeCircles[i].circles.Length; j++)
                {
                    if (shapeCircles[i].circles[j] != null)
                        shapeCircles[i].circles[j].transform.rotation = Quaternion.Euler(0, 0, shapeCircles[i].angCircles[j]);
                }
            }
            //CircleAntHRotAlone_Red
            if (shapeCircles[i].tipo == "CircleAntHRotAlone_Red")
            {
                for (int j = 0; j < shapeCircles[i].circles.Length; j++)
                {
                    if (shapeCircles[i].circles[j] != null)
                        shapeCircles[i].circles[j].transform.rotation = Quaternion.Euler(0, 0, shapeCircles[i].angCircles[j]);
                }
            }
            //CircleHRotAlone_Blue
            if (shapeCircles[i].tipo == "CircleHRotAlone_Blue")
            {
                for (int j = 0; j < shapeCircles[i].circles.Length; j++)
                {
                    if (shapeCircles[i].circles[j] != null)
                        shapeCircles[i].circles[j].transform.rotation = Quaternion.Euler(0, 0, shapeCircles[i].angCircles[j]);
                }
            }
            //CircleAntHRotAlone_Blue
            if (shapeCircles[i].tipo == "CircleAntHRotAlone_Blue")
            {
                for (int j = 0; j < shapeCircles[i].circles.Length; j++)
                {
                    if (shapeCircles[i].circles[j] != null)
                        shapeCircles[i].circles[j].transform.rotation = Quaternion.Euler(0, 0, shapeCircles[i].angCircles[j]);
                }
            }
            //CircleHRotAlone_Orange
            if (shapeCircles[i].tipo == "CircleHRotAlone_Orange")
            {
                for (int j = 0; j < shapeCircles[i].circles.Length; j++)
                {
                    if (shapeCircles[i].circles[j] != null)
                        shapeCircles[i].circles[j].transform.rotation = Quaternion.Euler(0, 0, shapeCircles[i].angCircles[j]);
                }
            }
            //CircleAntHRotAlone_Orange
            if (shapeCircles[i].tipo == "CircleAntHRotAlone_Orange")
            {
                for (int j = 0; j < shapeCircles[i].circles.Length; j++)
                {
                    if (shapeCircles[i].circles[j] != null)
                        shapeCircles[i].circles[j].transform.rotation = Quaternion.Euler(0, 0, shapeCircles[i].angCircles[j]);
                }
            }
        }
    }

    //Tentar AI para com randon para embalralhar os objs
    //criar construtor para parâmentros
    float EmbaralhaObjs(ClicksEmbaralha_RedCircles clicks)
    {
        float x = 0;

        //Embaralha Red_Circles
        if(clicks.Clicks_HRed != 0)
        {
            if (clicks.Tipo == "CircleS_Red")
            {
                x = clicks.Clicks_CentralAntHRed * -45 + clicks.Clicks_HRed * 45;
                return x;
            }
            //pensando...
            //if (tipo == "CircleAntH_Red")
            //{
            //    print("oi");
            //    x = clicksCentral * -45 + clicksHred * 45;

            //    return x;
            //}
            if (clicks.Tipo == "CircleHRotAlone_Red")
            {
                x = clicks.Clicks_CentralAntHRed * -45 + clicks.Clicks_HRed * 45 + clicks.Clicks_AntHRotAloneRed * 45;
                return x;
            }
            //if (tipo == "CircleAntHRotAlone_Red")
            //{
            //    print("oi");
            //    x = clicks_HCentral * -45 + clicks_HRed * 45;

            //    return x;
            //}
            return x;
        }        
        else
            return 0;
        
    }
}


