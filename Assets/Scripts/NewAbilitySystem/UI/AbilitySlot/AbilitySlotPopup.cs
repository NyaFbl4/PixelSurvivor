using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PixelSurvivor.NewAbilitySystem.UI
{
    public class AbilitySlotPopup : MonoBehaviour //, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private GameObject _rootObject;
        [SerializeField] private Image _displayImage; 
        [SerializeField] private Image _cooldownImage; 
        //[SerializeField] private GameObject _borderImage;
        
        public void SetDisplayImage(Sprite displayImage) => _displayImage.sprite = displayImage;

        public void SetCooldown(float current, float max)
        {
            if (current <= 0.0f)
            {
                _cooldownImage.fillAmount = 0.0f;
            }
            else
            {
                _cooldownImage.fillAmount = current / max;
            }
        }
        
        public void Hide() => _rootObject.SetActive(false);
    }
}