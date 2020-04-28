﻿using UnityEngine;
using System.Collections;
using Scripts.Settings;

namespace Scripts.Enemy.Attack
{
    public class EnemyAttack : IAttack
    {
        private PlayerSettings playerSettings;
        private EnemySettings enemySettings;
        private Transform transform;
        private MonoBehaviour mono;
        private int playerLayer = 9;
        private float attackCoolDown = 2f;

        public EnemyAttack(PlayerSettings _playerSettings, EnemySettings _enemySettings ,Transform _transform, MonoBehaviour _mono)
        {
            playerSettings = _playerSettings;
            enemySettings = _enemySettings;
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
                    playerSettings.Health = playerSettings.Health - enemySettings.Damage * playerSettings.Defence;
                    yield return null;
                }

                yield return new WaitForSeconds(attackCoolDown);
            }
        }       
    }
}