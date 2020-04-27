using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Player.HealthSystem
{
    public abstract class healthSystemBase : MonoBehaviour
    {
        [SerializeField] protected Slider healthSlider;

        public abstract void Initiate();
        public abstract void Tick();
    }
}