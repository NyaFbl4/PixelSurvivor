using System;
using UnityEngine;

namespace PixelSurvivor
{
    [Serializable]
    public class Wave
    {
        public float startWave;
        public float stopWave;
        public float spawnTime;
        public EnemyController enemyPrefab;
        public int countMin, countMax;
    }
}