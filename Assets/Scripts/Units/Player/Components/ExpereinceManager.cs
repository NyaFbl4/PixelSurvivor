﻿using System;
using PixelSurvivor.NewAbilitySystem.UI;
using PixelSurvivor.Units.Player.Configs;
using UniRx;
using UnityEngine;
using Zenject;

namespace PixelSurvivor
{
    public class ExpereinceManager : MonoBehaviour
    {
        [SerializeField] private AbilityUpgradeManager _upgradeManager;
        
        [SerializeField] private int _lvl;
        [SerializeField] private long _experience;

        [SerializeField] private ExperienceConfig _config;

        private ValueView _view;
        private CurrentExperienceStorage _storage;
        private IDisposable _disposable;
        

        [Inject]
        public void Construct(CurrentExperienceStorage storage)
        {
            _storage = storage;
        }
        
        public void AddExperience(int newExperience)
        {
            _experience += newExperience;

            var newLvl = Array.FindLastIndex(_config.experienceLvl, e => _experience >= e);

            if (newLvl > _lvl)
            {
                _lvl = newLvl;
                LvlUp();
            }
            
            Debug.Log("lvl: " + _lvl.ToString() + " exp: " + _experience.ToString());
        }

        private void LvlUp()
        {
            _upgradeManager.SuggestUpgrades();
        }
    }
}