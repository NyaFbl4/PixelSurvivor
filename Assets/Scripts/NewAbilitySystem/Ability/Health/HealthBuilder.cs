namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class HealthBuilder : AbilityBuilder
    {
        private readonly HealthConfig _config;

        public HealthBuilder(HealthConfig config) : base(config)
        {
            _config = config;
        }

        public override void Make()
        {
            _ability = new HealthAbility(_config.Health);
            
            base.Make();
        }
    }
}