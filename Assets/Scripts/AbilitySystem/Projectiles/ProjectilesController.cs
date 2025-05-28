using System;
using PixelSurvivor.NewAbilitySystem.Ability;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Projectiles
{
    public abstract class ProjectilesController : MonoBehaviour, IProjectilesController
    {
        private float _lifeTime; 
        protected int _damage;
        
        protected ProjectilePool _pool;
        private float _time;
        
        public void SetDamage(int damage) => _damage = damage;
        public void SetLifeTime(float lifeTime) => _lifeTime = lifeTime;
        public void SetPool(ProjectilePool pool) => _pool = pool;

        private void FixedUpdate()
        {
            _time += Time.deltaTime;
            
            if (_time >= _lifeTime)
            {
                ReturnToPool();
            }
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                IDamage damageComponent = other.gameObject.GetComponent<IDamage>();
                if (damageComponent != null)
                {
                    damageComponent.TakeDamage(_damage);
                }

                Debug.Log("Return BaseProjectile");
                ReturnToPool();
            }
        }
        
        private void OnEnable()
        {
            _time = 0f; // Сбрасываем таймер
            
            if (_lifeTime > 0)
            {
                Invoke(nameof(ReturnToPool), _lifeTime);
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
                Debug.Log("ReturnToPool");
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}