using UnityEngine;
using UnityEngine.UI;
using Scripts.Settings;

namespace Scripts.Enemy.HealthSystem
{
    public abstract class HealthSystemBase : MonoBehaviour
    {
        [SerializeField] protected Slider healthSlider;
        [SerializeField] protected CameraTransformHolder cameraTransform;

        public abstract void SetSettings(EnemySettings enemySettings);
        public abstract void Initiate();
        public abstract void Tick();
    }
}