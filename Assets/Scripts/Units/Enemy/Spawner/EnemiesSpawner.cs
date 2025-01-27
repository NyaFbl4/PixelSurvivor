using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PixelSurvivor
{
    public class EnemiesSpawner : MonoBehaviour
    {
        [SerializeField] private Wave[] _waves;

        private int _waveIndex;

        private Wave CurrentWave => _waves[_waveIndex];
        
        private void Update()
        {
            if (Time.timeSinceLevelLoad > CurrentWave.spawnTime)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            int count = Random.Range(CurrentWave.countMin, CurrentWave.countMax + 1);

            for (int i = 0; i < count; i++)
            {
                Instantiate(CurrentWave.enemyPrefab);
            }
        }
    }
}