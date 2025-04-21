using System;
using PixelSurvivor.NewAbilitySystem.UI;
using PixelSurvivor.Units.Player;
using UnityEngine;
using Zenject;

namespace PixelSurvivor
{
    public class LvlComponent : MonoBehaviour
    {
        [SerializeField] private AbilityUpgradeManager _upgradeManager;
        
        [SerializeField] private int _lvl;
        [SerializeField] private int _experience;

        [SerializeField] private int[] _experienceLvl;

        private int _newLvl;

        private PlayerExperienceData _playerExperienceData;
        private MaxExperienceStorage _maxStorage;

        [Inject]
        public void Construct(PlayerExperienceData playerExperienceData) //, MaxExperienceStorage maxStorage)
        {
            _playerExperienceData = playerExperienceData;
            
            Started();
            //_maxStorage = maxStorage;
            
            //_maxStorage.AddMaxExperience(_experienceLvl[_newLvl + 1]);
        }
        
        public void AddExperience(int newExperience)
        {
            _playerExperienceData.AddExperience(newExperience);
            _experience += newExperience;

            _newLvl = Array.FindLastIndex(_experienceLvl, e => _experience >= e);

            if (_newLvl > _lvl)
            {
                _lvl = _newLvl;
                LvlUp();
            }
        }

        private void Started()
        {
            Debug.Log("STARTED");
            _playerExperienceData.AddExperience(_experience);
            _playerExperienceData.AddMaxExperienceOnLvl(_experienceLvl[_newLvl + 1]);
        }
        
        private void LvlUp()
        {
            _upgradeManager.SuggestUpgrades();
            _playerExperienceData.AddMaxExperienceOnLvl(_experienceLvl[_newLvl + 1]);
        }
    }
}