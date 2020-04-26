using UnityEngine;
using System.Collections;
using Scripts.Settings;

namespace Scripts.Enemy.Attack
{
    public class EnemyAttack : IAttack
    {
        private PlayerSettings playerSettings;
        private Transform transform;
        private MonoBehaviour mono;
        private float AttackRadious = 8f;
        private int playerLayer = 9;

        public EnemyAttack(PlayerSettings _playerSettings, Transform _transform, MonoBehaviour _mono)
        {
            playerSettings = _playerSettings;
            transform = _transform;
            mono = _mono;
        }

        public void Attack()
        {
            mono.StartCoroutine(EnemyAttackLogic());
        }

        private IEnumerator EnemyAttackLogic()
        {
            while (true)
            {
                Collider[] hits = Physics.OverlapBox(transform.position, transform.localScale, Quaternion.identity, 1 << playerLayer);

                foreach (var hit in hits)
                {
                    Debug.Log(hit.name);
                    yield return null;
                }

                yield return null;
            }
        }       
    }
}