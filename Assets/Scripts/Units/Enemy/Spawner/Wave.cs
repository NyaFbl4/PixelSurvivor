using System;
using UnityEngine;

namespace PixelSurvivor
{
    [Serializable]
    public class Wave
    {
        [SerializeField] private float _startWave;
        [SerializeField] private float _stopWave;
        [SerializeField] private float _spawnTime;
        [SerializeField] private EnemyController _enemyPrefab;
        [SerializeField] private int _countMin; 
        [SerializeField] private int _countMax;
        
        public float StartWave => _startWave;
        public float StopWave => _stopWave;
        public float SpawnTime => _spawnTime;
        public EnemyController EnemyPrefab => _enemyPrefab;
        public int CountMin => _countMin; 
        public int CountMax => _countMax;
    }
}