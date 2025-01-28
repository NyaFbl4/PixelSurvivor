using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PixelSurvivor
{
    public class EnemiesSpawner : MonoBehaviour
    { 
        [SerializeField] private float _spawnRadius;
        [SerializeField] private Transform _center;
        [SerializeField] private Wave[] _waves;
        
        private int _waveIndex;

        private Wave CurrentWave => _waves[_waveIndex];
        private bool HasWaves => _waveIndex < _waves.Length;
        
        
        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
            StartCoroutine(SpawnWaves());
        }
        
        private IEnumerator SpawnWaves()
        {
            while (HasWaves)
            {
                yield return new WaitForSeconds(CurrentWave.spawnTime); // Ожидание времени волны
                Spawn();
                _waveIndex++;
            }
        }
        
        /*
        private void Update()
        {
            if (HasWaves && Time.timeSinceLevelLoad > CurrentWave.spawnTime)
            {
                Spawn();
                _waveIndex++;
            }
        }
        */

        private void Spawn()
        {
            int count = Random.Range(CurrentWave.countMin, CurrentWave.countMax + 1);

            for (int i = 0; i < count; i++)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition();
                Instantiate(CurrentWave.enemyPrefab, spawnPosition, Quaternion.identity);
            }
            
            /*
            int count = Random.Range(CurrentWave.countMin, CurrentWave.countMax + 1);

            for (int i = 0; i < count; i++)
            {
                var spawnPosition = _center.position + (Vector3)Random.insideUnitCircle* _spawnRadius;
                Instantiate(CurrentWave.enemyPrefab, spawnPosition, Quaternion.identity);
            }
            */
        }
        
        private Vector3 GetRandomSpawnPosition()
        {
            // Получаем границы камеры
            float cameraHeight = mainCamera.orthographicSize * 2;
            float cameraWidth = cameraHeight * mainCamera.aspect;

            // Генерируем позицию спавна вне области видимости камеры
            Vector3 spawnPosition = Vector3.zero;
            bool validPosition = false;

            while (!validPosition)
            {
                spawnPosition = _center.position + (Vector3)Random.insideUnitCircle * _spawnRadius;

                // Проверяем, находится ли позиция вне камеры
                if (spawnPosition.x < (_center.position.x - cameraWidth / 2) || 
                    spawnPosition.x > (_center.position.x + cameraWidth / 2) ||
                    spawnPosition.y < (_center.position.y - cameraHeight / 2) || 
                    spawnPosition.y > (_center.position.y + cameraHeight / 2))
                {
                    validPosition = true; // Позиция вне камеры валидная
                }
            }

            return spawnPosition;
        }
    }
}