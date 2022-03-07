using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryWeaponModel 
{
    public int maxAmmo { get; }
    public int remaningAmmo { get; }
    public int magazineSize { get; }
    public int fireRate { get; }
    public int damage { get; }

    public PrimaryWeaponModel(PrimaryWeaponSO weaponData)
    {
        this.maxAmmo = weaponData.maxAmmo;
        this.remaningAmmo = maxAmmo;
        this.magazineSize = weaponData.magazineSize;
        this.fireRate = weaponData.fireRate;
        this.damage = weaponData.fireRate;
    }
}
