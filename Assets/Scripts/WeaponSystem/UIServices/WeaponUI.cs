using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    // Array to store reference of all weapon images.
    Image[] weaponImages;

    Image primaryWeaponOneImage;
    Image primaryWeaponTwoImage;
    Image secondaryWeaponImage;

    Text currentAmmo;
    Text totalAmmo;

    public void UpdateBulletCount(EquipedWeapon equipedWeapon)
    {
        // Based on equiped weapon we will set currentAmmo and totalAmmo text.
    }

    public void UpdateWeaponImage(int weaponIndex)
    {
        // Based on equiped weapon we will change weapon image of that particular slot.
    }

    public void SetPrimaryWeaponOneImage(int weaponIndex)
    {
        primaryWeaponOneImage = weaponImages[weaponIndex];
    }

    public void SetPrimaryWeaponTwoImage(int weaponIndex)
    {
        primaryWeaponTwoImage = weaponImages[weaponIndex];
    }

    public void SetSecondaryWeaponImage(int weaponIndex)
    {
        secondaryWeaponImage = weaponImages[weaponIndex];
    }

    public void SetCurrentAmmoText(int value)
    {
        currentAmmo.text = value.ToString();
    }

    public void SetTotalAmmoText(int value)
    {
        totalAmmo.text = value.ToString();
    }
}
