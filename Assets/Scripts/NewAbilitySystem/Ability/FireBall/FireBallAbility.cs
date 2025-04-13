using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class FireBallAbility : NewAbility
    {
        private GameObject _player;
        
        private TargetTrackerComponent _targetTracker;
        private List<GameObject> _targets;
        private GameObject _prefabProjectile;
        private int _projectileDamage;
        private int _maxCurrentShots;
        private float _projectileSpeed;

        public FireBallAbility(GameObject prefabProjectile, 
            int projectileDamage, int maxCurrentShots, float projectileSpeed)
        {
            _prefabProjectile = prefabProjectile;
            _projectileDamage = projectileDamage;
            _maxCurrentShots  = maxCurrentShots;
            _projectileSpeed  = projectileSpeed;
        }
        
        public override void UpgradeAbility()
        {
            Debug.Log("Upgrade FireBallAbility");
        }

        public override void Added(GameObject player)
        {
            _player = player;
            
            _targetTracker = _player.GetComponent<TargetTrackerComponent>();
        }

        public override void ApplyCast()
        {
            int shotsFired = 0;

            Debug.Log("FireBallAbility");
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
                    Debug.Log("FireBallAbility " + EAbilityState.Ready);
                    
                    ChangeAbilityState(EAbilityState.Ready);
                }
            }
        }
        
        private void ShootAtTarget(GameObject target)
        {
            GameObject projectile = Object.Instantiate(_prefabProjectile, _player.transform.position, _player.transform.rotation);

            ProjectileFireBall projectileComponent = projectile.GetComponent<ProjectileFireBall>();

            _targetTracker.GetFirstTarget();
            
            if (projectileComponent != null)
            {
                projectileComponent.SetDamage(_projectileDamage);

                Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

                if (projectileRb != null)
                {
                    Vector2 direction = (target.transform.position - _player.transform.position).normalized;
                    projectileRb.velocity = direction * _projectileSpeed;
                    
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Получаем угол
                    projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Устанавливаем вращение
                }
            }
        }
    }
}