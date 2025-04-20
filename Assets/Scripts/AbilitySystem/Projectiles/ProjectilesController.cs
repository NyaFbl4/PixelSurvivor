using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Projectiles
{
    public abstract class ProjectilesController : MonoBehaviour, IProjectilesController
    {
        protected float lifeTime; 
        protected int _damage;

        public void SetDamage(int damage)
        {
            _damage = damage;
        }
        
        public void SetLifeTime(float livetime)
        {
            lifeTime = livetime;
            Destroy(this.gameObject, lifeTime);
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