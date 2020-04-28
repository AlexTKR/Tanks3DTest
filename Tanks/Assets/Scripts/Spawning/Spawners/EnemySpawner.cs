using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Scripts.Enemy.Controller;
using Scripts.Pool;

namespace Scripts.Spawning
{
    public class EnemySpawner : ISpawner
    {
        private GenericPool<EnemyBase> enemyPool;
        private List<Transform> spawnPos;
        private EnemyBase[] enemies;
        private MonoBehaviour mono;
        private Transform enemyHolder;

        private int maxEnemyCount = 10;

        public EnemySpawner(GenericPool<EnemyBase> _enemyPool, List<Transform> _spawnPos, Transform _enemyHolder, MonoBehaviour _mono, EnemyBase[] _enemies)
        {
            enemyPool = _enemyPool;
            spawnPos = _spawnPos;
            enemies = _enemies;
            mono = _mono;
            enemyHolder = _enemyHolder;

            PrespawnEnemies();
        }

        public void Spawn()
        {
            mono.StartCoroutine(SpawnEnemies());
        }

        private void PrespawnEnemies()
        {
            for (int i = 0; i < maxEnemyCount; i++)
            {
                EnemyBase enemy = MonoBehaviour.Instantiate(enemies[Random.Range(0, enemies.Length)]);
                enemy.InjectPool(enemyPool);
                enemy.gameObject.SetActive(false);
                enemyPool.SetInstance(enemy);
            }
        }

        private IEnumerator SpawnEnemies()
        {
            while (true)
            {
                if (!enemyPool.IsPoolEmpty())
                {
                    EnemyBase enemy = enemyPool.GetInctance();
                    enemy.transform.position = spawnPos[Random.Range(0, spawnPos.Count)].position;
                    enemy.gameObject.SetActive(true);
                    enemy.RestoreEnemy();
                    yield return null;
                }
                yield return new WaitForSeconds(1f);
            }
        }
    }
}