using UnityEngine;
using Scripts.Settings;

namespace Scripts.Player.HealthSystem
{
    public class PlayersHealth : HealthSystemBase
    {
        [SerializeField] private PlayerSettings playerSettings;

        public override void Initiate()
        {
            healthSlider.maxValue = playerSettings.Health;
        }

        public override void Tick()
        {
            SetHealth();
            LookAtCamera();
        }

        private void LookAtCamera()
        {
            transform.LookAt(cameraTransform.CameraTransform);
        }

        private void SetHealth()
        {
            healthSlider.value = Mathf.Clamp(playerSettings.Health, 0, healthSlider.maxValue);
        }
    }
}