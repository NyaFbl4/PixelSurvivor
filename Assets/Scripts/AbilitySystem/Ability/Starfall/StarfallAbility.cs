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
        private readonly GameObject _prefabProjectile;
        private readonly int _projectileDamage;
        private int _maxCurrentShots;
        private readonly int _ricochetShots;
        private readonly float _projectileSpeed;
        private readonly float _liveTime;
        
        private ProjectilePool _projectilePool;
        private const int PoolInitialSize = 10;
        private Transform _projectilesContainer;


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
        
        private void InitializePoolContainer()
        {
            _projectilesContainer = new GameObject("StarfallContainer").transform;
            _projectilesContainer.SetParent(_player.transform);
            _projectilesContainer.localPosition = Vector3.zero;
            
            _projectilePool = new ProjectilePool(_prefabProjectile, PoolInitialSize, _projectilesContainer);
        }
        
        public override void Added(GameObject player)
        {
            _player = player;

            InitializePoolContainer();
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
            GameObject projectile = _projectilePool.GetProjectile();
            projectile.transform.position = _player.transform.position;
            projectile.transform.rotation = _player.transform.rotation;

            StarfallProjectile projectileComponent = 
                projectile.GetComponent<StarfallProjectile>();

            if (projectileComponent != null)
            {
                projectileComponent.SetParametrs(_projectileDamage, _ricochetShots, _projectileSpeed);
                projectileComponent.SetLifeTime(_liveTime);
                projectileComponent.SetPool(_projectilePool);
                
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