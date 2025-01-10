using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor
{
    public class OrbitalAbility : MonoBehaviour
    {
        [SerializeField] private OrbitalAbilityConfig _config;

        private GameObject _projectile;
        
        private float _cooldown;
        private float _radius;
        private float _rotationSpeed;
        private float _duration;
        
        private int _projectileCount;
        private int _damage;

        private bool _isActive;

        private List<GameObject> _projectiles;

        private void Start()
        {
            _projectile = _config.prefabProjectile;
            _cooldown = _config.cooldown;
            _radius = _config.radius;
            _rotationSpeed = _config.rotationSpeed;
            _duration = _config.duration;
            _projectileCount = _config.currentProjectile;
            _damage = _config.damage;
            
            _isActive = true;
            _projectiles = new List<GameObject>();
            ActivateAbility();
        }

        public void UpgradeAbility()
        {
            _projectileCount++;
        }
        
        private IEnumerator AbilityCooldown()
        {
            yield return new WaitForSeconds(_cooldown);
            ActivateAbility();
        }

        private void ActivateAbility()
        {
            StartCoroutine(SpawnAndRotateProjectiles());
            _isActive = true;
        }

        private IEnumerator SpawnAndRotateProjectiles()
        {
            _projectiles = new List<GameObject>();

            for (int i = 0; i < _projectileCount; i++)
            {
                float angle = i * (360f / _projectileCount);
                Vector2 projectilePosition = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), 
                    Mathf.Sin(angle * Mathf.Deg2Rad)) * _radius;
                
                GameObject projectile = Instantiate(_projectile, 
                    (Vector2)transform.position + projectilePosition, Quaternion.identity);

                _projectiles.Add(projectile);

                ProjectileOrbitalAbility projectileOrbitalAbilityComponent =
                    projectile.GetComponent<ProjectileOrbitalAbility>();

                if (projectile != null)
                {
                    projectileOrbitalAbilityComponent.SetDamage(_damage);
                }
            }
            
            float elapsedTime = 0f;
            while (elapsedTime < _duration)
            {
                for (int i = 0; i < _projectileCount; i++)
                {
                    float angle = i * (360f / _projectileCount) + (elapsedTime / _duration * _rotationSpeed * 360f);
                    Vector2 orbPosition = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * _radius;
                    _projectiles[i].transform.position = (Vector2)transform.position + orbPosition;
                }

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Удаление шариков после завершения способности
            foreach (var orb in _projectiles)
            {
                Destroy(orb);
            }
            _projectiles.Clear(); // Очистка списка

            _isActive = false;
            StartCoroutine(AbilityCooldown());
        }
    }
}