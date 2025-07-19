using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    [CreateAssetMenu(menuName = "Game/Abilities/Sunstrike", fileName = "SunstrikeConfig ")]
    public class SunstrikeConfig : AbilityConfig
    {
        [SerializeField] private GameObject _prefabProjectile;
        [SerializeField] private int _projectileDamage;
        [SerializeField] private int _maxCurrentSunStrike;
        [SerializeField] private float _radius;
        [SerializeField] private float _liveTime;

        public GameObject PrefabProjectile => _prefabProjectile;
        public int Damage => _projectileDamage;
        public int MaxCurrentSunStrike => _maxCurrentSunStrike;
        public float Radius => _radius;
        public float LiveTime => _liveTime;
        
        public override AbilityBuilder GetBuilder()
        {
            return new SunstrikeBuilder(this);
        }
    }
}