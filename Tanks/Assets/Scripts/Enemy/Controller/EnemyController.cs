using UnityEngine;
using UnityEngine.AI;
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

        public void TakeDamage(float damage)
        {
            enemySettingsCopy.Health = enemySettingsCopy.Health - damage * enemySettingsCopy.Defence;
        }

        public override void Initiate()
        {
            InitiateSettings();
        }

        public override void ReturnToThePool()
        {
            gameObject.SetActive(false);
            gameObject.transform.SetParent(null);
            InitiateSettings();
            enemyPool.SetInstance(this);
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
            healthListener.Tick();
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
            enemyAttack.Attack();
        }

        private void InitiateHealthListener()
        {
            healthListener = new HealthListener.HealthListener(enemySettingsCopy, this);
        }

        private void InitiateEnemiesHealth()
        {
            enemiesHealh.SetSettings(enemySettingsCopy);
            enemiesHealh.Initiate();
        }
    }
}

