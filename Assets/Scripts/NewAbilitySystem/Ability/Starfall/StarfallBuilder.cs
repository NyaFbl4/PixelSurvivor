namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class StarfallBuilder : AbilityBuilder
    {
        private readonly StarfallConfig _config;
        
        public StarfallBuilder(StarfallConfig config) : base(config)
        {
            _config = config;
        }

        public override void Make()
        {
            _ability = new StarfallAbility(_config.AbilityType,
                _config.PrefabProjectile, _config.Damage,
                _config.MaxCurrentShot, _config.RicochetShots, 
                _config.SpeedProjectile);
            
            base.Make();
        }
    }
}