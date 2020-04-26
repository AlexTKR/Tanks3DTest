using UnityEngine;
using System.Collections.Generic;

namespace Scripts.Player.Weapons
{
    public abstract class WeaponSystemBase : MonoBehaviour
    {
        [SerializeField] private List<WeaponBase> weaponHolder;

        private LinkedList<WeaponBase> weapons;
        private LinkedListNode<WeaponBase> currentWeapon;

        public void InitiateWeapons()
        {
            weapons = new LinkedList<WeaponBase>();

            foreach (WeaponBase weapon in weaponHolder)
            {
                weapon.Initiate();
                weapons.AddLast(weapon);
            }

            currentWeapon = weapons.First;
        }

        public void NextWeapon()
        {

        }

        public void PrevWeapon()
        {

        }

        public void Attack()
        {
            if (currentWeapon.Value != null)
            {
                currentWeapon.Value.Attack();
            }
        }
    }
}