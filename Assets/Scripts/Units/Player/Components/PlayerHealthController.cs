using System.Collections;
using UnityEngine;

namespace PixelSurvivor
{
    public class PlayerHealthController : MonoBehaviour, IDamage
    {
        [SerializeField] private int _health;
        [SerializeField] private bool _isImmortal;
        [SerializeField] private float _immortalDuration;
        
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
                StartImmortalStatus(); 
            }
            
            Debug.Log(_health);
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