using System;
using PixelSurvivor.NewAbilitySystem.UI;
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

        private CurrentExperienceStorage _currentStorage;
        private MaxExperienceStorage _maxStorage;

        [Inject]
        public void Construct(CurrentExperienceStorage currentStorage, MaxExperienceStorage maxStorage)
        {
            _currentStorage = currentStorage;
            _maxStorage = maxStorage;
            
            _currentStorage.AddExperience(_experience);
            _maxStorage.AddMaxExperience(_experienceLvl[_newLvl + 1]);
        }
        
        public void AddExperience(int newExperience)
        {
            _currentStorage.AddExperience(newExperience);
            _experience += newExperience;

            _newLvl = Array.FindLastIndex(_experienceLvl, e => _experience >= e);

            if (_newLvl > _lvl)
            {
                _lvl = _newLvl;
                LvlUp();
            }
        }

        private void LvlUp()
        {
            _upgradeManager.SuggestUpgrades();
            _maxStorage.AddMaxExperience(_experienceLvl[_newLvl + 1]);
        }
    }
}