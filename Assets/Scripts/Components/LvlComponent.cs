using System;
using UnityEngine;

namespace PixelSurvivor
{
    public class LvlComponent : MonoBehaviour
    {
        [SerializeField] private UpgradesManager _upgradeManager;
        
        [SerializeField] private int _lvl;
        [SerializeField] private int _experience;

        [SerializeField] private int[] _experienceLvl;

        public void AddExperience(int newExperience)
        {
            _experience += newExperience;

            var newLvl = Array.FindLastIndex(_experienceLvl, e => _experience >= e);

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