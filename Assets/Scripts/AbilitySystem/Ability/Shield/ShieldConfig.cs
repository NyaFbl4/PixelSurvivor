using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    [CreateAssetMenu(menuName = "Game/Abilities/Shield", fileName = "ShieldConfig ")]
    public class ShieldConfig : AbilityConfig
    {
        [SerializeField] private GameObject _shield;
        [SerializeField] private float _timeAbility;
        
        public GameObject ShieldObject => _shield;
        public float TimeAbility => _timeAbility;
        
        public override AbilityBuilder GetBuilder()
        {
            return new ShieldBuilder(this);
        }
    }
}