using UnityEngine;

namespace PixelSurvivor
{
    public class HealthBoss : MonoBehaviour, IDamage
    {
        [SerializeField] private int _health;
        [SerializeField] private bool _isImmortalStatus;
        [SerializeField] private Animator _animator;

        private void Start()
        {
            _isImmortalStatus = false;
        }

        public void SwitchImmortalStatus()
        {
            if (_isImmortalStatus)
            {
                _isImmortalStatus = false;
                _animator.SetBool("IsHurt", false);
            }
        }
        
        public void TakeDamage(int damage)
        {
            if (_isImmortalStatus)
            {
                return;
            }

            _animator.SetBool("IsHurt", true);
            _health -= damage;
            _isImmortalStatus = true;
        }
    }
}