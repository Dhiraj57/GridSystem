using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryWeaponService : GenericSingleton<PrimaryWeaponService>
{
    PrimaryWeaponSOList primaryWeaponList;  

    public PrimaryWeaponController CreatePrimaryWeapon(int weaponIndex)
    {
        PrimaryWeaponModel weaponModel = new PrimaryWeaponModel(primaryWeaponList.weaponTypes[weaponIndex]);
        PrimaryWeaponView weaponView = new PrimaryWeaponView();

        PrimaryWeaponController weaponController = new PrimaryWeaponController(weaponModel, weaponView);
        return weaponController;
    }
}
