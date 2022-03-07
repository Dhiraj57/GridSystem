using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObject/Weapon/PrimaryWeaponScriptableObject")]
public class PrimaryWeaponSO : ScriptableObject
{
    public int maxAmmo;
    public int magazineSize;
    public int fireRate;
    public int damage;
}
