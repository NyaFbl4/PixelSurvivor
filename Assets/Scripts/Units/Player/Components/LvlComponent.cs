﻿using System;
using UnityEngine;
using Zenject;

namespace PixelSurvivor
{
    public class LvlComponent : MonoBehaviour
    {
        [SerializeField] private UpgradesManager _upgradeManager;
        
        [SerializeField] private int _lvl;
        [SerializeField] private int _experience;

        [SerializeField] private int[] _experienceLvl;

        private ExperienceStorage _storage;

        [Inject]
        public void Construct(ExperienceStorage storage)
        {
            _storage = storage;
            
            _storage.AddExperience(_experience);
        }
        
        public void AddExperience(int newExperience)
        {
            _storage.AddExperience(newExperience);
            _experience += newExperience;

            var newLvl = Array.FindLastIndex(_experienceLvl, e => _experience >= e);

            if (newLvl > _lvl)
            {
                _lvl = newLvl;
                LvlUp();
            }
            
            //_storage.AddExperience(_experience);
            
            Debug.Log("lvl: " + _lvl.ToString() + " exp: " + _experience.ToString());
        }

        [ContextMenu("AddExp")]
        void AddExp()
        {
            AddExperience(2);
        }

        private void LvlUp()
        {
            _upgradeManager.SuggestUpgrades();
        }
    }
}