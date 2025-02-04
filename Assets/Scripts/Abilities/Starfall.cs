using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor
{
    public class Starfall : Ability, IUpgradeable
    {
        [SerializeField] private TargetTrackerComponent _targetTracker;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private StarfallConfig _config;

        private List<GameObject> targets;
        private GameObject _prefabProjectile;

        private int _ricochetShots;
        private int _projectileDamage;
        private int _maxCurrentShots;
        
        private float _projectileSpeed;
        private float _cooldown;
        
        [SerializeField] private float currentTime;

        private void Start()
        {
            _prefabProjectile = _config.prefabProjectile;
            _ricochetShots = _config.ricochetShots;
            _projectileDamage = _config.damage;
            _maxCurrentShots = _config.maxCurrentProjectile;
            _projectileSpeed = _config.speedProjectile;

            StartCoroutine(ActivateWithCooldown());
        }
        
        protected override float CalculateCooldown()
        {
            return _config.cooldown;
        }

        public void FixedUpdate()
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
            Debug.Log("shoot");
            GameObject projectile = Instantiate(_prefabProjectile, _shootPoint.position, _shootPoint.rotation);

            ProjectileStarfall projectileComponent = projectile.GetComponent<ProjectileStarfall>();

            if (projectileComponent != null)
            {
                //projectileComponent.SetDamage(_projectileDamage);
                //projectileComponent.SetRicochetShots(_ricochetShots);
                projectileComponent.SetParamets(_projectileDamage, _ricochetShots, _projectileSpeed);
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