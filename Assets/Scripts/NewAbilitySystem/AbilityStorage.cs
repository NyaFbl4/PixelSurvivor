using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem
{
    public class AbilityStorage : MonoBehaviour
    {
        [SerializeField] private List<NewAbilityConfig> _abilityConfigs = new();
        [SerializeField] private GameObject _player;
        
        [SerializeField] private List<NewAbility> _abilities = new();

        public void Init()
        {
            /*
            foreach (var abilityConfig in _abilityConfigs)
            {
                var builder = abilityConfig.GetBuilder();
                builder.Make();
                
                
                _abilities.Add(builder.GetResult());
            }
            */
            
            for (int i = 0; i < _abilityConfigs.Count; ++i)
            {
                var builder = _abilityConfigs[i].GetBuilder();

                builder.Make();
                var ability = builder.GetResult();

                ability.Added(_player);


                _abilities.Add(ability);
            }

        }

        public List<NewAbility> GetAbilities() => _abilities;
    }
}