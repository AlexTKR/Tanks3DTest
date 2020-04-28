using Scripts.Settings;
using UnityEngine;

namespace Scripts.Enemy.HealthSystem
{
    public class EnemiesHealth : HealthSystemBase
    {
        private EnemySettings enemySettings;

        public override void Initiate()
        {
            healthSlider.maxValue = enemySettings.Health;
        }

        public override void SetSettings(EnemySettings _enemySettings)
        {
            enemySettings = _enemySettings;
        }

        public override void Tick()
        {
            healthSlider.value = Mathf.Clamp(enemySettings.Health, 0, healthSlider.maxValue);
        }
    }
}