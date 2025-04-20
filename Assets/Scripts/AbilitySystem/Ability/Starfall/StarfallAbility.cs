using System.Collections.Generic;
using PixelSurvivor.NewAbilitySystem.Projectiles;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class StarfallAbility : PlayerAbility
    {
        private GameObject _player;
        
        private TargetTrackerComponent _targetTracker;
        private List<GameObject> _targets;
        
        private AbilityType _abilityType;
        private GameObject _prefabProjectile;
        private int _projectileDamage;
        private int _maxCurrentShots;
        private int _ricochetShots;
        private float _projectileSpeed;
        private float _liveTime;


        public StarfallAbility(AbilityType abilityType,
            GameObject prefabProjectile, int projectileDamage,
            int maxCurrentShots, int ricochetShots,
            float projectileSpeed, float liveTime)
        {
            _abilityType      = abilityType;
            _prefabProjectile = prefabProjectile;
            _projectileDamage = projectileDamage;
            _maxCurrentShots  = maxCurrentShots;
            _ricochetShots    = ricochetShots;
            _projectileSpeed  = projectileSpeed;
            _liveTime         = liveTime;
        }
        
        public override void UpgradeAbility()
        {
            Debug.Log("Upgrade StarfallAbility");
            _maxCurrentShots++;
        }
        
        public override void Added(GameObject player)
        {
            _player = player;
            
            _targetTracker = _player.GetComponent<TargetTrackerComponent>();
        }
        
        public override void ApplyCast()
        {
            int shotsFired = 0;

            _targets = _targetTracker.GetCurrentTargets();
            
            if (_targets != null)
            {
                foreach (var target in _targets)
                {
                    if (shotsFired >= _maxCurrentShots)
                    {
                        break;
                    }

                    ShootAtTarget(target);
                    shotsFired++;
                    
                    ChangeCooldownTimer(CooldownTime);
                    ChangeAbilityState(EAbilityState.Cooldown);
                }
            }
        }

        public override void EventTick(float deltaTick)
        {
            if (AbilityState == EAbilityState.Cooldown)
            {
                ChangeCooldownTimer(CooldownTimer - deltaTick);

                if (CooldownTimer <= 0.0f)
                {
                    Debug.Log("FireBallAbility " + EAbilityState.Ready);
                    
                    ChangeAbilityState(EAbilityState.Ready);
                }
            }
        }
        
        private void ShootAtTarget(GameObject target)
        {
            //Debug.Log("shoot");
            GameObject projectile = Object.Instantiate(_prefabProjectile, 
                _player.transform.position, _player.transform.rotation);

            StarfallProjectile projectileComponent = 
                projectile.GetComponent<StarfallProjectile>();

            if (projectileComponent != null)
            {
                projectileComponent.SetParametrs(_projectileDamage, _ricochetShots, _projectileSpeed);
                projectileComponent.SetLifeTime(_liveTime);
                Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

                if (projectileRb != null)
                {
                    Vector2 direction = (target.transform.position - 
                                         _player.transform.position).normalized;
                    projectileRb.velocity = direction * _projectileSpeed;
                    
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Получаем угол
                    projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Устанавливаем вращение
                }
            }
        }
    }
}