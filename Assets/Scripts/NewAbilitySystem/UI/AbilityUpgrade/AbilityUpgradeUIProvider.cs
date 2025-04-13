using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.UI
{
    public class AbilityUpgradeUIProvider: MonoBehaviour
    {
        [SerializeField] private RectTransform _containerWidgets;
        [SerializeField] private GameObject _upgradePopup;

        public void Show(List<NewAbilityConfig> abilities, AbilityCastHandler castHandler)
        {
            gameObject.SetActive(true);

            foreach (Transform child in _containerWidgets)
            {
                Destroy(child.gameObject);
            }

            foreach (var ability in abilities)
            {
                var uiWidget = Instantiate(_upgradePopup, _containerWidgets);
                
                var popup = uiWidget.GetComponent<AbilityUpgradePopup>();
                popup.Setup(ability.IconImage, ability.Title);    
            }
        }
        
        /*
        public void TakeNewAbilities(List<NewAbility> abilities)
        {
            foreach (var ability in abilities)
            {
                AbilityUpgradePopup widget = Instantiate(
                    _upgradeWidget, _containerWidgets);
                
                widget.Setup(ability.IconImage, ability.Title);
            }
        }
        */
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}