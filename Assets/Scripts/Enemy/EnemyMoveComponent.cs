using System;
using UnityEngine;

namespace PixelSurvivor
{
    public class EnemyMoveComponent : MonoBehaviour, IGameUpdateListener
    {
        [SerializeField] private float _moveSpeed;
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

        public void OnUpdate(float deltaTime)
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            if (_character != null)
            {
                float distance = Vector2.Distance(transform.position, _character.position);
                
                Vector3 direction = (_character.position - transform.position).normalized;
                
                transform.position += direction * _moveSpeed * Time.deltaTime;
            }
        }
    }
}