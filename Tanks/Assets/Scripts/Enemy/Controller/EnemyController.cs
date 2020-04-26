using UnityEngine;
using UnityEngine.AI;
using Scripts.Enemy.Movement;
using Scripts.Enemy.Attack;
using Scripts.Enemy.Damage;
using Scripts.Settings;

namespace Scripts.Enemy.Controller
{
    public class EnemyController : EnemyBase, IDamagble
    {
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private PositionHolder targetPosition;

        private IMovement enemyMovement;
        private IAttack enemyAttack;

        private void Awake()
        {
            InitiateSettings();
            InitiateMovement();
            InitiateAttack();
        }

        private void Update()
        {
            enemyMovement.Tick();
            Debug.Log(enemySettingsCopy.Health);
        }

        public void TakeDamage(float damage)
        {
            enemySettingsCopy.Health = enemySettingsCopy.Health - damage * enemySettingsCopy.Defence;
        }

        private void InitiateSettings()
        {
            enemySettingsCopy = ScriptableObject.CreateInstance<EnemySettings>();
            enemySettingsCopy.Health = enemySettings.Health;
            enemySettingsCopy.Defence = enemySettings.Defence;
            enemySettingsCopy.MovingSpeed = enemySettings.MovingSpeed;
        }


        private void InitiateMovement()
        {
            enemyMovement = new EnemyMovement(enemySettings, targetPosition, transform, agent);
        }

        private void InitiateAttack()
        {
            enemyAttack = new EnemyAttack(playerSettings, transform, this);
            enemyAttack.Attack();
        }        
    }

}

