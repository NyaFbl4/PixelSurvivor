using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Projectiles
{
    public class StarfallProjectile : ProjectilesController
    {
        [SerializeField] private TargetTrackerComponent _targetTrackerComponent;
        [SerializeField] private Transform _shootPoint;

        private GameObject _prefabProjectile;
        private int _projectileDamage;
        [SerializeField] private int _ricochetShots;
        [SerializeField] private int _currentRicochet;
        private float _projectileSpeed;

        private GameObject target;
        
        public StarfallProjectile(int ricochetShots)
        {
            _ricochetShots = ricochetShots;
        }

        public void SetParametrs(int damage, int ricochetShots, float speed)
        {
            _damage = damage;
            _ricochetShots = ricochetShots;
            _currentRicochet = _ricochetShots;
            _projectileSpeed = speed;
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _targetTrackerComponent.GetIgnoreTarget(other.gameObject);
                _targetTrackerComponent.ClearIgnoreTargets();

                IDamage damageComponent = other.gameObject.GetComponent<IDamage>();
                if (damageComponent != null)
                {
                    damageComponent.TakeDamage(_damage);
                }
                
                target = _targetTrackerComponent.GetFirstTarget();
                _ricochetShots--;

                if (_ricochetShots > 0)
                {
                    if (target == null)
                    {
                        Debug.Log("Return StarfallProjectile");
                        base._pool.ReturnProjectile(gameObject);
                    }
                    
                    ShootAtTarget(target);
                }
                else
                {
                    Debug.Log("Return StarfallProjectile");
                    base._pool.ReturnProjectile(gameObject);
                }
            }
        }

        private void ShootAtTarget(GameObject target)
        {
            Rigidbody2D projectileRb = GetComponent<Rigidbody2D>();
            Vector2 direction;

            if (projectileRb != null)
            {
                if (target != null)
                { 
                    direction = (target.transform.position - _shootPoint.position).normalized;
                }
                else
                {
                    direction = (gameObject.transform.position - _shootPoint.position).normalized;
                }
                
                projectileRb.velocity = direction * _projectileSpeed;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }
}