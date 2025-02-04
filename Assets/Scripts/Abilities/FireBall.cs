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
            
            StartCoroutine(ActivateWithCooldown());
        }

        protected override float CalculateCooldown()
        {
            return _config.cooldown;
        }
        
        private void Update()
        {
            targets = _targetTracker.GetCurrentTargets();
            
            /*
            if (targets.Count > 0 && _shootingCoroutine == null)
            {
                _shootingCoroutine = StartCoroutine(ShootAutomatically(targets));
            }
            else if (targets.Count == 0 && _shootingCoroutine != null)
            {
                StopCoroutine(_shootingCoroutine);
                _shootingCoroutine = null;
            }
            */
        }
        
        public void UpgradeAbility()
        {
            _maxCurrentShots++;
        }

        /*
        private IEnumerator ShootAutomatically(List<GameObject> targets)
        {
            while (true)
            {
                ShootAtTargets(targets);
                yield return new WaitForSeconds(_cooldown); 
            }
        }
        */

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