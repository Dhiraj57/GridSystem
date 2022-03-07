using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryWeaponService : GenericSingleton<SecondaryWeaponService>
{
    SecondaryWeaponSOList secondaryWeaponList;

    public SecondaryWeaponController CreateSecondaryWeapon(int weaponIndex)
    {
        SecondaryWeaponModel weaponModel = new SecondaryWeaponModel(secondaryWeaponList.weaponTypes[weaponIndex]);
        SecondaryWeaponView weaponView = new SecondaryWeaponView();

        SecondaryWeaponController weaponController = new SecondaryWeaponController(weaponModel, weaponView);
        return weaponController;
    }
}
