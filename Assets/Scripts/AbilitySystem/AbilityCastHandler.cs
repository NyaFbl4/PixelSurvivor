using System.Collections.Generic;
using PixelSurvivor.NewAbilitySystem.UI;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem
{
    public class AbilityCastHandler : MonoBehaviour
    {
        [SerializeField] private AbilitySlotsProvoder _slotsProvoder;
        
        [SerializeField] private List<PlayerAbility> _playerAbilities = new();
        private List<PlayerAbility> _playerBuffs = new();
        private PlayerAbility _currentAbility;

        //[Inject]
        public void Construct(AbilitySlotsProvoder slotsProvoder)
        {
            _slotsProvoder = slotsProvoder;
            
            //_abilityStorage.Init();
            //_abilities.AddRange(_abilityStorage.GetAbilities());
        }

        public void TakeNewAbility(PlayerAbility newAbility)
        {
            //if(newAbility.A)
            _playerAbilities.Add(newAbility);
            _slotsProvoder.TakeNewAbility(newAbility);
        }

        public void OnAbilityActive(int abilityIndex)
        {
            _currentAbility?.CancelCast();

            switch (_playerAbilities[abilityIndex].AbilityState)
            {
                case EAbilityState.Ready:
                    
                    Debug.Log("Ability Ready");
                    _currentAbility = _playerAbilities[abilityIndex];
                    _currentAbility.ApplyCast();
                    
                    break;
                case EAbilityState.Cooldown: 
                    
                    Debug.Log("Ability Cooldown");
                    break;
                
                default:
                    break;
            }
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < _playerAbilities.Count; ++i)
            {
                _playerAbilities[i].EventTick(Time.deltaTime);
                
                OnAbilityActive(i);
            }

            if (_currentAbility != null)
            {
                _currentAbility.StartCast();
                _currentAbility = null;
                
                return;
            }
        }
    }
}