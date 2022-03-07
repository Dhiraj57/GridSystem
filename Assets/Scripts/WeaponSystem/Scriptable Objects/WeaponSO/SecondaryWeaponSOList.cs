using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObject/Weapon/SecondaryWeaponScriptableObjectList")]
public class SecondaryWeaponSOList : ScriptableObject
{
    public SecondaryWeaponSO[] weaponTypes;
}
