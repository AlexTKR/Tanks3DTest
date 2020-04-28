using UnityEngine;
using Scripts.Pool;

namespace Scripts.Player.Weapons
{
    public abstract class ShellBase : MonoBehaviour
    {
        protected GenericPool<ShellBase> shellPool;
        protected float damageAmount;

        public void InjectPool(GenericPool<ShellBase> _shellPool)
        {
            shellPool = _shellPool;
        }

        public void SetDamageAmount(float _damageAmount)
        {
            damageAmount = _damageAmount;
        }

        public abstract void Fire();
        
    }
}