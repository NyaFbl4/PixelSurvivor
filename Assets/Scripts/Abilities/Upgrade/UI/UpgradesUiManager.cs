﻿using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor
{
    public class UpgradesUiManager : MonoBehaviour
    {
        [SerializeField] private UpgradeUi _upgradeUiPrefab;
        [SerializeField] private UpgradesManager _upgradesManager;
        [SerializeField] private Transform _container;

        [SerializeField] private int _maxUpgradeAbility;
        
        public void Show(List<Upgrade> upgrades, GameObject playerAbilities)
        {
            gameObject.SetActive(true);

            foreach (Transform child in _container)
            {
                Destroy(child.gameObject);
            }
            
            foreach (var upgrade in upgrades)
            //for (int i = 0; i < _maxUpgradeAbility; i++)
            {
                var ui = Instantiate(_upgradeUiPrefab, _container);
                ui.Setup(upgrade.title, upgrade.icon, () => OnClickApply(upgrade, playerAbilities));
                //ui.Setup(upgrades[i].title, upgrades[i].icon, () => OnClickApply(upgrades[i], playerAbilities));
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnClickApply(Upgrade upgrade, GameObject playerAbilities)
        {
            upgrade.Apply(playerAbilities);
            _upgradesManager.OnUpgradeApplied(upgrade);
        }
    }
}