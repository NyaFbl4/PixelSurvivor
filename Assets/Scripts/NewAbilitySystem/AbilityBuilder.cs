namespace PixelSurvivor.NewAbilitySystem
{
    public class AbilityBuilder
    {
        private NewAbilityConfig _abilityConfig;
        protected NewAbility _ability;

        public AbilityBuilder(NewAbilityConfig abilityConfig)
        {
            _abilityConfig = abilityConfig;
        }

        public virtual void Make()
        {
            if (_ability != null)
            {
                 _ability.SetDescription(_abilityConfig.Title, _abilityConfig.IconImage);
                 _ability.SetCooldown(_abilityConfig.CooldownTime);
            }
        }

        public virtual NewAbility GetResult() => _ability;
    }
}