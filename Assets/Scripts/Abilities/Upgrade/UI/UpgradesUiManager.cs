using System.Collections.Generic;
using PixelSurvivor.UI;
using UnityEngine;

namespace PixelSurvivor
{
    public class UpgradesUiManager : MonoBehaviour
    {
        [SerializeField] private UpgradeUi _upgradeUiPrefab;
        [SerializeField] private UpgradesManager _upgradesManager;
        [SerializeField] private Transform _container;

        //[SerializeField] private AbilityPopupProvider _abilityPopupProvider;
        //[SerializeField] private int _maxUpgradeAbility;
        
        //public void Show(List<GameObject> abilities, GameObject playerAbilityContainer)
        public void Show(List<GameObject> abilities, GameObject playerAbilityContainer)
        {
            gameObject.SetActive(true);

            foreach (Transform child in _container)
            {
                Destroy(child.gameObject);
            }
            
            foreach (var ability in abilities)
            {
                var ui = Instantiate(_upgradeUiPrefab, _container);

                var upgrade = ability.GetComponent<Upgrade>();
                
                ui.Setup(upgrade.title, upgrade.icon, () => OnClickApply(ability, playerAbilityContainer));
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnClickApply(GameObject ability, GameObject playerAbilityContainer)
        {
            var upgrade = ability.GetComponent<Upgrade>();
            //var upgrade = ability.GetComponent<Upgrade>();
            ability = upgrade.Apply(playerAbilityContainer);
            
            _upgradesManager.OnUpgradeApplied(ability , upgrade.icon);//ability.GetComponent<Ability>(), upgrade.icon);
        }
    }
}