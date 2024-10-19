using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooterInstantiate : WeaponShooterBase
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform cannonBarrel;
    public override void ShootOnce()
    {
        Instantiate(prefab, cannonBarrel.position, cannonBarrel.rotation);
        
    }
}
