using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor
{
    public class MiliEnemyAnimationController : MonoBehaviour, IEnemyAnimation
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _sprite;

        private bool _isMoving = false;
        public bool isHurt { get; private set; }

        private void Start()
        {
            if (_animator == null)
            {
                _animator = GetComponent<Animator>();
            }
        }

        private void Update()
        {
            HandleAnimationState();
        }

        private void HandleAnimationState()
        {
            if (_isMoving)
            {
                _animator.SetBool("IsMoving", true);
            }
            else if (!_isMoving)
            {
                _animator.SetBool("IsMoving", false);
            }

            if (isHurt)
            {
                _animator.SetTrigger("IsHurt");
            }
        }

        public void TakeDamage()
        {
            //Debug.Log("TakeDamage");

            isHurt = true;
            _isMoving = false;
        }

        public void SetHurt()
        {
            _animator.SetBool("IsHurt", false);

            if (isHurt)
            {
                isHurt = false;
            }
        }

        public void SetMoving(bool isMoving)
        {
            _isMoving = isMoving;
        }

        public void FlipSpriteDirection(Vector3 direction)
        {
            if (direction.x > 0)
            {
                _sprite.flipX = true;
            }
            else if (direction.x < 0)
            {
                _sprite.flipX = false;
            }
        }
    }
}
