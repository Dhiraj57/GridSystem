using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObject/Weapon/PrimaryWeaponScriptableObjectList")]
public class PrimaryWeaponSOList : ScriptableObject
{
    public PrimaryWeaponSO[] weaponTypes;
}
