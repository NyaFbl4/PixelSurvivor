using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class ProjectilePool 
    {
        private Queue<GameObject> _pool = new();
        private GameObject _prefab;
        private Transform _parent;

        public ProjectilePool(GameObject prefab, int initialSize, Transform parent = null)
        {
            _prefab = prefab;
            _parent = parent;

            for (int i = 0; i < initialSize; i++)
            {
                GameObject projectile = CreateNewProjectile();
                _pool.Enqueue(projectile);
            }
        }

        private GameObject CreateNewProjectile()
        {
            GameObject projectile = UnityEngine.Object.Instantiate(_prefab, 
                Vector3.zero, Quaternion.identity, _parent);
            
            projectile.SetActive(false);
            return projectile;
        }

        public GameObject GetProjectile()
        {
            if (_pool.Count == 0)
            {
                return CreateNewProjectile();
            }

            GameObject projectile = _pool.Dequeue();
            projectile.SetActive(true);
            return projectile;
        }

        public void ReturnProjectile(GameObject projectile)
        {
            projectile.SetActive(false);
            _pool.Enqueue(projectile);
        }
    }
}