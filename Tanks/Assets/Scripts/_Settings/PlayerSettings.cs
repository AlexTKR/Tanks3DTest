using UnityEngine;

namespace Scripts.Settings
{
    [CreateAssetMenu(menuName = "Settings/Player", fileName = "Settings")]
    public class PlayerSettings : ScriptableObject
    {
        [SerializeField] private float health;
        [SerializeField] private float defence;
        [SerializeField] private float movingSpeed;
        [SerializeField] private float turningSpeed;

        public float Health => healthBuffer;
        public float Defence => defence;
        public float MovingSpeed => movingSpeed;
        public float TurningSpeed => turningSpeed;

        private float healthBuffer;

        private void OnEnable()
        {
            healthBuffer = health;
        }

    }
}