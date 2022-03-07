using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateFiring : WeaponStateBase
{
    private void Update()
    {
        FireWeapon();
    }

    public void FireWeapon()
    {
        switch (weaponHandler.GetEquipedWeapon())
        {
            case EquipedWeapon.FirstPrimaryWeapon:
                {
                    weaponHandler.primaryWeaponSlotOne.FireWeapon();
                    break;
                }

            case EquipedWeapon.SecondPrimaryWeapon:
                {
                    weaponHandler.primaryWeaponSlotTwo.FireWeapon();
                    break;
                }

            case EquipedWeapon.SecondaryWeapon:
                {
                    weaponHandler.secondaryWeaponSlot.FireWeapon();
                    break;
                }
        }

        EventService.Instance.InvokeOnBulletFired();
    }
}
