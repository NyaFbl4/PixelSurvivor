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

        public void SetupCooldown(Sprite icon, Ability newAbility)
        {
            _view.SetupCooldown(icon);
            ability = newAbility;
            StartWork();
        }

        private void StartWork()
        {
            if (ability != null)
            {
                ability.OnCooldownChanged += HandleCooldownChanged; // Подписка на событие
                ability.OnMaxCooldownChanged += HandleMaxCooldownChanged; // Подписка на событие
                Debug.Log("Подписка выполнена");
            }
            else
            {
                Debug.LogError("Ability is null!");
            }
        }
        
        private void HandleCooldownChanged(float currentCooldown)
        {
            //Debug.Log(currentCooldown);
            _view.UpdateCurrentCooldown(currentCooldown);
        }

        private void HandleMaxCooldownChanged(float maxCooldown)
        {
            //Debug.Log(maxCooldown);
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