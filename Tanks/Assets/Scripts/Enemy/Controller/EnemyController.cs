using UnityEngine;
using UnityEngine.AI;
using System;
using Scripts.Enemy.Movement;
using Scripts.Enemy.Attack;
using Scripts.Enemy.Damage;
using Scripts.Enemy.HealthListener;
using Scripts.Enemy.HealthSystem;
using Scripts.Settings;

namespace Scripts.Enemy.Controller
{
    public class EnemyController : EnemyBase, IDamagble
    {
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private PositionHolder targetPosition;
        [SerializeField] private HealthSystemBase enemiesHealh;

        private IMovement enemyMovement;
        private IAttack enemyAttack;
        private IListener healthListener;

        private Action onEnemyDeth;

        public void TakeDamage(float damage)
        {
            enemySettingsCopy.Health = enemySettingsCopy.Health - damage * enemySettingsCopy.Defence;

            if (enemySettingsCopy.Health <= 0)
            {
                onEnemyDeth?.Invoke();
            }
        }

        public override void Initiate()
        {
            InitiateSettings();
        }

        public override void ReturnToThePool()
        {
            enemyAttack.StopAttacking();            
            gameObject.SetActive(false);
            enemyPool.SetInstance(this);
        }

        public override void RestoreEnemy()
        {
            enemySettingsCopy.Health = enemySettings.Health;
            enemyAttack.StartAttacking();
        }

        private void Awake()
        {            
            InitiateSettings();
            InitiateMovement();
            InitiateAttack();
            InitiateHealthListener();
            InitiateEnemiesHealth();
        }

        private void Update()
        {
            enemyMovement.Tick();
        }

        private void LateUpdate()
        {
            enemiesHealh.Tick();
        }

        private void InitiateSettings()
        {
            enemySettingsCopy = ScriptableObject.CreateInstance<EnemySettings>();
            enemySettingsCopy.Health = enemySettings.Health;
            enemySettingsCopy.Defence = enemySettings.Defence;
            enemySettingsCopy.MovingSpeed = enemySettings.MovingSpeed;
            enemySettingsCopy.Damage = enemySettings.Damage;
        }


        private void InitiateMovement()
        {
            enemyMovement = new EnemyMovement(enemySettingsCopy, targetPosition, transform, agent);

            agent.speed = enemySettingsCopy.MovingSpeed;
        }

        private void InitiateAttack()
        {
            enemyAttack = new EnemyAttack(playerSettings, enemySettingsCopy ,transform, this);
            enemyAttack.StartAttacking();
        }

        private void InitiateHealthListener()
        {
            healthListener = new HealthListener.HealthListener(enemySettingsCopy, this);

            onEnemyDeth += healthListener.Listen;
        }

        private void InitiateEnemiesHealth()
        {
            enemiesHealh.SetSettings(enemySettingsCopy);
            enemiesHealh.Initiate();
        }
    }
}

