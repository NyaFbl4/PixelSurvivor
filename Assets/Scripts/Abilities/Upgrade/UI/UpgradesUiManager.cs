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

        [SerializeField] private AbilityPopupProvider _abilityPopupProvider;
        [SerializeField] private int _maxUpgradeAbility;
        
        public void Show(List<GameObject> abilities, GameObject playerAbilityContainer)
        {
            gameObject.SetActive(true);

            foreach (Transform child in _container)
            {
                Destroy(child.gameObject);
            }
            
            foreach (var ability in abilities)
            //for (int i = 0; i < _maxUpgradeAbility; i++)
            {
                var ui = Instantiate(_upgradeUiPrefab, _container);

                var upgrade = ability.GetComponent<Upgrade>();
                
                ui.Setup(upgrade.title, upgrade.icon, () => OnClickApply(ability, playerAbilityContainer));
                //ui.Setup(upgrades[i].title, upgrades[i].icon, () => OnClickApply(upgrades[i], playerAbilities));
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
            
            _upgradesManager.OnUpgradeApplied(ability.GetComponent<Ability>(), upgrade.icon);
        }
    }
}