using UnityEngine;

namespace PixelSurvivor.CameraController
{
    public class CameraController : MonoBehaviour
    {
        [Header("Основные настройки")]
        [SerializeField] private Transform _target;  // Цель (игрок)
        [SerializeField] private float _smoothTime = 0.3f;  // Время плавности
        [SerializeField] private Vector3 _offset = new Vector3(0, 0, -10);  // Смещение камеры
        
        [Header("Дополнительные параметры")]
        [SerializeField] private bool _enableBounds = false;
        [SerializeField] private Rect _cameraBounds;
        [SerializeField] private bool _lookAhead = true;
        [SerializeField] private float _lookAheadAmount = 2f;
        
        private Vector3 _velocity = Vector3.zero;
        private Vector3 _targetLastPosition;
        private Vector3 _lookAheadPos;

        private void Start()
        {
            if (_target == null)
            {
                Debug.LogError("Target not assigned for camera!");
                return;
            }
            
            _targetLastPosition = _target.position;
            transform.position = _target.position + _offset;
        }

        private void LateUpdate()
        {
            if (_target == null) return;

            // Рассчитываем опережение
            if (_lookAhead)
            {
                Vector3 targetMovement = (_target.position - _targetLastPosition).normalized;
                _lookAheadPos = Vector3.Lerp(_lookAheadPos, targetMovement * _lookAheadAmount, Time.deltaTime * 5f);
                _targetLastPosition = _target.position;
            }
            else
            {
                _lookAheadPos = Vector3.zero;
            }

            // Целевая позиция с учетом смещения и опережения
            Vector3 targetPosition = _target.position + _offset + _lookAheadPos;

            // Ограничение границами
            if (_enableBounds)
            {
                targetPosition.x = Mathf.Clamp(targetPosition.x, _cameraBounds.xMin, _cameraBounds.xMax);
                targetPosition.y = Mathf.Clamp(targetPosition.y, _cameraBounds.yMin, _cameraBounds.yMax);
            }

            // Плавное перемещение
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
        }

        // Установка новых границ камеры
        public void SetCameraBounds(Rect newBounds)
        {
            _cameraBounds = newBounds;
            _enableBounds = true;
        }

        // Визуализация границ в редакторе
        private void OnDrawGizmosSelected()
        {
            if (!_enableBounds) return;
            
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(new Vector3(
                _cameraBounds.center.x, 
                _cameraBounds.center.y, 0),
                new Vector3(_cameraBounds.width, _cameraBounds.height, 0));
        }
    }
}