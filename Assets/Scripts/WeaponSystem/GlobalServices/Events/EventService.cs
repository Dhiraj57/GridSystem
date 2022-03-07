using System;
using UnityEngine;

public class EventService : GenericSingleton<EventService>
{
    public event Action OnBulletFired;

    public delegate void OnChangeEquipedWeapon(EquipedWeapon weapon);
    public event OnChangeEquipedWeapon onChangeEquipedWeapon;

    public delegate void OnWeaponPickUp(int weaponIndex);
    public event OnWeaponPickUp onWeaponPickUP;

    public void InvokeOnBulletFired()
    {
        OnBulletFired?.Invoke();
    }

    public void InvokeOnChangeEquipedWeapon(EquipedWeapon weapon)
    {
        if(onChangeEquipedWeapon != null)
        {
            onChangeEquipedWeapon(weapon);
        }
    }

    public void InvokeOnWeaponPickUP(int weaponIndex)
    {
        if(onWeaponPickUP != null)
        {
            onWeaponPickUP(weaponIndex);
        }
    }
}
