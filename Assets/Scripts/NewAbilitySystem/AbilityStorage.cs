using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem
{
    public class AbilityStorage : MonoBehaviour
    {
        [SerializeField] private List<NewAbilityConfig> _abilityConfigs = new();
        [SerializeField] private List<NewAbilityConfig> _playerAbilitiesConfigs = new();
        [SerializeField] private List<NewAbility> _playerAbilities = new();

                         private Dictionary<Type, NewAbility> _playerAbilitiesDict = new();
        
        [SerializeField] private GameObject _player;
        [SerializeField] private AbilityCastHandler _castHandler;

        [Button]
        public void AddAbility(NewAbilityConfig newAbility)
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

        public List<NewAbilityConfig> GetAbilities => _abilityConfigs;
    }
}