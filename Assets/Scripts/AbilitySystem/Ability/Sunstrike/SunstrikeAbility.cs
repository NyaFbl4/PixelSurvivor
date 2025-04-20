using PixelSurvivor.NewAbilitySystem.Projectiles;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class SunstrikeAbility : PlayerAbility
    {
        private GameObject _player;

        private AbilityType _abilityType;
        
        private GameObject _projectile;
        private int _projectileDamage;
        private int _maxCurrentSunstrike;
        private float _radius;
        private float _liveTime;

        public SunstrikeAbility(AbilityType abilityType, 
            GameObject projectile, int projectileDamage, 
            int maxCurrentSunstrike, float radius, float liveTime)
        {
            _abilityType         = abilityType;
            _projectile          = projectile;
            _projectileDamage    = projectileDamage;
            _maxCurrentSunstrike = maxCurrentSunstrike;
            _radius              = radius;
            _liveTime            = liveTime;
        }
        
        public override void UpgradeAbility()
        {
            _maxCurrentSunstrike++;
            Debug.Log("Upgrade SunstrikeAbility");
        }
        
        public override void Added(GameObject player)
        {
            _player = player;
        }
        public override void ApplyCast()
        {
            for (var i = 0; i < _maxCurrentSunstrike; i++)
            {
                Vector2 randomPosition = GetRandomSpawnPosition();

                GameObject tornado = GameObject.Instantiate(
                    _projectile, randomPosition, Quaternion.identity);
                SunstrikeProjectile projectileComponent = tornado.GetComponent<SunstrikeProjectile>();

                if (projectileComponent != null)
                {
                    projectileComponent.SetDamage(_projectileDamage);
                    projectileComponent.SetLifeTime(_liveTime);
                }
            }
            
            ChangeCooldownTimer(CooldownTime);
            ChangeAbilityState(EAbilityState.Cooldown);
        }
        
        public override void EventTick(float deltaTick)
        {
            if (AbilityState == EAbilityState.Cooldown)
            {
                ChangeCooldownTimer(CooldownTimer - deltaTick);

                if (CooldownTimer <= 0.0f)
                {
                    ChangeAbilityState(EAbilityState.Ready);
                }
            }
        }
        
        private Vector2 GetRandomSpawnPosition()
        {
            float randomX = Random.Range(-_radius, _radius);
            float randomY = Random.Range(-_radius, _radius);

            var position = _player.transform.position;

            Vector2 randomSpawnPosition = new Vector2(
                position.x + randomX, position.y + randomY);
            
            return randomSpawnPosition;
        }
    }
}