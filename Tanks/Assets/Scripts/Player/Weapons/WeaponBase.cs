using UnityEngine;
using Scripts.Settings;

namespace Scripts.Player.Weapons
{
    public abstract class WeaponBase : MonoBehaviour
    {
        [SerializeField] protected WeaponSettings weaponSettings;

        public abstract void Initiate();
        public abstract void Enable();
        public abstract void Disable();
        public abstract void Attack();
    }
}