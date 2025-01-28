using System;
using UnityEngine;

namespace PixelSurvivor
{
    [Serializable]
    public class Wave
    {
        public float spawnTime;
        public EnemyController enemyPrefab;
        public int countMin, countMax;
    }
}