using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor
{
    public class InfiniteWaveSpawner : MonoBehaviour
    {
        [Header("Основные настройки")]
        [SerializeField] private GameObject[] _enemyPrefabsPool;
        [SerializeField] private float _timeBetweenWaves;
        [SerializeField] private float _spawnRadius;
        [SerializeField] private Transform _player;
        private Camera _mainCamera;
        
        [Header("Прогрессия сложности")]
        [SerializeField] private int _startEnemyCount; // Стартовое кол-во врагов
        [SerializeField] private float _enemyCountMultiplier; // Множитель роста кол-ва врагов
        [SerializeField] private float _spawnRateIncrease; // Ускорение спавна (меньше = быстрее)

        private int _currentWave;
        private List<GameObject> _aliveEnemies = new();

        private void Start()
        {
            _mainCamera = Camera.main;
            StartCoroutine(SpawnWaves());
        }

        IEnumerator SpawnWaves()
        {
            while (true)
            {
                int enemiesInWave = Mathf.RoundToInt(
                    _startEnemyCount * Mathf.Pow(_enemyCountMultiplier, _currentWave));
                
                Debug.Log($"Волна {_currentWave + 1}. Врагов: {enemiesInWave}");

                for (int i = 0; i < enemiesInWave; i++)
                {
                    SpawnSingleEnemy();
                    yield return new WaitForSeconds(_timeBetweenWaves * _spawnRateIncrease);
                }

                _currentWave++;
            }
        }

        private void SpawnSingleEnemy()
        {
            if (_enemyPrefabsPool.Length == 0)
            {
                return;
            }

            GameObject enemyPrefab = _enemyPrefabsPool[Random.Range(0, _enemyPrefabsPool.Length)];

            Vector3 spawnPosition = GetRandomPosition();
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            _aliveEnemies.Add(enemy);
        }

        private Vector3 GetRandomPosition()
        {
            float cameraHeight = _mainCamera.orthographicSize * 2;
            float cameraWidth = cameraHeight * _mainCamera.aspect;
            
            Vector3 spawnPosition = Vector3.zero;
            bool validPosition = false;

            while (!validPosition)
            {
                spawnPosition = _player.position + (Vector3)Random.insideUnitCircle * _spawnRadius;
                
                if (spawnPosition.x < (_player.position.x - cameraWidth / 2) || 
                    spawnPosition.x > (_player.position.x + cameraWidth / 2) ||
                    spawnPosition.y < (_player.position.y - cameraHeight / 2) || 
                    spawnPosition.y > (_player.position.y + cameraHeight / 2))
                {
                    validPosition = true;
                }
            }

            return spawnPosition;
        }
    }
}