using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    [CreateAssetMenu(menuName = "Game/Abilities/Tornado", fileName = "TornadoConfig ")]
    public class TornadoConfig : AbilityConfig
    {
        [SerializeField] private GameObject _prefabProjectile;
        [SerializeField] private int _damage;
        [SerializeField] private int _maxCurrentTornado;
        [SerializeField] private float _liveTime;
        [SerializeField] private float _radius;
        [SerializeField] private float _tornadoSpeed;
        
        public GameObject PrefabProjectile => _prefabProjectile;
        public int Damage => _damage;
        public int MaxCurrentTornado => _maxCurrentTornado;
        public float LiveTime => _liveTime;
        public float Radius => _radius;
        public float TornadoSpeed => _tornadoSpeed;

        public override AbilityBuilder GetBuilder()
        {
            return new TornadoBuilder(this);
        }
    }
}