using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem
{
    public class AbilityStorage : MonoBehaviour
    {
        [SerializeField] private List<NewAbilityConfig> _abilityConfigs = new();

        private List<NewAbility> _abilities = new();

        public void Init()
        {
            foreach (var abilityConfig in _abilityConfigs)
            {
                var builder = abilityConfig.GetBuilder();
                builder.Make();
                _abilities.Add(builder.GetResult());
            }
        }

        public List<NewAbility> GetAbilities() => _abilities;
    }
}