using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : MonoBehaviour
{
    // This function will get called when OnTriggerStay is getting called on weapon trigger and player gives input to pickup weapon.
    void PickUpWeapon(WeaponType weaponType, int weaponIndex)
    {
        WeaponService.Instance.PickUpWeapon(weaponType, weaponIndex);
    }
}
