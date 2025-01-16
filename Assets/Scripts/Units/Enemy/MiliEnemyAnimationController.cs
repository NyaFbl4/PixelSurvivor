using UnityEngine;

namespace PixelSurvivor
{
    public class MiliEnemyAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;  // Ссылка на Animator
        [SerializeField] private SpriteRenderer _sprite;  // Ссылка на SpriteRenderer
        [SerializeField] private float _moveSpeed;  // Скорость перемещения

        private bool _isMoving = false;  // Состояние передвижения
        private bool _isHurt = false;  // Состояние получения урона

        private void Start()
        {
            if (_animator == null) {
                _animator = GetComponent<Animator>();  // Привязка компонента Animator
            }
        }

        private void Update()
        {
            HandleAnimationState();  // Проверка и управление состоянием анимации
        }

        private void HandleAnimationState()
        {
            // Если персонаж в движении, устанавливаем анимацию движения
            if (_isMoving)
            {
                _animator.SetBool("IsMoving", true);
                _animator.SetBool("IsIdle", false);
            }
            else if (!_isMoving)
            {
                _animator.SetBool("IsIdle", true);
                _animator.SetBool("IsMoving", false);
            }

            // Если персонаж получил урон, воспроизводим анимацию урона
            if (_isHurt)
            {
                _animator.SetTrigger("Hurt");
                _isHurt = false;  // Сбрасываем флаг получения урона после воспроизведения анимации
            }
        }

        // Метод для установки состояния "Получение урона"
        public void TakeDamage()
        {
            _isHurt = true;
        }

        // Метод для управления состоянием "Движение"
        public void SetMoving(bool isMoving)
        {
            _isMoving = isMoving;
        }

        // Метод для управления направлением персонажа
        public void FlipSpriteDirection(Vector3 direction)
        {
            if (direction.x > 0)
            {
                _sprite.flipX = true;  // Поворот спрайта влево
            }
            else if (direction.x < 0)
            {
                _sprite.flipX = false;  // Поворот спрайта вправо
            }
        }
    }
}