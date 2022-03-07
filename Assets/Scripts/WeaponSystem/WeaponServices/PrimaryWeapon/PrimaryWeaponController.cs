using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryWeaponController 
{
    public PrimaryWeaponModel primaryWeaponModel { get; }
    public PrimaryWeaponView primaryWeaponView { get; }

    public PrimaryWeaponController(PrimaryWeaponModel weaponModel, PrimaryWeaponView weaponView)
    {
        primaryWeaponView = weaponView;
        primaryWeaponModel = weaponModel;
    }

    public void FireWeapon()
    {
        // Fire bullets.
    }
}
