using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngsPositions : MonoBehaviour
{
    public static AngsPositions instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [System.Serializable]
    public class Modulos
    {
        public controlPanelRotation[] angPosAtiv;
        public string tipo;
        public int index;
        public int posH;
        public int posAntH;       
    }

    public Modulos[] mods;
    [Space(20)]
    public int[] alinhados;

    public bool trava_AngsPos;

    private void Update()
    {
        //CheckPos();
        //StartCoroutine(WaitAngs_Pos());
    }

    public void CheckPos()
    {
        for (int i = 0; i < mods.Length - 1; i++)//modulos
        {
            for (int j = 0; j < mods[i].angPosAtiv.Length; j++)//angulos dos modulos
            {
                //StartCoroutine(WaitAngs_Pos());

                //if(trava_AngsPos == true)
                //{
                    if (mods[i].angPosAtiv[j].posAng_H_Temp > 0)
                    {
                        mods[i].posH = mods[i].angPosAtiv[j].posAng_H_Temp;
                        mods[i].posAntH = mods[i].angPosAtiv[j].posAng_AH_Temp;
                    }
                    else if (mods[i].angPosAtiv[j].posAng_H_Temp == -1)
                    {
                        mods[i].posH = 0;
                        mods[i].posAntH = 0;
                    }

                    //trava_AngsPos = false;
                //}
                
                for (int a = i + 1; a < mods.Length; a++)//modulos
                {
                    for (int b = 0; b < mods[a].angPosAtiv.Length; b++)//angulos dos mdulos
                    {
                        
                        if (mods[a].angPosAtiv[b].posAng_H_Temp > 0)
                        {
                            mods[a].posH = mods[a].angPosAtiv[b].posAng_H_Temp;
                            mods[a].posAntH = mods[a].angPosAtiv[b].posAng_AH_Temp;
                        }
                        else if (mods[a].angPosAtiv[b].posAng_H_Temp == -1)
                        {
                            mods[a].posH = 0;
                            mods[a].posAntH = 0;
                        }
                        if (mods[i].tipo == "H" && mods[a].tipo == "H" && mods[i].posH != 0 && mods[a].posH != 0)
                        {
                            if (mods[i].posH == mods[a].posH)
                            {
                                print("mod " + i + " = " + mods[i].posH + " mod " + a + " = " + mods[a].posH);
                                //print("alinhados");                                
                                alinhados[mods[i].index] = 1;
                                alinhados[mods[a].index] = 1;
                               // alinhados[a] = 1;
                               // print("i " + i + " X " + "a " + a );
                            }
                            //else if(mods[i].posH == mods[a].posH)
                            //{
                            //    mods[i].alinhado = 1;
                            //    mods[a].alinhado = 1;
                            //    print("i " + i + " X iguais " + "a " + a);
                            //    print(mods[i].posH + " iguais " + mods[a].posH);
                            //}
                            //if (mods[i].posH != mods[a].posH)
                            //{
                            //    print("Desalinhados");
                            //}
                        }
                    }
                }
            }
        }

        //alinhados += alinh;
    }

    IEnumerator WaitAngs_Pos()
    {
        yield return new WaitForSeconds(1);
        trava_AngsPos = true;
        //CheckPos();
    }
}
