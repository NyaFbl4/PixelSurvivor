using System.Collections;
using UnityEngine;
using Zenject;

namespace PixelSurvivor
{
    public class PlayerHealthController : MonoBehaviour, IDamage
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _currentHealth;
        
        [SerializeField] private bool _isImmortal;
        [SerializeField] private float _immortalDuration;

        private CurrentHealthStorage _currentHealthStorage;
        private MaxHealthStorage _maxHealthStorage;

        [Inject]
        public void Construct(MaxHealthStorage maxHealthStorage, 
            CurrentHealthStorage currentHealthStorage)
        {
            _currentHealth = _maxHealth;
            
            _maxHealthStorage = maxHealthStorage;
            _currentHealthStorage = currentHealthStorage;
            
            _maxHealthStorage.AddMaxHealth(_maxHealth);
            _currentHealthStorage.AddCurrentHealth(_currentHealth);
        }
        
        public void TakeDamage(int damage)
        {
            if(_isImmortal)
                return;

            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _currentHealthStorage.SpendCurrentHealth(_currentHealth);
                StartImmortalStatus(); 
            }
        }
        
        public void AddHealth(int health)
        {
            _currentHealth += health;
            _currentHealthStorage.AddCurrentHealth(_currentHealth);

            if (_currentHealth > _maxHealth)
            {
                _maxHealth = _currentHealth;
                _maxHealthStorage.AddMaxHealth(_maxHealth);
            }
            //Debug.Log("new Health = " + _health);
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