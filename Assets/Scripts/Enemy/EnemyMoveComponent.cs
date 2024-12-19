using UnityEngine;

namespace PixelSurvivor
{
    public class EnemyMoveComponent : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Rigidbody2D _rigidbody;

        private Transform _character;

        private void OnEnable()
        {
            GameObject character = GameObject.FindGameObjectWithTag("Character");

            if (character != null)
            {
                _character = character.transform;
            }
        }

        private void Update()
        {
            
        }

        private void FollowTarget()
        {
            if (_character != null)
            {
                float distance = Vector2.Distance(transform.position, _character.position);
                
                // Рассчитываем направление к цели
                Vector3 direction = (_character.position - transform.position).normalized;
                
                direction.y = 0;
                
                // Обновляем позицию врага
                transform.position += direction * _moveSpeed * Time.deltaTime;

                // Проверяем, что направлению не равен нулевой вектор
                if (direction != Vector3.zero)
                {
                    // Вычисляем поворот объекта, чтобы он смотрел в направлении движения
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
            
                    // Плавный поворот между текущей и целевой ротацией
                    Quaternion newRotation = Quaternion.Slerp(_rigidbody.rotation, targetRotation, Time.fixedDeltaTime * _rotationSpeed);
                    _rigidbody.rotation = newRotation;
                }
            }
        }
    }
}