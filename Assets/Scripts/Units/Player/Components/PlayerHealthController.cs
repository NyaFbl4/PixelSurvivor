using System.Collections;
using UnityEngine;
using Zenject;

namespace PixelSurvivor
{
    public class PlayerHealthController : MonoBehaviour, IDamage
    {
        [SerializeField] private int _health;
        [SerializeField] private bool _isImmortal;
        [SerializeField] private float _immortalDuration;

        private CurrentHealthStorage _currentHealth;
        private MaxHealthStorage _maxHealth;

        [Inject]
        public void Construct(MaxHealthStorage maxHealth, CurrentHealthStorage currentHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = currentHealth;
            
            _maxHealth.AddMaxHealth(_health);
            _currentHealth.AddCurrentHealth(_health);
        }
        
        public void TakeDamage(int damage)
        {
            if(_isImmortal)
                return;

            _health -= damage;

            if (_health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _currentHealth.SpendCurrentHealth(damage);
                StartImmortalStatus(); 
            }
        }
        
        private void StartImmortalStatus()
        {
            _isImmortal = true;
            StartCoroutine(EndImmortalStatus());
        }
        
        private IEnumerator EndImmortalStatus()
        {
            yield return new WaitForSeconds(_immortalDuration); 
            _isImmortal = false; 
        }
    }
}