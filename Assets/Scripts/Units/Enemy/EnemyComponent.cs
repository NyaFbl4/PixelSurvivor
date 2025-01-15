using System;
using UnityEngine;

namespace PixelSurvivor
{
    public class EnemyComponent : EnemyController//, IGameUpdateListener
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private int _damage = 1;

        [SerializeField] private Transform _player;

        private void Start()
        {
            //IGameListener.Register(this);
        }

        public void OnEnable()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                _player = player.transform;
            }
        }

        public void OnDisable()
        {
            //IGameListener.Unregister(this);
        }

        //public void Update(float deltaTime)
        public void Update()
        {
            FollowTarget();
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

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                IDamage damageComponent = other.gameObject.GetComponent<IDamage>();
                if (damageComponent != null)
                {
                    damageComponent.TakeDamage(_damage);
                }
            }
        }
    }
}