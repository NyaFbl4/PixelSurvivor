using System;
using UnityEngine;

namespace PixelSurvivor
{
    public class RangedEnemy : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private int _damage;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private GameObject _prefabProjectile;
        [SerializeField] private SpriteRenderer _sprite;
        
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private float _shootingRange = 5f;
        [SerializeField] private float _cooldown;
        [SerializeField] private Transform _player;
        //[SerializeField] private Transform _playerTransform;
        
        [SerializeField] private float currentTime;

        private bool isTrue = true;
        
        private void Start()
        {
             GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                _player = player.transform;
            }

            currentTime = _cooldown;
        }

        private void FixedUpdate()
        {
            float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

            if (distanceToPlayer > _shootingRange)
            {
                FollowTarget();
            }
            else
            {
                this.currentTime -= Time.fixedDeltaTime;
                if (this.currentTime <= 0)
                {
                    ShootAtTarget(_player);
                    this.currentTime += this._cooldown;
                }
            }
        }
        
        private void FollowTarget()
        {
            if (_player != null)
            {
                Vector3 vector3 = (_player.position - transform.position).normalized;
                if (vector3.x > 0)
                {
                    _sprite.flipX = true;
                }
                else if (vector3.x  < 0)
                {
                    _sprite.flipX = false;
                }

                transform.position += vector3 * _moveSpeed * Time.deltaTime;
            }
        }
        
        private void MoveTowardsPlayer()
        {
            Vector2 direction = (_player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, _player.position, _moveSpeed * Time.deltaTime);
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