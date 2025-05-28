using UnityEngine;

namespace PixelSurvivor
{
    public class MagmaLaser : MonoBehaviour
    {
        [SerializeField] private int _damage;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
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