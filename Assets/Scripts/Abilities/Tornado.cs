using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PixelSurvivor
{
    public class Tornado : MonoBehaviour
    {
        [SerializeField] private TornadoConfig _config;
        
        private GameObject _projectile;
        
        private int _projectileDamage;
        private int _maxCurrentTornado;
        private float _cooldown; 
        private float _radius;

        private void Start()
        {
            _projectile = _config.prefabProjectile;
            _projectileDamage = _config.damage;
            _maxCurrentTornado = _config.currentProjectile;
            _cooldown = _config.cooldown;
            _radius = _config.radius;
            
            StartCoroutine(SpawnTornados());
        }

        private IEnumerator SpawnTornados()
        {
            while (true)
            {
                SpawnTornado();
                
                yield return new WaitForSeconds(_cooldown);
            }
        }

        private void SpawnTornado()
        {
            for (var i = 0; i < _maxCurrentTornado; i++)
            {
                Vector2 randomPosition = GetRandomSpawnPosition();

                GameObject tornado = Instantiate(_projectile, randomPosition, Quaternion.identity);
                ProjectileTornado projectileComponent = tornado.GetComponent<ProjectileTornado>();

                if (projectileComponent != null)
                {
                    projectileComponent.SetDamage(_projectileDamage);
                }
            }
        }
        
        private Vector2 GetRandomSpawnPosition()
        {
            float randomX = Random.Range(-_radius, _radius);
            float randomY = Random.Range(-_radius, _radius);

            Vector2 randomSpawnPosition = new Vector2(transform.position.x + randomX, transform.position.y + randomY);
            
            return randomSpawnPosition;
        } 
    }
}