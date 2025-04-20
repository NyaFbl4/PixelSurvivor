namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class SunstrikeBuilder : AbilityBuilder
    {
        private readonly SunstrikeConfig _config;
        
        public SunstrikeBuilder(SunstrikeConfig config) : base(config)
        {
            _config = config;
        }
        
        public override void Make()
        {
            _ability = new SunstrikeAbility(_config.AbilityType,
                _config.PrefabProjectile, _config.Damage, 
                _config.MaxCurrentSunStrike, _config.Radius, 
                _config.LiveTime);
            
            base.Make();
        }
    }
}