using System;
using UnityEngine;

namespace PixelSurvivor
{
    public class RangedEnemy : EnemyController
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private int _damage;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private GameObject _prefabProjectile;

        [SerializeField] private float _projectileSpeed;
        [SerializeField] private float _shootingRange = 5f;
        [SerializeField] private float _cooldown;
        [SerializeField] private Transform _player;

        [SerializeField] private float currentTime;
        [SerializeField] private int _health;
        
        [SerializeField] private GameObject _experience;
        [SerializeField] private RangetEnemyAnimationController _enemyAnimationController;
        [SerializeField] private EnemyDamageUI _enemyDamageUI;

        private void Start()
        {
             GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                _player = player.transform;
            }

            base.damageUI = _enemyDamageUI;
            base.health = _health;
            base.player = _player;
            base.moveSpeed = _moveSpeed;
            base.experience = _experience;
            base.damage = _damage;
            base.enemyAnimationController = _enemyAnimationController;

            currentTime = _cooldown;
        }

        private void FixedUpdate()
        {
            float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

            if (!_enemyAnimationController.isHurt)
            {
                if (distanceToPlayer > _shootingRange)
                {
                    _enemyAnimationController.SetMoving(false);
                    
                    MoveTowardsPlayer();
                    FollowTarget();
                }
                else
                {
                    MoveTowardsPlayer();
                    
                    _enemyAnimationController.SetMoving(false);

                    currentTime -= Time.deltaTime;
                    if (currentTime <= 0)
                    {
                        _enemyAnimationController.Attack();
                        ShootAtTarget(_player);
                        Debug.Log("is attack");
                        currentTime = _cooldown;
                    }
                }
            }
        }

        private void ShootAtTarget(Transform target)
        {
            GameObject projectile = Instantiate(_prefabProjectile, _shootPoint.position, _shootPoint.rotation);

            AttackBall projectileComponent = projectile.GetComponent<AttackBall>();

            if (projectileComponent != null)
            {
                projectileComponent.SetDamage(_damage);

                Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

                if (projectileRb != null)
                {
                    Vector2 direction = (target.transform.position - _shootPoint.position).normalized;
                    projectileRb.velocity = direction * _projectileSpeed;

                    float angle = Mathf.Atan2(direction.y, direction.x);
                    projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                }
            }
        }
    }
}