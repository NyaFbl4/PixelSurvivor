using System;
using System.Collections;
using UniRx;
using UnityEngine;
using Zenject;

namespace PixelSurvivor
{
    public abstract class Ability: MonoBehaviour
    {
        public abstract float CalculateCooldown();

        private float _maxCooldown; // Текущий кулдаун
        private float _currentCooldown; // Таймер кулдауна

        public event Action<float> OnCooldownChanged; // Событие при изменении текущего кулдауна
        public event Action<float> OnMaxCooldownChanged; // Событие при изменении максимального кулдауна

        void Update()
        {
            // Уменьшаем таймер кулдауна, если он больше нуля
            if (_currentCooldown > 0)
            {
                _currentCooldown-= Time.deltaTime;
                OnCooldownChanged?.Invoke(_currentCooldown); 
                
                Debug.Log("cooldownTimer = " + _currentCooldown);
                Debug.Log("cooldown = " + _maxCooldown);
            }
            else if (_currentCooldown <= 0)
            {
                // Если кулдаун закончился, активируем способность
                ActivateAbility();
                StartCooldown(); // Запускаем новый кулдаун
            }
        }

        // Метод для начала кулдауна
        private void StartCooldown()
        {
            _maxCooldown = CalculateCooldown();
            OnMaxCooldownChanged?.Invoke(_maxCooldown);
            _currentCooldown = _maxCooldown;
        }
        
        protected abstract void ActivateAbility();
    }
}