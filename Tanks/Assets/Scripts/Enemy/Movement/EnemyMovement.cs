using UnityEngine;
using UnityEngine.AI;
using Scripts.Settings;

namespace Scripts.Enemy.Movement
{
    public class EnemyMovement : IMovement
    {
        private EnemySettings enemySettings;
        private PositionHolder targetPosition;
        private Transform transform;
        private NavMeshAgent agent;
        private Vector3 offset = new Vector3(1.5f, 0, 1.5f);

        public EnemyMovement(EnemySettings _enemySettings, PositionHolder  _targetPosition, Transform _transform, NavMeshAgent _agent)
        {
            enemySettings = _enemySettings;
            targetPosition = _targetPosition;
            transform = _transform;
            agent = _agent;
        }

        public void Tick()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            float distance = Vector3.Distance(targetPosition.Value, transform.position);
           
            if (distance > agent.stoppingDistance)
            {
                agent.isStopped = false;
                agent.SetDestination(targetPosition.Value + offset);
            }
            else
            {
                agent.isStopped = true;
            }
        }
    }
}