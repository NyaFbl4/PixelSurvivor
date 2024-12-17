using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace PixelSurvivor
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private TargetTrackerComponent _targetTracker;

        [SerializeField] private Transform _shootPoint;
        [SerializeField] private GameObject _prefabProjectile;
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private int _projectileDamage;
        [SerializeField] private float _fireRate;
        [SerializeField] private int _maxCurrentShots;
        
        private Coroutine _shootingCoroutine;

        private void Update()
        {
            List<GameObject> targets = _targetTracker.GetCurrentTargets();
            
            if (targets.Count > 0 && _shootingCoroutine == null)
            {
                _shootingCoroutine = StartCoroutine(ShootAutomatically(targets));
            }
            else if (targets.Count == 0 && _shootingCoroutine != null)
            {
                StopCoroutine(_shootingCoroutine);
                _shootingCoroutine = null;
            }
        }

        private IEnumerator ShootAutomatically(List<GameObject> targets)
        {
            while (true)
            {
                ShootAtTargets(targets);
                yield return new WaitForSeconds(_fireRate); 
            }
        }

        private void ShootAtTargets(List<GameObject> targets)
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

            ProjectileShooter projectileComponent = projectile.GetComponent<ProjectileShooter>();

            if (projectileComponent != null)
            {
                projectileComponent.SetDamage(_projectileDamage);

                Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

                if (projectileRb != null)
                {
                    Vector2 direction = (target.transform.position - _shootPoint.position).normalized;
                    projectileRb.velocity = direction * _projectileSpeed;
                }
            }
        }
    }
}