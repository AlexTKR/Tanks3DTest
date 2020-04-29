using UnityEngine;
using Scripts.Enemy.Damage;
using System.Collections;

namespace Scripts.Player.Weapons
{
    public class SimpleShell : ShellBase
    {
        [SerializeField] private Rigidbody rb;

        private int enemyLayer = 10;
        private float pushingForce = 4000;
        private float shellLifeTime = 2f;

        public override void Fire()
        {
            rb.AddForce(transform.forward * pushingForce);
            StartCoroutine(WaitAndReturn());
        }

        private void FixedUpdate()
        {
            DetectEnemies();
        }

        private void DetectEnemies()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, transform.localScale.y, 1 << enemyLayer);

            if (hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    IDamagble damagble = hits[i].gameObject.GetComponent<IDamagble>();
                    damagble?.TakeDamage(damageAmount);
                }

                StopCoroutine(WaitAndReturn());
                ReturnToThePool();
            }
        }

        private void ReturnToThePool()
        {
            rb.velocity = Vector3.zero;
            gameObject.SetActive(false);
            shellPool.SetInstance(this);
        }

        IEnumerator WaitAndReturn()
        {
            yield return new WaitForSecondsRealtime(shellLifeTime);
            ReturnToThePool();
        }
    }
}