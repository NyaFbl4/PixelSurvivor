using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class OrbitalAbilityProjectile : MonoBehaviour
    {
        private float _lifeTime; 
        private int _damage;

        private void Start()
        {
            Destroy(this.gameObject, _lifeTime);
        }
        
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
    }
}