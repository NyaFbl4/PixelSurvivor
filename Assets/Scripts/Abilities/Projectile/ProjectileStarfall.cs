using UnityEngine;

namespace PixelSurvivor
{
    public class ProjectileStarfall : MonoBehaviour
    {
        private int _damage;

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

                Destroy(gameObject); 
            }
        }
    }
}