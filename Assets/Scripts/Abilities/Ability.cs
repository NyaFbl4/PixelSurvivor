using System;
using System.Collections;
using UnityEngine;

namespace PixelSurvivor
{
    public abstract class Ability: MonoBehaviour
    {
        // Метод для вычисления кулдауна
        public abstract float CalculateCooldown();

        private float cooldown; // Текущий кулдаун
        private float cooldownTimer; // Таймер кулдауна

        public float Cooldown => cooldown;
        public float CooldownTimer => cooldownTimer;
        
        void Update()
        {
            // Уменьшаем таймер кулдауна, если он больше нуля
            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime;
            }
            else if (cooldownTimer <= 0)
            {
                // Если кулдаун закончился, активируем способность
                ActivateAbility();
                StartCooldown(); // Запускаем новый кулдаун
            }
        }

        // Метод для начала кулдауна
        private void StartCooldown()
        {
            cooldown = CalculateCooldown();
            cooldownTimer = cooldown;
            Debug.Log("Cooldown started: " + cooldown);
        }

        // Метод для вычисления кулдауна
        //public abstract float CalculateCooldown();
        
        /*
        protected IEnumerator ActivateWithCooldown()
        {
            Debug.Log("Cooldown =" + CalculateCooldown());
            
            while (true)
            {
                yield return new WaitForSeconds(CalculateCooldown());
                ActivateAbility();
            }
        }
        */

        // Абстрактный метод для активации способности
        protected abstract void ActivateAbility();
    }
}