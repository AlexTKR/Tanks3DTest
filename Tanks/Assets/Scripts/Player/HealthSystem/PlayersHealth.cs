using UnityEngine;
using Scripts.Settings;

namespace Scripts.Player.HealthSystem
{
    public class PlayersHealth : healthSystemBase
    {
        [SerializeField] private PlayerSettings playerSettings;

        public override void Initiate()
        {
            healthSlider.maxValue = playerSettings.Health;
        }

        public override void Tick()
        {
            healthSlider.value = Mathf.Clamp(playerSettings.Health, 0, healthSlider.maxValue);
        }
    }
}