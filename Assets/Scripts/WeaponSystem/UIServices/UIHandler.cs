using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    EquipedWeapon equipedWeapon;
    WeaponUI weaponUI;

    private void OnEnable()
    {
        EventService.Instance.OnBulletFired += UpdateBulletCount;
        EventService.Instance.onChangeEquipedWeapon += UpdateEquipedWeapon;
        EventService.Instance.onWeaponPickUP += ChangeWeaponImage;
    }

    private void Start()
    {
        equipedWeapon = WeaponService.Instance.GetEquipedWeapon();
    }

    public void UpdateEquipedWeapon(EquipedWeapon weapon)
    {
        equipedWeapon = weapon;
    }

    public void ChangeWeaponImage(int weaponIndex)
    {
        weaponUI.UpdateWeaponImage(weaponIndex);
    }

    public void UpdateBulletCount()
    {
        weaponUI.UpdateBulletCount(equipedWeapon);
    }


    private void OnDisable()
    {
        EventService.Instance.OnBulletFired -= UpdateBulletCount;
        EventService.Instance.onChangeEquipedWeapon -= UpdateEquipedWeapon;
        EventService.Instance.onWeaponPickUP -= ChangeWeaponImage;
    }
}
