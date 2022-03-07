using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponService : GenericSingleton<WeaponService>
{
    WeaponHandler weaponHandler;

    protected override void Awake() 
    {
        base.Awake();
        weaponHandler = new WeaponHandler();
    }

    public void PickUpWeapon(WeaponType weaponType, int weaponIndex)
    {
        weaponHandler.PickUpWeapon(weaponType, weaponIndex);
    }

    // This function will get called through player input script when we change weapon.
    public void ChangeEquipedWeapon(EquipedWeapon equipedWeapon)
    {
        weaponHandler.ChangeEquipedWeapon(equipedWeapon);
    }

    public void ChangeWeaponState(WeaponState weaponState)
    {
        weaponHandler.ChangeWeaponState(weaponState);
    }

    public EquipedWeapon GetEquipedWeapon()
    {
        return weaponHandler.GetEquipedWeapon();
    }

    
}
