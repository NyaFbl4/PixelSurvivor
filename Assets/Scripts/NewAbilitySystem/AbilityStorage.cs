using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem
{
    public class AbilityStorage : MonoBehaviour
    {
        [SerializeField] private List<NewAbilityConfig> _abilityConfigs = new();
        
        [SerializeField] private List<NewAbility> _playerAbilities = new();
        [SerializeField] private List<NewAbilityConfig> _playerAbilitiesConfigs = new();
        
        [SerializeField] private GameObject _player;
        [SerializeField] private AbilityCastHandler _castHandler;

        [Button]
        public void AddAbility(NewAbilityConfig newAbility)
        {
            var builder = newAbility.GetBuilder();
            builder.Make();

            if (СheckAbilityStatus(newAbility))
            {
                var ability = builder.GetResult();
                ability.Added(_player);
                _playerAbilities.Add(ability);
                _playerAbilitiesConfigs.Add(newAbility);
                _castHandler.TakeNewAbility(ability);
            }
        }

        public List<NewAbilityConfig> GetAbilities => _abilityConfigs;
        public List<NewAbility> GetPlayerAbilities() => _playerAbilities;
        //public List<NewAbilityConfig> GetAbilities() => _playerAbilitiesConfigs;
        
        private bool СheckAbilityStatus(NewAbilityConfig newAbility)
        {
            foreach (var ability in _playerAbilitiesConfigs)
            {
                if (newAbility.GetType() == ability.GetType())
                {
                    return true;
                }
            }

            return false;
        }
    }
}