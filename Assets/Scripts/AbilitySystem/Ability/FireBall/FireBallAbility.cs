using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class FireBallAbility : PlayerAbility
    {
        private GameObject _player;
        private TargetTrackerComponent _targetTracker;
        private List<GameObject> _targets;
        
        private AbilityType _abilityType;
        private readonly GameObject _prefabProjectile;
        private readonly int _projectileDamage;
        private int _maxCurrentShots;
        private readonly float _projectileSpeed;
        private readonly float _liveTime;
        
        private ProjectilePool _projectilePool;
        private const int PoolInitialSize = 10;
        private Transform _projectilesContainer;

        public FireBallAbility(AbilityType abilityType, GameObject prefabProjectile,
            int projectileDamage, int maxCurrentShots, float projectileSpeed, float liveTime)
        {
            _abilityType      = abilityType;
            _prefabProjectile = prefabProjectile;
            _projectileDamage = projectileDamage;
            _maxCurrentShots  = maxCurrentShots;
            _projectileSpeed  = projectileSpeed;
            _liveTime         = liveTime;
        }
        
        private void InitializePoolContainer()
        {
            _projectilesContainer = new GameObject("FireBallContainer").transform;
            _projectilesContainer.SetParent(_player.transform);
            _projectilesContainer.localPosition = Vector3.zero;
            
            _projectilePool = new ProjectilePool(_prefabProjectile, PoolInitialSize, _projectilesContainer);
        }
        
        public override void UpgradeAbility()
        {
            _maxCurrentShots++;
            Debug.Log("Upgrade FireBallAbility");
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
            
            //_targetTracker.GetCurrentTargets();

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
                    ChangeAbilityState(EAbilityState.Ready);
                }
            }
        }
        
        private void ShootAtTarget(GameObject target)
        {
            GameObject projectile = _projectilePool.GetProjectile();
            projectile.transform.position = _player.transform.position;
            projectile.transform.rotation = _player.transform.rotation;

            FireBallProjectile projectileComponent = 
                projectile.GetComponent<FireBallProjectile>();
        
            if (projectileComponent != null)
            {
                projectileComponent.SetDamage(_projectileDamage);
                projectileComponent.SetLifeTime(_liveTime);
                projectileComponent.SetPool(_projectilePool);

                Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
                if (projectileRb != null)
                {
                    Vector2 direction = (target.transform.position - 
                                         _player.transform.position).normalized;
                    projectileRb.velocity = direction * _projectileSpeed;
                
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    projectile.transform.rotation = Quaternion.Euler(0, 0, angle);
                }
            }
            
            
            /*
            GameObject projectile = Object.Instantiate(_prefabProjectile, 
                _player.transform.position, _player.transform.rotation);

            FireBallProjectile projectileComponent = projectile.GetComponent<FireBallProjectile>();

            _targetTracker.GetFirstTarget();
            
            if (projectileComponent != null)
            {
                projectileComponent.SetDamage(_projectileDamage);
                projectileComponent.SetLifeTime(_liveTime);

                Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

                if (projectileRb != null)
                {
                    Vector2 direction = (target.transform.position - _player.transform.position).normalized;
                    projectileRb.velocity = direction * _projectileSpeed;
                    
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Получаем угол
                    projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Устанавливаем вращение
                }
            }
            */
        }
    }
}