using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PixelSurvivor
{
    public class UpgradesManager : MonoBehaviour
    {
        [SerializeField] private UpgradesUiManager _uiManager;
        [SerializeField] private Upgrade[] _upgrades;
        [SerializeField] private GameObject _playerAbilities; 

        [SerializeField] private List<Upgrade> _availableUpgrades;

        private void Awake()
        {
            _availableUpgrades = _upgrades.ToList();
        }
        
        public void SuggestUpgrades()
        {
            if (_availableUpgrades.Count > 0)
            {
                Time.timeScale = 0;
                _uiManager.Show(_availableUpgrades, _playerAbilities);
            }
        }

        public void OnUpgradeApplied(Upgrade appliedUpgrade)
        {
            _uiManager.Hide();
            _availableUpgrades.Remove(appliedUpgrade);
            Time.timeScale = 1;
        }
    }
}