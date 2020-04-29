using UnityEngine;
using Scripts.Pool;

namespace Scripts.Player.Weapons
{
    public class UltraCanon : WeaponBase
    {
        [SerializeField] private ShellBase shell;
        [SerializeField] private Transform shellHolder;

        private GenericPool<ShellBase> shellPool;
        private int maxSheelCount = 5;
        private int increaseShellCount = 3;

        public override void Initiate()
        {
            shellPool = new ShellPool();
            shellPool.InitiatePool();

            PreSpawnShells(maxSheelCount);
        }

        public override void Attack()
        {


            if (!shellPool.IsPoolEmpty())
            {
                Fire();
            }
            else
            {
                PreSpawnShells(increaseShellCount);
                Fire();
            }
        }

        public override void Enable()
        {
            gameObject.SetActive(true);
        }

        public override void Disable()
        {
            gameObject.SetActive(false);
        }

        private void PreSpawnShells(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ShellBase newShell = Instantiate(shell, shellHolder.transform.position, Quaternion.identity);
                newShell.InjectPool(shellPool);
                newShell.gameObject.SetActive(false);
                newShell.transform.SetParent(shellHolder);
                newShell.SetDamageAmount(weaponSettings.Damage);
                shellPool.SetInstance(newShell);
            }
        }

        private void Fire()
        {
            ShellBase newShell = shellPool.GetInctance();
            newShell.transform.position = shellHolder.position;
            newShell.transform.forward = shellHolder.transform.forward;
            newShell.gameObject.SetActive(true);
            newShell.Fire();
        }
    }

}
