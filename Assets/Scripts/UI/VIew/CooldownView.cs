﻿using UnityEngine;
using UnityEngine.UI;

namespace PixelSurvivor
{
    public class CooldownView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Image _cooldownImage;
        
        private float _currentCooldownTime; // Текущее время кулдауна
        private float _maxCooldownTime; // Максимальное время кулдауна

        public void SetupCooldown(Sprite spriteImage)
        {
            _icon.sprite = spriteImage;
        }

        public void UpdateMaxCooldown(float maxCooldown)
        {
            _maxCooldownTime = maxCooldown;
        }

        public void UpdateCurrentCooldown(float currentCooldown)
        {
            _currentCooldownTime = currentCooldown;
            
            Setter(_currentCooldownTime);
        }
        
        private void Setter(float currentCooldown)
        {
            _cooldownImage.fillAmount = _currentCooldownTime / _maxCooldownTime;
        }
    }
}