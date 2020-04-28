using UnityEngine;
using UnityEngine.UI;
using Scripts.Settings;

namespace Scripts.Player.HealthSystem
{
    public abstract class HealthSystemBase : MonoBehaviour
    {
        [SerializeField] protected Slider healthSlider;
        [SerializeField] protected CameraTransformHolder cameraTransform;

        public abstract void Initiate();
        public abstract void Tick();
    }
}