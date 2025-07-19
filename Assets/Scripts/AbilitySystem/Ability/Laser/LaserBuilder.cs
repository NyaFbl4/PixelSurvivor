namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class LaserBuilder : AbilityBuilder
    {
        private readonly LaserConfig _config;

        public LaserBuilder(LaserConfig config) : base(config)
        {
            _config = config;
        }

        public override void Make()
        {
            _ability = new LaserAbility(_config.AbilityType, 
                _config.PrefabProjectile, _config.Damage, 
                _config.CurrentLasers, _config.ContainerShootPoints);
            
            base.Make();
        }
    }
}