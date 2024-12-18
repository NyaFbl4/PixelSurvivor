using UnityEngine;

namespace PixelSurvivor
{
    public class ProjectileOrbitalAbility : MonoBehaviour
    {
        private int _damage;

        public void SetDamage(int damage)
        {
            _damage = damage;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //Debug.Log(other.gameObject.name);
            
            if (other.gameObject.CompareTag("Enemy"))
            {
                //Debug.Log(other.gameObject.name);
                
                IDamage damageComponent = other.gameObject.GetComponent<IDamage>();
                if (damageComponent != null)
                {
                    damageComponent.TakeDamage(_damage);
                }
            }
        }
    }
}