using System;
using UnityEngine;

namespace PixelSurvivor
{
    public class EnemyMoveComponent : MonoBehaviour, IGameUpdateListener
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private Rigidbody2D _rigidbody;

        [SerializeField] private Transform _character;

        private void Start()
        {
            IGameListener.Register(this);
        }

        public void OnEnable()
        {
            GameObject character = GameObject.FindGameObjectWithTag("Player");

            if (character != null)
            {
                _character = character.transform;
            }
        }

        public void OnDisable()
        {
            IGameListener.Unregister(this);
        }

        public void OnUpdate(float deltaTime)
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            if (_character != null)
            {
                Vector3 vector3 = (_character.position - transform.position).normalized;
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
    }
}