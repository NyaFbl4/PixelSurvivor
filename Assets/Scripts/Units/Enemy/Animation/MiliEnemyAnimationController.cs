using UnityEngine;

namespace PixelSurvivor
{
    public class MiliEnemyAnimationController : MonoBehaviour, IEnemyAnimation
    {
        [SerializeField] private Animator _animator; 
        [SerializeField] private SpriteRenderer _sprite; 
        
        private bool _isMoving = false; 
        private bool _isHurt = false;

        private void Start()
        {
            if (_animator == null) {
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
            
            if (_isHurt)
            {
                _animator.SetTrigger("Hurt");
                _isHurt = false;
            }
        }
        
        public void TakeDamage()
        {
            Debug.Log("TakeDamage");

            _isHurt = true;
            _isMoving = false;
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