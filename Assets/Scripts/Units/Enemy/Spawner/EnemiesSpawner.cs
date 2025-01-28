using System;
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
        
        private void Update()
        {
            if (HasWaves && Time.timeSinceLevelLoad > CurrentWave.spawnTime)
            {
                Spawn();
                _waveIndex++;
            }
        }

        private void Spawn()
        {
            int count = Random.Range(CurrentWave.countMin, CurrentWave.countMax + 1);

            for (int i = 0; i < count; i++)
            {
                var spawnPosition = _center.position + (Vector3)Random.insideUnitCircle* _spawnRadius;
                Instantiate(CurrentWave.enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}