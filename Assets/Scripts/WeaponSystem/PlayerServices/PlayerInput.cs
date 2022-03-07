using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            WeaponService.Instance.ChangeWeaponState(WeaponState.Firing);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            WeaponService.Instance.ChangeWeaponState(WeaponState.Idle);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            WeaponService.Instance.ChangeWeaponState(WeaponState.Reloading);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            WeaponService.Instance.ChangeEquipedWeapon(EquipedWeapon.FirstPrimaryWeapon);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            WeaponService.Instance.ChangeEquipedWeapon(EquipedWeapon.SecondPrimaryWeapon);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            WeaponService.Instance.ChangeEquipedWeapon(EquipedWeapon.SecondaryWeapon);
        }
    }
}
