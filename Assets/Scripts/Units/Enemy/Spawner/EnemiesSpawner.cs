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
            yield return new WaitForSeconds(CurrentWave.SpawnTime);
            Spawn();
            
            _waveIndex++;
            
            //StartCoroutine(SpawnWaves());
        }
        
        /*
        private IEnumerator SpawnWaves()
        {
            while (HasWaves)
            {
                yield return new WaitForSeconds(CurrentWave.SpawnTime); 
                //Spawn();
                Debug.Log("EnumeratorSpawn");
                _waveIndex++;
            }
        }
        
        
        private void Update()
        {
            if (HasWaves && Time.timeSinceLevelLoad > CurrentWave.SpawnTime)
            {
                Spawn();
                Debug.Log("UpdateSpawn");
                _waveIndex++;
            }
        }
        */

        private void Spawn()
        {
            int countEnemy = Random.Range(CurrentWave.CountMin, CurrentWave.CountMax);
            Debug.Log("spawn");
            for (int i = 0; i < countEnemy; i++)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition();
                Instantiate(CurrentWave.EnemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
        
        private Vector3 GetRandomSpawnPosition()
        {
            float cameraHeight = mainCamera.orthographicSize * 2;
            float cameraWidth = cameraHeight * mainCamera.aspect;
            
            Vector3 spawnPosition = Vector3.zero;
            bool validPosition = false;

            while (!validPosition)
            {
                spawnPosition = _center.position + (Vector3)Random.insideUnitCircle * _spawnRadius;
                
                if (spawnPosition.x < (_center.position.x - cameraWidth / 2) || 
                    spawnPosition.x > (_center.position.x + cameraWidth / 2) ||
                    spawnPosition.y < (_center.position.y - cameraHeight / 2) || 
                    spawnPosition.y > (_center.position.y + cameraHeight / 2))
                {
                    validPosition = true;
                }
            }

            return spawnPosition;
        }
    }
}