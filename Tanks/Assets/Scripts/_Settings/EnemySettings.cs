using UnityEngine;

namespace Scripts.Settings
{
    [CreateAssetMenu(menuName = "Settings/Enemy", fileName = "Settings")]
    public class EnemySettings : ScriptableObject
    {
        [SerializeField] private float health;
        [SerializeField] private float defence;
        [SerializeField] private float movingSpeed;
        [SerializeField] private float stoppingDistance;

        public float Health { get => health; set => health = value; }
        public float Defence { get => defence; set => defence = value; }
        public float MovingSpeed { get => movingSpeed; set => movingSpeed = value; }
    }
}