using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class  OrbitalAbility : PlayerAbility
    {
        private GameObject _player;
        private AbilityType _abilityType;
        
        private GameObject _projectile;
        private float _radius;
        private float _rotationSpeed;
        private float _liveTime;
        private int _projectileCount;
        private int _damage;
        
        private List<GameObject> _projectiles;
        private MonoBehaviour _monobeh;
        
        public OrbitalAbility(AbilityType abilityType, 
            GameObject projectile, float radius, float rotationSpeed, 
            float liveTime, int projectileCount, int damage)
        {
            _abilityType     = abilityType;
            _projectile      = projectile;
            _radius          = radius;
            _rotationSpeed   = rotationSpeed;
            _liveTime        = liveTime;
            _projectileCount = projectileCount;
            _damage          = damage;
        }
        
        public override void Added(GameObject player)
        {
            _player = player;
            
            _monobeh = _player.GetComponent<MonoBehaviour>();
        }
        
        
        public override void UpgradeAbility()
        {
            Debug.Log("Upgrade FireBallAbility");
            
            _projectileCount++;
        }

        public override void ApplyCast()
        {
            SpawnProjectiles();
            _monobeh.StartCoroutine(RotateProjectiles(_projectileCount));
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
        
        /*
        private IEnumerator SpawnAndRotateProjectiles()
        {
            ChangeCooldownTimer(CooldownTime);
            ChangeAbilityState(EAbilityState.Cooldown);
            
            float elapsedTime = 0f;
            while (elapsedTime < _liveTime)
            {
                for (int i = 0; i < _projectileCount; i++)
                {
                    float angle = i * (360f / _projectileCount) + (elapsedTime / _liveTime * _rotationSpeed * 360f);
                    
                    Vector2 orbPosition = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), 
                        Mathf.Sin(angle * Mathf.Deg2Rad)) * _radius;
                    
                    _projectiles[i].transform.position = (Vector2)_player.transform.position + orbPosition;
                }

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            DestroyProjectiles(_projectiles);
        }
        */

        private IEnumerator RotateProjectiles(int countProjectile)
        {
            ChangeCooldownTimer(CooldownTime);
            ChangeAbilityState(EAbilityState.Cooldown);
            
            float elapsedTime = 0f;

            while (elapsedTime < _liveTime)
            {
                for (int i = 0; i < countProjectile; i++)
                {
                    float angle = i * (360f / countProjectile) + 
                                  (elapsedTime / _liveTime * _rotationSpeed * 360);
                    
                    Vector2 orbPosition = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), 
                        Mathf.Sin(angle * Mathf.Deg2Rad)) * _radius;
                    
                    _projectiles[i].transform.position = (Vector2)_player.transform.position + orbPosition;
                }
                
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            
            DestroyProjectiles(_projectiles);
        }
        
        private void SpawnProjectiles()
        {
            _projectiles = new List<GameObject>();

            for (int i = 0; i < _projectileCount; i++)
            {
                float angle = i * (360f / _projectileCount);
                Vector2 projectilePosition = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), 
                    Mathf.Sin(angle * Mathf.Deg2Rad)) * _radius;
                
                GameObject projectile = UnityEngine.Object.Instantiate(_projectile, 
                    (Vector2)_player.transform.position + projectilePosition, Quaternion.identity);

                _projectiles.Add(projectile);

                OrbitalAbilityProjectile projectileOrbitalAbilityComponent =
                    projectile.GetComponent<OrbitalAbilityProjectile>();

                if (projectile != null)
                {
                    projectileOrbitalAbilityComponent.SetDamage(_damage);
                }
            }
        }

        private void DestroyProjectiles(List<GameObject> projectiles)
        {
            foreach (var orb in projectiles)
            {
                UnityEngine.Object.Destroy(orb);
            }
            
            projectiles.Clear();
        }
    }
}