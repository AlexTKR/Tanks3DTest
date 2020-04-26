using UnityEngine;
using Scripts.Pool;

namespace Scripts.Player.Weapons
{
    public class UltraCanon : WeaponBase
    {
        [SerializeField] private ShellBase shell;

        private GenericPool<ShellBase> shells;

        public override void Initiate()
        {
            shells = new ShellPool();
        }

        public override void Attack()
        {
            
        }
    }
}