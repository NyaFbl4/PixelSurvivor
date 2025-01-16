using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor
{
    public class Starfall : MonoBehaviour
    {
        [SerializeField] private TargetTrackerComponent _targetTracker;
        [SerializeField] private Transform _shootPoint;
        
        [SerializeField] private GameObject _prefabProjectile;
        [SerializeField] private int _projectileDamage;
        [SerializeField] private int _maxCurrentShots;
        
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private float _cooldown;
        
        [SerializeField] private float currentTime;

        public void FixedUpdate()
        {
            List<GameObject> targets = _targetTracker.GetCurrentTargets();

            if (targets.Count > 0)
            {
                currentTime -= Time.fixedDeltaTime;
                
                if (currentTime <= 0)
                {
                    ShootAtTargets(targets);

                    //ShootAtTarget(_player);
                    currentTime += _cooldown;
                }
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
            Debug.Log("shoot");
            GameObject projectile = Instantiate(_prefabProjectile, _shootPoint.position, _shootPoint.rotation);

            ProjectileStarfall projectileComponent = projectile.GetComponent<ProjectileStarfall>();

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