using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace PixelSurvivor
{
    public class FireBall : Ability, IUpgradeable
    {
        [SerializeField] private TargetTrackerComponent _targetTracker;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private FireBallConfig _config;

        private List<GameObject> targets;
        private GameObject _prefabProjectile;
        
        private int _projectileDamage;
        private int _maxCurrentShots;
        
        private float _projectileSpeed;
        private float _cooldown;
        
        //private Coroutine _shootingCoroutine;

        private void Start()
        {
            _prefabProjectile = _config.prefabProjectile;
            _projectileDamage = _config.damage;
            _maxCurrentShots = _config.currentProjectile;
            _projectileSpeed = _config.speedProjectile;
            _cooldown = _config.cooldown;
            
            //StartCoroutine(ActivateWithCooldown());
        }

        public override float CalculateCooldown()
        {
            return _cooldown;
        }
        
        private void FixedUpdate()
        {
            targets = _targetTracker.GetCurrentTargets();
        }
        
        public void UpgradeAbility()
        {
            _maxCurrentShots++;
        }

        protected override void ActivateAbility()
        {
            int shotsFired = 0;

            foreach (var target in targets)
            {
                if (shotsFired >= _maxCurrentShots)
                {
                    break;
                }

                ShootAtTarget(target);
                shotsFired++;
            }
        }

        private void ShootAtTarget(GameObject target)
        {
            GameObject projectile = Instantiate(_prefabProjectile, _shootPoint.position, _shootPoint.rotation);

            ProjectileFireBall projectileComponent = projectile.GetComponent<ProjectileFireBall>();

            if (projectileComponent != null)
            {
                projectileComponent.SetDamage(_projectileDamage);

                Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

                if (projectileRb != null)
                {
                    Vector2 direction = (target.transform.position - _shootPoint.position).normalized;
                    projectileRb.velocity = direction * _projectileSpeed;
                    
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Получаем угол
                    projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Устанавливаем вращение
                }
            }
        }
    }
}