using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor
{
    public class ProjectileTornado : MonoBehaviour
    {
        [SerializeField] private TornadoConfig _config;
        
        private int _damage;
        private float _speed = 1f; // Скорость движения торнадо
        private float _changeDirectionInterval = 1f; // Интервал изменения направления
        private Vector3 _targetDirection;

        private void Start()
        {
            // Устанавливаем начальное направление
            ChangeDirection();
            InvokeRepeating("ChangeDirection", _changeDirectionInterval, _changeDirectionInterval);
        }

        private void Update()
        {
            // Двигаем торнадо в выбранном направлении
            transform.Translate(_targetDirection * _speed * Time.deltaTime);
        }

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
        
        private void ChangeDirection()
        {
            // Генерируем случайное направление
            float randomX = Random.Range(-1f, 1f);
            float randomY = Random.Range(-1f, 1f);
            _targetDirection = new Vector2(randomX, randomY).normalized; // Нормализуем вектор направления
        }
    }
}