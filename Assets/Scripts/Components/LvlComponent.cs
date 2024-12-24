using System;
using UnityEngine;

namespace PixelSurvivor
{
    public class LvlComponent : MonoBehaviour
    {
        [SerializeField] private int _lvl;
        [SerializeField] private int _experience;

        [SerializeField] private int[] _experienceLvl;

        public void AddExperience(int newExperience)
        {
            _experience += newExperience;

            _lvl = Array.FindLastIndex(_experienceLvl, e => _experience >= e);
            
            Debug.Log("lvl: " + _lvl.ToString() + " exp: " + _experience.ToString());
        }

        [ContextMenu("AddExp")]
        void AddExp()
        {
            AddExperience(2);
        }

        public void UpdateLvl()
        {
            
        }
    }
}