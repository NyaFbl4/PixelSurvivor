using System;
using UniRx;
using UnityEngine;

namespace PixelSurvivor
{
    public class CooldownObserver : MonoBehaviour
    {
        [SerializeField] public Ability ability; // Ссылка на объект Ability
        //[SerializeField] private Upgrade _config;
        [SerializeField] private CooldownView _view;
        
        private void Start()
        {
            if (ability != null)
            {
                ability.OnCooldownChanged += HandleCooldownChanged; // Подписка на событие
                ability.OnMaxCooldownChanged += HandleMaxCooldownChanged; // Подписка на событие
                
                //_view.SetupCooldown(_config.Config);
            }
        }

        public void SetupCooldown(AbilityConfig config) //, Ability appliedUpgrade)
        {
            _view.SetupCooldown(config.Icon);
            //ability = appliedUpgrade;
        }

        private void HandleCooldownChanged(float currentCooldown)
        {
            _view.UpdateCurrentCooldown(currentCooldown);
        }

        private void HandleMaxCooldownChanged(float maxCooldown)
        {
            _view.UpdateMaxCooldown(maxCooldown);
        }

        private void OnDestroy()
        {
            if (ability != null)
            {
                ability.OnCooldownChanged -= HandleCooldownChanged; // Отписка от события
                ability.OnMaxCooldownChanged -= HandleMaxCooldownChanged; // Отписка от события
            }
        }
    }
}