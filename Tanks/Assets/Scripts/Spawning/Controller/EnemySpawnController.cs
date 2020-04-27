using UnityEngine;
using Scripts.Pool;
using Scripts.Enemy.Controller;
using System.Collections.Generic;

namespace Scripts.Spawning.Controller
{
    public class EnemySpawnController : MonoBehaviour
    {
        [SerializeField] private EnemyBase enemyOne;
        [SerializeField] private EnemyBase enemyTwo;
        [SerializeField] private EnemyBase enemyThree;

        [SerializeField] private List<Transform> spawnPos;
        [SerializeField] private Transform enemyHolder;


        private GenericPool<EnemyBase> enemyPool;
        private ISpawner enemySpawner;

        private void Awake()
        {
            InitiatePool();
            InitiateSpawner();

            enemySpawner.Spawn();
        }

        private void Update()
        {
            
        }

        private void InitiatePool()
        {
            enemyPool = new EnemyPool();
            enemyPool.InitiatePool();
        }

        private void InitiateSpawner()
        {
            enemySpawner = new EnemySpawner(enemyPool, spawnPos , enemyHolder , this ,enemyOne, enemyTwo, enemyThree);
        }
    }
}