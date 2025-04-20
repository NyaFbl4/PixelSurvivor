using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    [CreateAssetMenu(menuName = "Game/Abilities/Health", fileName = "HealthConfig ")]
    public class HealthConfig : AbilityConfig
    {
        [SerializeField] private int _health;

        public int Health => _health;

        public override AbilityBuilder GetBuilder()
        {
            return new HealthBuilder(this);
        }
    }
}