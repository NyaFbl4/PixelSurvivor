using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor
{
    public class UpgradesUiManager : MonoBehaviour
    {
        [SerializeField] private UpgradeUi _upgradeUiPrefab;
        [SerializeField] private UpgradesManager _upgradesManager;
        [SerializeField] private Transform _container;
        
        public void Show(List<Upgrade> upgrades)
        {
            gameObject.SetActive(true);

            foreach (Transform child in _container)
            {
                Destroy(child.gameObject);
            }
            
            foreach (var upgrade in upgrades)
            {
                var ui = Instantiate(_upgradeUiPrefab, _container);
                ui.Setup(upgrade._title, upgrade._icon, () => OnClickApply(upgrade));
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnClickApply(Upgrade upgrade)
        {
            upgrade.Apply();
            _upgradesManager.OnUpgradeApplied(upgrade);
        }
    }
}