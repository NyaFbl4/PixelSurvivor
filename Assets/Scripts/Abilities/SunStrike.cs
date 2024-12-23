using System.Collections;
using UnityEngine;

namespace PixelSurvivor
{
    public class SunStrike : MonoBehaviour
    {
        [SerializeField] private GameObject _projectileSunStrike;
        [SerializeField] private float _radius;

        [SerializeField] private int _projectileDamage;
        [SerializeField] private int _maxCurrentSunStrike;
        [SerializeField] private float _cooldown;

        private void Start()
        {
            StartCoroutine(SpawnSunStrikes());
        }

        private IEnumerator SpawnSunStrikes()
        {
            while (true)
            {
                //for (int i = 0; i < _maxCurrentSunStrike; i++)
                //{
                    SpawnSunStrike();

                    yield return new WaitForSeconds(_cooldown);
                //}
            }
        }
        
        private void SpawnSunStrike()
        {
            for (int i = 0; i < _maxCurrentSunStrike; i++)
            {
                Vector2 randomPosition = GetRandomSpawnPosition();

                GameObject projectile = Instantiate(_projectileSunStrike, randomPosition, Quaternion.identity);
                ProjectileSunStrike projectileComponent = projectile.GetComponent<ProjectileSunStrike>();

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