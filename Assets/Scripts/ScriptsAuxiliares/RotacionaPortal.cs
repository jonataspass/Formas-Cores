using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionaPortal : MonoBehaviour
{
    public float velRot;
    //public GeraMeteor geraMeteor;
    //public int numMax_repetMeteor;

    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * velRot);
        //DestroyPortal();
    }

    //void DestroyPortal()
    //{
    //    if (numMax_repetMeteor == geraMeteor.num_Meteors)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
