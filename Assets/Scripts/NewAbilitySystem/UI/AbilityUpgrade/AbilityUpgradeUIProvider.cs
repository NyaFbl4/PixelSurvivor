using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.UI
{
    public class AbilityUpgradeUIProvider: MonoBehaviour
    {
        [SerializeField] private RectTransform _containerWidgets;
        [SerializeField] private AbilityUpgradePopup _upgradePopup;

        private AbilityStorage _abilityStorage;

        public void Show(List<NewAbilityConfig> abilities, AbilityStorage abilityStorage)
        {
            gameObject.SetActive(true);

            _abilityStorage = abilityStorage;
            foreach (Transform child in _containerWidgets)
            {
                Destroy(child.gameObject);
            }

            foreach (NewAbilityConfig ability in abilities)
            {
                var uiWidget = Instantiate(_upgradePopup, _containerWidgets);
                
                var popup = uiWidget.GetComponent<AbilityUpgradePopup>();
                popup.Setup(ability.IconImage, ability.Title, () => OnClickApply(ability));    
            }
        }
        
        private void OnClickApply(NewAbilityConfig ability)
        {
            _abilityStorage.AddAbility(ability);
            Hide();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}