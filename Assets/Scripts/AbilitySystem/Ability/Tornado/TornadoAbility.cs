using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class TornadoAbility : PlayerAbility
    {
        private GameObject _player;

        private AbilityType _abilityType;
        
        private GameObject _projectile;
        //private int _projectileDamage;
        private int _maxCurrentTornado;
        private float _radius;
        private float _liveTime;
        private float _tornadoSpeed;

        public TornadoAbility(AbilityType abilityType, 
            GameObject projectile, int projectileDamage, 
            int maxCurrentTornado, float radius, 
            float liveTime, float tornadoSpeed)
        {
            _abilityType       = abilityType;
            _projectile        = projectile;
            _damage  = projectileDamage;
            _maxCurrentTornado = maxCurrentTornado;
            _radius            = radius;
            _liveTime          = liveTime;
            _tornadoSpeed      = tornadoSpeed;
        }
        
        public override void UpgradeAbility()
        {
            _maxCurrentTornado++;
            Debug.Log("Upgrade TornadoAbility");
        }
        
        public override void Added(GameObject player)
        {
            _player = player;
        }
        
        public override void ApplyCast()
        {
            for (var i = 0; i < _maxCurrentTornado; i++)
            {
                Vector2 randomPosition = GetRandomSpawnPosition();

                GameObject tornado = GameObject.Instantiate(
                    _projectile, randomPosition, Quaternion.identity);
                TornadoProjectile projectileComponent = tornado.GetComponent<TornadoProjectile>();

                if (projectileComponent != null)
                {
                    //projectileComponent.SetDamage(_projectileDamage);
                    projectileComponent.SetLifeTime(_liveTime);
                    projectileComponent.SetParametrs(_damage, _tornadoSpeed);
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