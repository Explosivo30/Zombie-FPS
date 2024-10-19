using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooterBase : MonoBehaviour
{
    public virtual void ShootOnce() 
    {
        Debug.Log("ShootOnce");
    }

    public virtual void ShootBurst()
    {
        Debug.Log("ShootBurst");
    }

    public virtual void StartShooting()
    {
        Debug.Log("StartShooting");
    }

    public virtual void StopShooting()
    {
        Debug.Log("StopShooting");
    }
}
