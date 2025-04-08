using UnityEngine;

namespace PixelSurvivor
{
    public class RangetEnemyAnimationController : MonoBehaviour, IEnemyAnimation
    {
        [SerializeField] private Animator _animator; 
        [SerializeField] private SpriteRenderer _sprite; 
        
        private bool _isMoving = false; 
        public bool isHurt { get; private set; }
        public bool isAttack { get; private set; }

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

            /*
            if (isAttack)
            {
                _animator.SetBool("Attack", true);
            }
            else if(!isAttack)
            {
                _animator.SetBool("Attack", false);
            }
            */
        }

        public void TakeDamage()
        {
            _animator.SetTrigger("IsHurt");
            
            //Debug.Log("TakeDamage");

            //isHurt = true;
            //_isMoving = false;
        }

        public void SetMoving(bool isMoving)
        {
            _isMoving = isMoving;
        }

        private void IsAttack()
        {
            if (isAttack)
            {
                isAttack = false;
            }
        }

        public void Attack()
        {
            if (!isAttack)
            {
                isAttack = true; 
            }
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