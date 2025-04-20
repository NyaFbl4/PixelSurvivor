using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem
{
    public class AbilityBuilder
    {
        private AbilityConfig _abilityConfig;
        protected PlayerAbility _ability;

        public AbilityBuilder(AbilityConfig abilityConfig)
        {
            _abilityConfig = abilityConfig;
        }

        public virtual void Make()
        {
            if (_ability != null)
            {
                 _ability.SetDescription(_abilityConfig.Title, _abilityConfig.IconImage);
                 _ability.SetCooldownTime(_abilityConfig.CooldownTime);
                 
                 _ability.ChangeAbilityState(EAbilityState.Ready);
            }
        }

        public virtual PlayerAbility GetResult() => _ability;
    }
}