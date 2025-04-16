using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    [CreateAssetMenu(menuName = "Game/Abilities/FireBall", fileName = "FireBallConfig ")]
    public class FireBallConfig : NewAbilityConfig
    {
        [SerializeField] private GameObject _prefabProjectile;
        [SerializeField] private int _damage;
        [SerializeField] private int _maxCurrentShot;
        [SerializeField] private float _speedProjectile;
        
        public GameObject PrefabProjectile => _prefabProjectile;
        public int Damage => _damage;
        public int MaxCurrentShot => _maxCurrentShot;
        public float SpeedProjectile => _speedProjectile;

        public override AbilityBuilder GetBuilder()
        {
            return new FireBallBuilder(this);
        }
    }
}