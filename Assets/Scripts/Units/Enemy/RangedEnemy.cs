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
        
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private float _shootingRange = 5f;
        [SerializeField] private float _cooldown;
        [SerializeField] private Transform _player;

        private void Start()
        {
            GameObject character = GameObject.FindGameObjectWithTag("Player");

            if (character != null)
            {
                _player = character.transform;
            }
        }

        private void Update()
        {
            // Вычисляем расстояние до игрока
            float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

            if (distanceToPlayer > _shootingRange)
            {
                // Если противник находится вне диапазона стрельбы, приближаемся к игроку
                MoveTowardsPlayer();
            }
            else
            {
                // Если противник в пределах диапазона стрельбы, стреляем по игроку
                Shoot();
            }
        }
        
        private void MoveTowardsPlayer()
        {
            // Движение к игроку
            Vector2 direction = (_player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, _player.position, _moveSpeed * Time.deltaTime);
        }

        private void ShootAtTarget(GameObject target)
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
        
        private void Shoot()
        {
            //Instantiate(_attakcBall, _firePoint.position, _firePoint.rotation);
        }
    }
}