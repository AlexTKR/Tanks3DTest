using UnityEngine;
using Scripts.Enemy.Damage;

namespace Scripts.Player.Weapons
{
    public class SimpleShell : ShellBase
    {
        [SerializeField] private Rigidbody rb;

        public override void Fire()
        {
            rb.AddForce(transform.forward * 4000);
        }

        private void FixedUpdate()
        {
            Collider[] hits = Physics.OverlapBox(transform.position, transform.localScale, Quaternion.identity, 1 << 10);

            if (hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    IDamagble damagble = hits[i].gameObject.GetComponent<IDamagble>();
                    damagble.TakeDamage(damageAmount);
                }
                gameObject.SetActive(false);
            }
        }
    }
}