using System.Collections;
using System.Collections.Generic;
using PixelSurvivor.ScoreManager;
using UnityEngine;
using Zenject;

namespace PixelSurvivor
{
    public class InfiniteWaveSpawner : MonoBehaviour
    {
        [Header("Основные настройки")]
        [SerializeField] private GameObject[] _enemyPrefabsPool;
        [SerializeField] private GameObject[] _enemyElitePrefabsPool;
        [SerializeField] private float _timeBetweenWaves;
        [SerializeField] private float _spawnRadius;
        [SerializeField] private Transform _player;

        [Header("Прогрессия сложности")]
        [SerializeField] private int _startEnemyCount; // Стартовое кол-во врагов
        [SerializeField] private float _enemyCountMultiplier; // Множитель роста кол-ва врагов
        [SerializeField] private float _spawnRateIncrease; // Ускорение спавна (меньше = быстрее)
        [SerializeField] private float _eliteChanceStart; // Начальный шанс элитных врагов
        [SerializeField] private float _eliteChanceGrowth; // Рост шанса за волну

        [Header("Настройки босса")]
        [SerializeField] private GameObject _boss;
        [SerializeField] private int _waveBossSpawn;
        private bool _bossSpawn;
        
        private Camera _mainCamera;
        private int _currentWave;
        private float _currentEliteChance;
        private List<GameObject> _aliveEnemies = new();
        
        private EnemyRewardSystem _rewardSystem;
        
        private void Start()
        {
            _mainCamera = Camera.main;
            _bossSpawn = false;
            StartCoroutine(SpawnWaves());
        }

        [Inject]
        public void Construct(EnemyRewardSystem enemyRewardSystem)
        {
            _rewardSystem = enemyRewardSystem;
        }

        IEnumerator SpawnWaves()
        {
            while (true)
            {
                if (_currentWave == _waveBossSpawn)
                {
                    SpawnBoss();
                }
                
                int enemiesInWave = Mathf.RoundToInt(
                    _startEnemyCount * Mathf.Pow(_enemyCountMultiplier, _currentWave));
                
                //Debug.Log($"Волна {_currentWave + 1}. Врагов: {enemiesInWave}");

                for (int i = 0; i < enemiesInWave; i++)
                {
                    SpawnSingleEnemy();
                    yield return new WaitForSeconds(_timeBetweenWaves * _spawnRateIncrease);
                }

                _currentWave++;
                _currentEliteChance = Mathf.Min(0.5f, _eliteChanceStart + (_eliteChanceGrowth * _currentWave));
            }
        }

        private void SpawnBoss()
        {
            var bossPrefab = _boss;
            Vector3 spawnPosition = GetRandomPosition();
            
            var enemy = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            _rewardSystem.RegisterEnemy(enemyController);
            _aliveEnemies.Add(enemy);
        }

        private void SpawnSingleEnemy()
        {
            if (_enemyPrefabsPool.Length == 0)
            {
                return;
            }

            GameObject enemyPrefab;
            
            if (Random.value < _currentEliteChance)
            {
                enemyPrefab = _enemyElitePrefabsPool[Random.Range(0, _enemyPrefabsPool.Length)];
            }
            else
            {
                enemyPrefab = _enemyPrefabsPool[Random.Range(0, _enemyPrefabsPool.Length)];
            }
            
            Vector3 spawnPosition = GetRandomPosition();
            var enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            _rewardSystem.RegisterEnemy(enemyController);
            _aliveEnemies.Add(enemy);
        }

        private Vector3 GetRandomPosition()
        {
            if (_player == null)
            {
                return Vector3.zero;
            }
            
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