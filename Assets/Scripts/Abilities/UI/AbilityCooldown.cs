using UnityEngine;
using UnityEngine.UI;

namespace PixelSurvivor.UI
{
    public class AbilityCooldown : MonoBehaviour
    {
        [SerializeField] private Image _cooldownnImage;
        [SerializeField] private float _cooldown;

        void Update()
        {
            // Увеличиваем fillAmount каждую кадры
            _cooldownnImage.fillAmount += _cooldown * Time.deltaTime;

            // Если fillAmount достигает 1, сбрасываем его на 0
            if (_cooldownnImage.fillAmount >= 1f)
            {
                _cooldownnImage.fillAmount = 0f;
            }
        }
        
    }
}