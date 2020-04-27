using UnityEngine;

namespace Scripts.Settings
{
    [CreateAssetMenu(menuName = "Settings/Weapon", fileName = "Settings")]
    public class WeaponSettings : ScriptableObject
    {
        [SerializeField] private float damage;

        public float Damage => damage;
    }
}