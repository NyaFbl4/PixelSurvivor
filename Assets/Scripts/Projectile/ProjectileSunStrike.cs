using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace PixelSurvivor
{
    public class ProjectileSunStrike : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private bool _isAnimating = false;
        
        private int _damage = 10;
        
        public void SetDamage(int damage)
        {
            _damage = damage;
        }

        private void Start()
        {
            Execute();
        }

        private void Execute()
        {
            if (!_isAnimating)
            {
                _isAnimating = true;
                //_animator.SetTrigger("SunStrike"); // Запускаем анимацию
                StartCoroutine(DestroyAfterAnimation());
            }
        }
        
        private IEnumerator DestroyAfterAnimation()
        {
            yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);

            Destroy(gameObject);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                IDamage damageComponent = other.gameObject.GetComponent<IDamage>();
                if (damageComponent != null)
                {
                    damageComponent.TakeDamage(_damage);
                }
            }
        }
    }
}