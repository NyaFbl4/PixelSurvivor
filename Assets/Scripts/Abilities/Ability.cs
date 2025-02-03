using System.Collections;
using UnityEngine;

namespace PixelSurvivor
{
    public abstract class Ability: MonoBehaviour
    {
        // Метод для вычисления кулдауна
        protected abstract float CalculateCooldown();

        // Пример использования кулдауна
        protected IEnumerator ActivateWithCooldown()
        {
            while (true)
            {
                yield return new WaitForSeconds(CalculateCooldown());
                ActivateAbility();
            }
        }

        // Абстрактный метод для активации способности
        protected abstract void ActivateAbility();
    }
}