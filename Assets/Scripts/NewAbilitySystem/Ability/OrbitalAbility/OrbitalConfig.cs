using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    [CreateAssetMenu(menuName = "Game/Abilities/OrbitalConfig", fileName = "OrbitalConfig ")]
    public class OrbitalConfig : NewAbilityConfig
    {
        [SerializeField] private GameObject _prefabProjectile;
        [SerializeField] private int _damage;
        [SerializeField] private int _projectileCount;
        [SerializeField] private float _radius;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _duration;
        
        public GameObject PrefabProjectile => _prefabProjectile;
        public int Damage => _damage;
        public int ProjectileCount => _projectileCount;
        public float Radius => _radius;
        public float RotationSpeed => _rotationSpeed;
        public float Duration => _duration;

        public override AbilityBuilder GetBuilder()
        {
            return new OrbitalBuilder(this);
        }
    }
}