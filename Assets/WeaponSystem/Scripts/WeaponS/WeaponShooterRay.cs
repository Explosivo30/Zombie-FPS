using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooterRay : WeaponShooterBase
{
    [SerializeField] Transform cannonBarrel;
    [SerializeField] AudioSource shootAudio;
    [SerializeField] AudioSource reload;

    public override void ShootOnce()
    {
        //base.ShootOnce();

        RaycastHit hit;
        //Disparamos
        if (Physics.Raycast(cannonBarrel.position, cannonBarrel.forward, out hit))
        {

            Debug.DrawRay(hit.point, hit.normal, Color.red, 5f);
            Debug.Log("Le hemos dado a algo" + hit.collider.name);
            shootAudio.Play();

            TargetBase target = hit.collider.GetComponent<TargetBase>();
            if (target)
            {
                target.NotifyShot();
            }
        }
    }

}
