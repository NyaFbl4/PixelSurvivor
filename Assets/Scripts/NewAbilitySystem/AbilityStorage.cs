using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem
{
    public class AbilityStorage : MonoBehaviour
    {
        [SerializeField] private List<NewAbilityConfig> _abilityConfigs = new();
        [SerializeField] private GameObject _player;
        [SerializeField] private AbilityCastHandler _castHandler;
        
        [SerializeField] private List<NewAbility> _playerAbilities = new();

        /*
        public void Init()
        {
            for (int i = 0; i < _abilityConfigs.Count; ++i)
            {
                var builder = _abilityConfigs[i].GetBuilder();
                builder.Make();
                
                var ability = builder.GetResult();
                ability.Added(_player);
                _playerAbilities.Add(ability);
            }
        }
        */

        [Button]
        public void AddAbility(NewAbilityConfig newAbility)
        {
            var builder = newAbility.GetBuilder();
            builder.Make();
            
            var ability = builder.GetResult();
            ability.Added(_player);
            _playerAbilities.Add(ability);
            _castHandler.TakeNewAbility(ability);
        }

        public List<NewAbility> GetPlayerAbilities() => _playerAbilities;
        public List<NewAbilityConfig> GetAbilities() => _abilityConfigs;
    }
}