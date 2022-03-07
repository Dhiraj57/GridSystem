using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState
{
    Idle,
    Firing,
    Reloading
}

public class WeaponStateBase : MonoBehaviour
{
    protected WeaponHandler weaponHandler;

    public virtual void OnStateEnter()
    {
        this.enabled = true;
    }

    public virtual void OnStateExit()
    {
        this.enabled = false;
    }

    public void ChangeWeaponState(WeaponStateBase newState)
    {
        weaponHandler.currentWeaponState.OnStateExit();
        weaponHandler.currentWeaponState = newState;
        weaponHandler.currentWeaponState.OnStateEnter();
    }
}
