using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    [CreateAssetMenu(menuName = "Game/Abilities/Health", fileName = "HealthConfig ")]
    public class ShieldBuilder : AbilityBuilder
    {
        private readonly ShieldConfig _config;
        
        public ShieldBuilder(ShieldConfig config) : base(config)
        {
            _config = config;
        }

        public override void Make()
        {
            _ability = new ShieldAbility(_config.TimeAbility, _config.ShieldObject);

            base.Make();
        }
    }
}