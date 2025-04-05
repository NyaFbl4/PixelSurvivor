using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor
{
    public class MagmaMageController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _shootPointAttack2;
        [SerializeField] private Transform _shootPointAttack3;
        
        [Header("Параметры босса")]
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _alignmentThreshold = 0.1f;
        [SerializeField] private float _attackRange;
        [SerializeField] private int _damage;
        
        [SerializeField] private bool _isInRage;

        [SerializeField] private GameObject _prefabProjectile;
        [SerializeField] private float _projectileSpeed;

        private Transform _player;

        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                _player = player.transform;
            }

            GetComponent<HealthBoss>().OnRagePhase += EnterRageMode;
            _isInRage = false;
        }

        public void Move()
        {
            if (_player.position.x < transform.position.x) 
            {
                // Игрок справа → поворачиваем вправо (обычно угол = 0)
                Flip(0); 
            }
            else 
            {
                // Игрок слева → поворачиваем влево (обычно угол = 180)
                Flip(180);
            }
            
            if(Mathf.Abs(_player.position.y - gameObject.transform.position.y) < _alignmentThreshold)
            {
                _animator.SetTrigger("MagmaLaser");
            }
            
            float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

            if (distanceToPlayer > _attackRange)
            {
                Vector2 direction = (_player.position - transform.position).normalized;
                

                
                Vector3 vector3 = (_player.position - transform.position).normalized;
            
                transform.position += vector3 * _moveSpeed * Time.deltaTime;
            }
            else
            {
                if (!_isInRage)
                {
                    _animator.SetTrigger("Attack_2");
                }
                else
                {
                    _animator.SetTrigger("Attack_3");
                }
            }
        }
        
        private void Attack2()
        {
            GameObject projectile = Instantiate(_prefabProjectile, _shootPointAttack2.position, _shootPointAttack2.rotation);

            AttackBall projectileComponent = projectile.GetComponent<AttackBall>();

            if (projectileComponent != null)
            {
                projectileComponent.SetDamage(_damage);

                Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

                if (projectileRb != null)
                {
                    Vector2 direction = (_player.transform.position - _shootPointAttack2.position).normalized;
                    projectileRb.velocity = direction * _projectileSpeed;

                    float angle = Mathf.Atan2(direction.y, direction.x);
                    projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                }
            }
        }

        private void Attack3()
        {
            int projectileCount = 5; // Количество снарядов
            float angleStep = 30f; // Угол между снарядами
            float startAngle = -angleStep * (projectileCount - 1) / 2f; // Начальный угол (центрирование)

            for (int i = 0; i < projectileCount; i++)
            {
                float currentAngle = startAngle + i * angleStep;
                ShootProjectile(currentAngle);
            }
        }

        private void ShootProjectile(float angleDegrees)
        {
            GameObject projectile = Instantiate(_prefabProjectile, _shootPointAttack3.position, Quaternion.identity);

            if (projectile.TryGetComponent(out AttackBall projectileComponent))
            {
                projectileComponent.SetDamage(_damage);

                if (projectile.TryGetComponent(out Rigidbody2D rb))
                {
                    // Направление с учетом угла
                    Vector2 baseDirection = (_player.transform.position - _shootPointAttack3.position).normalized;
                    Vector2 direction = Quaternion.Euler(0, 0, angleDegrees) * baseDirection;

                    rb.velocity = direction * _projectileSpeed;

                    // Поворот снаряда по направлению движения
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    projectile.transform.rotation = Quaternion.Euler(0, 0, angle);
                }
            }
        }

        private void Flip(float y)
        {
            transform.rotation = Quaternion.Euler(0f, y, 0f);
        }
        
        private void EnterRageMode(bool isRage)
        {
            if (_isInRage)
            {
                return;
            }

            _isInRage = isRage;
        }
    }
}