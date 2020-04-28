using UnityEngine;
using Scripts.Settings;
using Scripts.Enemy.Controller;

namespace Scripts.Enemy.HealthListener
{
    public class HealthListener : IListener
    {
        private EnemySettings enemySettings;
        private EnemyBase enemy;

        public HealthListener(EnemySettings _enemySettings, EnemyBase _enemy)
        {
            enemySettings = _enemySettings;
            enemy = _enemy;
        }

        public void Listen()
        {
            if (enemySettings.Health <= 0)
            {
                enemy.ReturnToThePool();              
            }
        }
    }
}