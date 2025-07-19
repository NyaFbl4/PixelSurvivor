using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{    
    [CreateAssetMenu(menuName = "Game/Abilities/Laser", fileName = "LaserConfig ")]
    public class LaserConfig : AbilityConfig
    {
        [SerializeField] private GameObject _prefabProjectile;
        [SerializeField] private int _projectileDamage;
        [SerializeField] private int _currentLasers;
        [SerializeField] private GameObject _containerShootPoints;

        public GameObject PrefabProjectile => _prefabProjectile;
        public int Damage => _projectileDamage;
        public int CurrentLasers => _currentLasers;
        public GameObject ContainerShootPoints => _containerShootPoints;

        public override AbilityBuilder GetBuilder()
        {
            return new LaserBuilder(this);
        }
    }
}