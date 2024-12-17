using UnityEngine;

namespace PixelSurvivor
{
    public class ProjectileShooter : MonoBehaviour
    {
        private int _damage;

        public void SetDamage(int damage)
        {
            _damage = damage;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            //Debug.Log(other.gameObject.name);
            
            if (other.gameObject.CompareTag("Enemy")) // Проверяем, что это враг
            {
                Debug.Log(other.gameObject.name);
                // Обработка урона врагу
                IDamage damageComponent = other.gameObject.GetComponent<IDamage>();
                if (damageComponent != null)
                {
                    damageComponent.TakeDamage(_damage);
                }

                //Destroy(gameObject); // Уничтожаем пулю
            }
        }
    }
}