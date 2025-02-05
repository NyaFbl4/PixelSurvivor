using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelSurvivor.UI
{
    public class AbilityCooldown : MonoBehaviour
    {
        [SerializeField] private Image cooldownImage; // Изображение для отображения кулдауна
        [SerializeField] private Ability ability; // Ссылка на возможность

        private float currentCooldownTime; // Текущее время кулдауна
        private float maxCooldownTime; // Максимальное время кулдауна

        private void Start()
        {
            if (ability != null)
            {
                maxCooldownTime = ability.Cooldown; // Получаем кулдаун
                currentCooldownTime = maxCooldownTime; // Устанавливаем текущее время на максимальное
                cooldownImage.fillAmount = 1f; // Устанавливаем начальное значение заполнения
            }
        }

        void FixedUpdate()
        {
            if (currentCooldownTime > 0)
            {
                currentCooldownTime -= Time.deltaTime; // Уменьшаем текущий кулдаун
                cooldownImage.fillAmount = currentCooldownTime / maxCooldownTime; // Обновляем fill amount

                Debug.Log($"Cooldown: {currentCooldownTime}");
            }
            else if (currentCooldownTime <= 0)
            {
                //ability.ActivateAbility(); // Активируем способность
                StartCooldown(); // Запускаем новый кулдаун
            }
        }

        private void StartCooldown()
        {
            currentCooldownTime = ability.CalculateCooldown(); // Перезагружаем кулдаун
            cooldownImage.fillAmount = 1f; // Заполняем изображение
        }
    }
}