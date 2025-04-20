using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem
{
    public class AbilityStorage : MonoBehaviour
    {
        [SerializeField] private List<AbilityConfig> _abilityConfigs = new();
        [SerializeField] private List<AbilityConfig> _playerAbilitiesConfigs = new();
        [SerializeField] private List<PlayerAbility> _playerAbilities = new();

                         private Dictionary<Type, PlayerAbility> _playerAbilitiesDict = new();
        
        [SerializeField] private GameObject _player;
        [SerializeField] private AbilityCastHandler _castHandler;

        [Button]
        public void AddAbility(AbilityConfig newAbility)
        {
            var builder = newAbility.GetBuilder();
            builder.Make();
            var newAbilityInstance = builder.GetResult();

            if (_playerAbilitiesDict.TryGetValue(newAbilityInstance.GetType(), 
                out var existingAbility))
            {
                existingAbility.UpgradeAbility();
            }
            else
            {
                if (newAbility.AbilityType == AbilityType.Ability)
                {
                    Debug.Log("Ability");
                    newAbilityInstance.Added(_player);
                    _playerAbilitiesDict.Add(newAbilityInstance.GetType(), newAbilityInstance);
                    _castHandler.TakeNewAbility(newAbilityInstance);
                }
                else if (newAbility.AbilityType == AbilityType.Buff)
                {
                    Debug.Log("Buff");
                    newAbilityInstance.Added(_player);
                    //_playerAbilitiesDict.Add(newAbilityInstance.GetType(), newAbilityInstance);
                    
                    newAbilityInstance.ApplyCast();
                    //_castHandler.TakeNewAbility(newAbilityInstance);
                }
            }
        }

        public List<AbilityConfig> GetAbilities => _abilityConfigs;
    }
}