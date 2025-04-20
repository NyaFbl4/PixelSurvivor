namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class OrbitalBuilder : AbilityBuilder
    {
        private readonly OrbitalConfig _config;

        public OrbitalBuilder(OrbitalConfig config) : base(config)
        {
            _config = config;
        }
            
        public override void Make()
        {
            _ability = new OrbitalAbility(_config.AbilityType,
                _config.PrefabProjectile, _config.Radius, 
                _config.RotationSpeed, _config.LiveTime,
                _config.ProjectileCount, _config.Damage);
            
            base.Make();
        }
    }
}