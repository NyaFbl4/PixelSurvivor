using UnityEngine;

namespace PixelSurvivor
{
    public class HealthBoss : MonoBehaviour, IDamage
    {
        [SerializeField] private int _maxHealth;
        private int _health;
        
        [SerializeField] private bool _isImmortalStatus;

        [SerializeField] private int _healthOnSwitchState;
        
        [SerializeField] private Animator _animator;

        private void Start()
        {
            _isImmortalStatus = false;
            _health = _maxHealth;
        }

        public void SwitchImmortalStatus(int i)
        {
            //_isImmortalStatus = parametr;

            
            if (i == 1)
            {
                _isImmortalStatus = false;
                Debug.Log("ImmortalStatus= " + _isImmortalStatus);
                //_animator.SetTrigger("IsHurt");
            }
            else if (i == 0)
            {
                _isImmortalStatus = true;
                Debug.Log("ImmortalStatus= " + _isImmortalStatus);
            }
            
        }
        
        public void TakeDamage(int damage)
        {
            if (_isImmortalStatus)
            {
                return;
            }
            
            _health -= damage;
            Debug.Log(_health);
            //_animator.SetTrigger("IsHurt");
            
            if (_health <= _healthOnSwitchState )
            {
               Debug.Log("SwitchState");
                _animator.SetTrigger("SwitchState");
            }
            else
            {

                _animator.SetTrigger("IsHurt");
            }

            _isImmortalStatus = true;
        }
    }
}