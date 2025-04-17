namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class SunstrikeBuilder : AbilityBuilder
    {
        private readonly NewSunstrikeConfig _config;
        
        public SunstrikeBuilder(NewSunstrikeConfig config) : base(config)
        {
            _config = config;
        }
        
        public override void Make()
        {
            _ability = new SunstrikeAbility(_config.AbilityType,
                _config.PrefabProjectile, _config.Damage, 
                _config.MaxCurrentSunStrike, _config.Radius);
            
            base.Make();
        }
    }
}