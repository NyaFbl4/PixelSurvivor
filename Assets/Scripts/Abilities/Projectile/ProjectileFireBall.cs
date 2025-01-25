using System;
using Unity.VisualScripting;
using UnityEngine;

namespace PixelSurvivor
{
    public class ProjectileFireBall : MonoBehaviour
    {
        [SerializeField] private float _lifeTime = 5f; 
        private int _damage;

        private void Start()
        {
            Destroy(this.gameObject, _lifeTime);
        }

        public void SetDamage(int damage)
        {
            _damage = damage;
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

                Destroy(gameObject); 
            }
        }
    }
}