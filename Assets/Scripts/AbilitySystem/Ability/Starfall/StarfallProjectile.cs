using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Projectiles
{
    public class StarfallProjectile : ProjectilesController
    {
        [SerializeField] private TargetTrackerComponent _targetTrackerComponent;
        [SerializeField] private Transform _shootPoint;

        private GameObject _prefabProjectile;
        private int _projectileDamage;
        private int _ricochetShots;
        private float _projectileSpeed;

        private int _damage;

        private GameObject target;
        //[SerializeField] private float _cooldown;
        

        public StarfallProjectile(int ricochetShots)
        {
            _ricochetShots = ricochetShots;
        }

        public void SetParametrs(int damage, int ricochetShots, float speed)
        {
            _damage = damage;
            _ricochetShots = ricochetShots;
            _projectileSpeed = speed;
        }

        public void SetRicochetShots(int ricochetShots)
        {
            _ricochetShots = ricochetShots;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _targetTrackerComponent.GetIgnoreTarget(other.gameObject);

                IDamage damageComponent = other.gameObject.GetComponent<IDamage>();
                if (damageComponent != null)
                {
                    damageComponent.TakeDamage(_damage);
                }

                //_targetTrackerComponent.FindTarges();
                target = _targetTrackerComponent.GetFirstTarget();
                _ricochetShots--;

                if (_ricochetShots > 0)
                {
                    ShootAtTarget(target);

                    if (target == null)
                    {
                        Destroy(this.gameObject);
                    }
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }

        private void ShootAtTarget(GameObject target)
        {
            Rigidbody2D projectileRb = GetComponent<Rigidbody2D>();

            if (projectileRb != null)
            {
                Vector2 direction = (target.transform.position - _shootPoint.position).normalized;

                projectileRb.velocity = direction * _projectileSpeed;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }
}