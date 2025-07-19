using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class LaserAbility : PlayerAbility
    {
        private GameObject _laserContainer;
        private GameObject _player;

        private AbilityType _abilityType;
        
        private GameObject _projectile;
        private int _maxCurrentLasers;
        private float _radius;
        private float _liveTime;

        private List<GameObject> _lasersContainer = new ();

        public LaserAbility(AbilityType abilityType,
            GameObject projectile, int projectileDamage, 
            int currentLasers, GameObject shootPoints)
        {
            _abilityType = abilityType;
            _projectile = projectile;
            _maxCurrentLasers = currentLasers;
            _damage = projectileDamage;
            _laserContainer = shootPoints;
        }

        public override void Added(GameObject player)
        {
            _player = player;
            
            CreateObjectsAroundPoint(_player.transform.position, 8, 2);
        }
        
        public void CreateObjectsAroundPoint(Vector3 center, int count, 
            float radius, string objectName = "Point")
        {
            if (count <= 0)
            {
                Debug.LogError("Count must be positive!");
                return;
            }

            float angleStep = 360f / count; // Шаг угла между объектами

            for (int i = 0; i < count; i++)
            {
                // Вычисляем угол в радианах
                float angle = i * angleStep * Mathf.Deg2Rad;
            
                // Позиция на окружности
                Vector3 position = center + new Vector3(
                    Mathf.Cos(angle) * radius,
                    Mathf.Sin(angle) * radius,
                    0
                );

                // Создаем пустой объект
                GameObject point = new GameObject();
                point.transform.position = position;
            
                // Опционально: добавляем компоненты
                // point.AddComponent<SpriteRenderer>();
            }
        }

        public override void UpgradeAbility()
        {
            _damage++;
        }

        public override void ApplyCast()
        {
            for (var i = 0; i < _maxCurrentLasers; i++)
            {
                
            }
        }
    }
}