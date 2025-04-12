using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PixelSurvivor.UI.Player.NewAbilityUi
{
    public class AbilitySlotPopup : MonoBehaviour //, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private GameObject _rootObject;
        [SerializeField] private Image _displayImage; 
        [SerializeField] private Image _cooldownImage; 
        //[SerializeField] private GameObject _borderImage;

        public void Show() => _rootObject.SetActive(true);
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
        
        /*
        public void OnPointerEnter(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }
        */
    }
}