using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryWeaponController
{
    public SecondaryWeaponModel secondaryWeaponModel { get; }
    public SecondaryWeaponView secondaryWeaponView { get; }

    public SecondaryWeaponController(SecondaryWeaponModel weaponModel, SecondaryWeaponView weaponView)
    {
        secondaryWeaponModel = weaponModel;
        secondaryWeaponView = weaponView;
    }

    public void FireWeapon()
    {
        // Fire bullets.
    }
}
