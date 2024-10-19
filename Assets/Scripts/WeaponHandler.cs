using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] GameObject weaponLogic;

    void EnableWeapon()
    {
        weaponLogic.SetActive(true);
    }


    void DisableWeapon()
    {
        weaponLogic.SetActive(false);
    }
}
