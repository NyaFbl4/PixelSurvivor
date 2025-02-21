using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor
{
    public class AbilityManager : MonoBehaviour
    {
        [SerializeField] private List<Ability> _allAbilitiesPool;
        
        [SerializeField] private GameObject _playerAbilitiesContainer;
        [SerializeField] private List<Ability> _playerAbilities;
        [SerializeField] private int _maxPlayerAbilities;

        public int MaxPlayerAbilities => _maxPlayerAbilities;

        public List<Ability> GetAbilitiesPool()
        {
            return _allAbilitiesPool;
        }

        public List<Ability> GetPlayerAbilities()
        {
            return _playerAbilities;
        }

        public void AddAbility(Ability newAbility)
        {
            _playerAbilities.Add(newAbility);
        }
    }
}