using UnityEngine;

namespace Scripts.Player.Weapons
{
    public class WeaponSystem : WeaponSystemBase
    {
        public override void Attack()
        {
            if (currentWeapon.Value != null)
            {
                currentWeapon.Value.Attack();
            }
        }

        public override void NextWeapon()
        {
            Debug.Log("Next");
            currentWeapon.Value.Disable();

            if (currentWeapon.Next != null)
            {
                currentWeapon = currentWeapon.Next;
            }
            else
            {
                currentWeapon = weapons.First;
            }

            currentWeapon.Value.Enable();
        }

        public override void PrevWeapon()
        {
            currentWeapon.Value.Disable();

            if (currentWeapon.Previous != null)
            {
                currentWeapon = currentWeapon.Previous;
            }
            else
            {
                currentWeapon = weapons.Last;
            }

            currentWeapon.Value.Enable();
        }
    }
}