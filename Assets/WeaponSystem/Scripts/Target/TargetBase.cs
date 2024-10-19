using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBase : MonoBehaviour
{
    public virtual void NotifyShot()
    {
        Debug.Log("Me han dao");
    }


    public virtual void NotifyExplosion(Explosion explosion)
    {
        Debug.Log("Me ha explotado la explosion " + explosion, explosion);
    }

}
