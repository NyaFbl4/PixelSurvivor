using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class SunstrikeAbility : NewAbility
    {
        private GameObject _player;

        private AbilityType _abilityType;
        
        private GameObject _projectile;
        private int _projectileDamage;
        private int _maxCurrentSunstrike;
        private float _radius;

        public SunstrikeAbility(AbilityType abilityType, 
            GameObject projectile, int projectileDamage, 
            int maxCurrentSunstrike, float radius)
        {
            _abilityType = abilityType;
            _projectile = projectile;
            _projectileDamage = projectileDamage;
            _maxCurrentSunstrike = maxCurrentSunstrike;
            _radius = radius;
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
                ProjectileTornado projectileComponent = tornado.GetComponent<ProjectileTornado>();

                if (projectileComponent != null)
                {
                    projectileComponent.SetDamage(_projectileDamage);
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