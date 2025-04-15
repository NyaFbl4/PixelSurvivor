namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class FireBallBuilder : AbilityBuilder
    {
        private readonly FireBallConfig _config;
        
        public FireBallBuilder(FireBallConfig config) : base(config)
        {
            _config = config;
        }
        
        public override void Make()
        {
            _ability = new FireBallAbility(_config.AbilityType,
                _config.PrefabProjectile, _config.Damage, 
                _config.MaxCurrentShot, _config.SpeedProjectile);
            
            base.Make();
        }
    }
}