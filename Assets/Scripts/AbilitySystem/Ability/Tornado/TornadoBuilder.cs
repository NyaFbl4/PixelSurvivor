namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class TornadoBuilder : AbilityBuilder
    {
        private readonly TornadoConfig _config;
        
        public TornadoBuilder(TornadoConfig config) : base(config)
        {
            _config = config;
        }
        
        public override void Make()
        {
            _ability = new TornadoAbility(_config.AbilityType,
                _config.PrefabProjectile, _config.Damage, 
                _config.MaxCurrentTornado, _config.Radius,
                _config.LiveTime, _config.TornadoSpeed);
            
            base.Make();
        }
    }
}