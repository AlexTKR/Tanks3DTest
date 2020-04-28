using UnityEngine;
using System.Collections.Generic;

namespace Scripts.Player.Weapons
{
    public abstract class WeaponSystemBase : MonoBehaviour
    {
        [SerializeField] private List<WeaponBase> weaponHolder;

        protected LinkedList<WeaponBase> weapons;
        protected LinkedListNode<WeaponBase> currentWeapon;

        public void InitiateWeapons()
        {
            weapons = new LinkedList<WeaponBase>();

            foreach (WeaponBase weapon in weaponHolder)
            {
                weapon.Initiate();
                weapons.AddLast(weapon);
            }

            currentWeapon = weapons.First;
            currentWeapon.Value.Enable();
        }

        public abstract void NextWeapon();
        public abstract void PrevWeapon();
        public abstract void Attack();        
    }
}