using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    [CreateAssetMenu(menuName = "Game/Abilities/Sunstrike", fileName = "SunstrikeConfig ")]
    public class NewSunstrikeConfig : NewAbilityConfig
    {
        [SerializeField] private GameObject _prefabProjectile;
        [SerializeField] private int _projectileDamage;
        [SerializeField] private int _maxCurrentSunStrike;
        [SerializeField] private float _radius;
        
        public GameObject PrefabProjectile => _prefabProjectile;
        public int Damage => _projectileDamage;
        public int MaxCurrentSunStrike => _maxCurrentSunStrike;
        public float Radius => _radius;
        
        public override AbilityBuilder GetBuilder()
        {
            return new SunstrikeBuilder(this);
        }
    }
}