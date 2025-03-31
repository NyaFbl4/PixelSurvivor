using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor
{
    public class MagmaMageController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private int _damage;
        [SerializeField] private Transform _shootPoint;
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
        }

        public void Attack2()
        {
            GameObject projectile = Instantiate(_prefabProjectile, _shootPoint.position, _shootPoint.rotation);

            AttackBall projectileComponent = projectile.GetComponent<AttackBall>();

            if (projectileComponent != null)
            {
                projectileComponent.SetDamage(_damage);

                Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

                if (projectileRb != null)
                {
                    Vector2 direction = (_player.transform.position - _shootPoint.position).normalized;
                    projectileRb.velocity = direction * _projectileSpeed;

                    float angle = Mathf.Atan2(direction.y, direction.x);
                    projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                }
            }
        }
    }
}