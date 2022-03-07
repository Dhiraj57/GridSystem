public enum EquipedWeapon
{
    FirstPrimaryWeapon,
    SecondPrimaryWeapon,
    SecondaryWeapon
}

public class WeaponHandler 
{
    public PrimaryWeaponController primaryWeaponSlotOne ;
    public PrimaryWeaponController primaryWeaponSlotTwo ;
    public SecondaryWeaponController secondaryWeaponSlot ;

    private int slotNumber;
    private EquipedWeapon equipedWeapon;

    public WeaponStateIdle weaponStateIdle;
    public WeaponStateFiring weaponStateFiring;
    public WeaponStateReloading weaponStateReloading;
    public WeaponStateBase currentWeaponState;
    public WeaponStateBase newWeaponState;

    public WeaponHandler()
    {
        slotNumber = 1;
        equipedWeapon = EquipedWeapon.FirstPrimaryWeapon;
        currentWeaponState = weaponStateIdle;
    }

    public void PickUpWeapon(WeaponType weaponType, int weaponIndex)
    {
        switch(weaponType)
        {
            case WeaponType.PrimaryWeapon:
                {
                    if(slotNumber == 1)
                    {
                        primaryWeaponSlotOne = PrimaryWeaponService.Instance.CreatePrimaryWeapon(weaponIndex);
                    }
                    else
                    {
                        primaryWeaponSlotTwo = PrimaryWeaponService.Instance.CreatePrimaryWeapon(weaponIndex);
                    }
                    break;
                }

            case WeaponType.SecondaryWeapon:
                {
                    secondaryWeaponSlot = SecondaryWeaponService.Instance.CreateSecondaryWeapon(weaponIndex);
                    break;
                }
        }
    }

    public void ChangeEquipedWeapon(EquipedWeapon weapon)
    {
        equipedWeapon = weapon;
        EventService.Instance.InvokeOnChangeEquipedWeapon(weapon);
    }

    public void ChangeWeaponState(WeaponState state)
    {

        switch (state)
        {
            case WeaponState.Idle:
                {
                    newWeaponState = weaponStateIdle;
                    break;
                }
            case WeaponState.Firing:
                {
                    newWeaponState = weaponStateFiring;
                    break;
                }
            case WeaponState.Reloading:
                {
                    newWeaponState = weaponStateReloading;
                    break;
                }
        }

        if (weaponStateIdle.isActiveAndEnabled)
        {
            weaponStateIdle.ChangeWeaponState(newWeaponState);
        }
        else if(weaponStateFiring.isActiveAndEnabled)
        {
            weaponStateFiring.ChangeWeaponState(newWeaponState);
        }
        else if(weaponStateReloading.isActiveAndEnabled)
        {
            weaponStateReloading.ChangeWeaponState(newWeaponState);
        }
    }

    public EquipedWeapon GetEquipedWeapon()
    {
        return equipedWeapon;
    }
}
