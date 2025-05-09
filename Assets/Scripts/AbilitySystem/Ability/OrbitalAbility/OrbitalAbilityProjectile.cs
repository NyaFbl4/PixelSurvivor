using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class OrbitalAbilityProjectile : MonoBehaviour
    {
        private int _damage;
        
        private ProjectilePool _pool;

        public void SetDamage(int damage)
        {
            _damage = damage;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                IDamage damageComponent = other.gameObject.GetComponent<IDamage>();
                if (damageComponent != null)
                {
                    damageComponent.TakeDamage(_damage);
                }
            }
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(ReturnToPool));
        }
        
        private void ReturnToPool()
        {
            if (_pool != null)
            {
                _pool.ReturnProjectile(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}