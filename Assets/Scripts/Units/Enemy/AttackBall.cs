using UnityEngine;

namespace PixelSurvivor
{
    public class AttackBall : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime = 5f;
        [SerializeField] private int _damage;
        
        private void Start()
        {
            Destroy(gameObject, _lifeTime); // Уничтожаем пулю через определенное время
        }
        
        private void Update()
        {
            // Двигаем пулю вперед
            transform.Translate(Vector2.up * _speed * Time.deltaTime);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Логика столкновения
            if (other.CompareTag("Player")) // Если пуля попадает в игрока
            {
                IDamage damageComponent = other.gameObject.GetComponent<IDamage>();
                if (damageComponent != null)
                {
                    damageComponent.TakeDamage(_damage);
                }
                Destroy(gameObject); // Уничтожаем пулю при столкновении
            }
        }
    }
}