using UnityEngine;
using Scripts.Player.InputReaders;
using Scripts.Player.Weapons;

namespace Scripts.Player.Attacking
{
    public class PlayerAttack : IAttack
    {
        private IInputReader inputReader;
        private WeaponSystemBase weaponSystem;

        public PlayerAttack(IInputReader _inputReader, WeaponSystemBase _weaponSystem)
        {
            inputReader = _inputReader;
            weaponSystem = _weaponSystem;
        }

        public void InitiateAttack()
        {
            weaponSystem.InitiateWeapons();
            inputReader.onNextWeapon += weaponSystem.NextWeapon;
            inputReader.onPrevWeapon += weaponSystem.PrevWeapon;
            inputReader.onAttack += weaponSystem.Attack;
        }
    }
}