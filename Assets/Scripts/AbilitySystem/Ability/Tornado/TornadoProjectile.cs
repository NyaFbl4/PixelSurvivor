using System.Collections;
using PixelSurvivor.NewAbilitySystem.Projectiles;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class TornadoProjectile : ProjectilesController
    {
        //private float _delay; 
        private int _damage;
        private float _speed;
        private float _changeDirectionInterval = 1f;
        private Vector3 _targetDirection;

        private void Start()
        {
            // Устанавливаем начальное направление
            ChangeDirection();
            InvokeRepeating("ChangeDirection", _changeDirectionInterval, _changeDirectionInterval);
            //StartCoroutine(DestroyObjectAfterDelay());
        }

        private void Update()
        {
            // Двигаем торнадо в выбранном направлении
            transform.Translate(_targetDirection * _speed * Time.deltaTime);
        }

        public void SetParametrs(int damage, float speed, float changeDirectionInterval)
        {
            _damage = damage;
            _speed = speed;
            _changeDirectionInterval = changeDirectionInterval;
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
        
        private void ChangeDirection()
        {
            // Генерируем случайное направление
            float randomX = Random.Range(-1f, 1f);
            float randomY = Random.Range(-1f, 1f);
            _targetDirection = new Vector2(randomX, randomY).normalized; // Нормализуем вектор направления
        }
        
        /*
        private IEnumerator DestroyObjectAfterDelay()
        {
            // Ждем заданное время
            /yield return new WaitForSeconds(_delay);
        
            // Уничтожаем объект
            Destroy(gameObject);
        }
        */
    }
}