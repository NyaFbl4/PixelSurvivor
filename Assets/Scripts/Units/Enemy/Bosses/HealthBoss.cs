using System;
using UnityEngine;

namespace PixelSurvivor
{
    public class HealthBoss : MonoBehaviour, IDamage
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private EnemyDamageUI _damageUi;
        private int _health;

        [SerializeField] private bool _isImmortalStatus;

        [SerializeField] private int _healthOnSwitchState;
        private bool _isInRage;
        
        [SerializeField] private Animator _animator;
        
        public event Action<bool> OnRagePhase;

        private void Start()
        {
            _isImmortalStatus = false;
            _health = _maxHealth;
            _isInRage = false;
        }

        public void SwitchImmortalStatus(int i)
        { 
            if (i == 1)
            {
                _isImmortalStatus = false;
            }
            else if (i == 0)
            {
                _isImmortalStatus = true;
            }
        }
        
        public void TakeDamage(int damage)
        {
            if (_isImmortalStatus)
            {
                return;
            }
            
            _health -= damage;

            if (_health > 0)
            {
                if (!_isInRage && _health <= _healthOnSwitchState)
                {
                    _animator.SetTrigger("SwitchState");
                    _isInRage = true;
                    OnRagePhase?.Invoke(_isInRage);
                }
                else
                {
                    _animator.SetTrigger("IsHurt");
                }
                
                _damageUi.ShowDamage(damage);
                _isImmortalStatus = true;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}