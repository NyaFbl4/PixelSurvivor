using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    [CreateAssetMenu(menuName = "Game/Abilities/Tornado", fileName = "TornadoConfig ")]
    public class TornadoConfig : NewAbilityConfig
    {
        [SerializeField] private GameObject _prefabProjectile;
        [SerializeField] private int _damage;
        [SerializeField] private int _maxCurrentTornado;
        [SerializeField] private float _radius;
        
        public GameObject PrefabProjectile => _prefabProjectile;
        public int Damage => _damage;
        public int MaxCurrentTornado => _maxCurrentTornado;
        public float Radius => _radius;

        public override AbilityBuilder GetBuilder()
        {
            return new TornadoBuilder(this);
        }
    }
}