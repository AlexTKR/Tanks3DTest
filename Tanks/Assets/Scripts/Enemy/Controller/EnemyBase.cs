using UnityEngine;
using Scripts.Pool;
using Scripts.Settings;

namespace Scripts.Enemy.Controller
{
    public abstract class EnemyBase : MonoBehaviour
    {
        [SerializeField] protected EnemySettings enemySettings;

        protected EnemySettings enemySettingsCopy;
        protected GenericPool<EnemyBase> enemyPool;

        public void InjectPool(GenericPool<EnemyBase> _enemyPool)
        {
            enemyPool = _enemyPool;
        }

        public abstract void ReturnToThePool();
        public abstract void Initiate();
    }
}