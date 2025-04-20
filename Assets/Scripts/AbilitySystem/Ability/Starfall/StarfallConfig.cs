using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    [CreateAssetMenu(menuName = "Game/Abilities/Starfall", fileName = "Starfall")]
    public class StarfallConfig : AbilityConfig
    {
        [SerializeField] private GameObject _prefabProjectile;
        [SerializeField] private int _damage;
        [SerializeField] private int _maxCurrentShot;
        [SerializeField] private int _ricochetShots;
        [SerializeField] private float _speedProjectile;

        public GameObject PrefabProjectile => _prefabProjectile;
        public int Damage => _damage;
        public int MaxCurrentShot => _maxCurrentShot;
        public int RicochetShots => _ricochetShots;
        public float SpeedProjectile => _speedProjectile;

        public override AbilityBuilder GetBuilder()
        {
            return new StarfallBuilder(this);
        }
    }
}