using System;
using PixelSurvivor.Units.Player.Configs;
using UniRx;
using UnityEngine;
using Zenject;

namespace PixelSurvivor
{
    public class ExpereinceManager : MonoBehaviour
    {
        [SerializeField] private UpgradesManager _upgradeManager;
        
        [SerializeField] private int _lvl;
        [SerializeField] private long _experience;

        [SerializeField] private ExperienceConfig _config;

        private ValueView _view;
        private CurrentExperienceStorage _storage;
        private IDisposable _disposable;
        
        //[SerializeField] private int[] _experienceLvl;

        [Inject]
        public void Constuct(CurrentExperienceStorage storage)
        {
            _storage = storage;
            //_disposable = storage.Experience.SkipLatestValueOnSubscribe()Subscribe();
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