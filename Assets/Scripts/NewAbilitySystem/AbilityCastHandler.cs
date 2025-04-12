using System.Collections.Generic;
using PixelSurvivor.UI.Player.NewAbilityUi;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace PixelSurvivor.NewAbilitySystem
{
    public class AbilityCastHandler : MonoBehaviour
    {
        //[SerializeField] private AbilityStorage _abilityStorage;

        [SerializeField] private AbilitySlotsProvoder _slotsProvoder;
        
        [SerializeField] private List<NewAbility> _abilities = new();
        private NewAbility _currentAbility;

        private void Start()
        {
            //_abilityStorage.Init();
            //_abilities.AddRange(_abilityStorage.GetAbilities());
        }

        //[Inject]
        public void Construct(AbilitySlotsProvoder slotsProvoder)
        {
            _slotsProvoder = slotsProvoder;
            
            //_abilityStorage.Init();
            //_abilities.AddRange(_abilityStorage.GetAbilities());
        }

        [Button]
        public void TakeNewAbility(NewAbility newAbility)
        {
            _abilities.Add(newAbility);
            _slotsProvoder.TakeNewAbility(newAbility);
        }

        public void OnAbilityActive(int abilityIndex)
        {
            _currentAbility?.CancelCast();

            switch (_abilities[abilityIndex].AbilityState)
            {
                case EAbilityState.Ready:
                    
                    Debug.Log("Ability Ready");
                    _currentAbility = _abilities[abilityIndex];
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
            for (int i = 0; i < _abilities.Count; ++i)
            {
                _abilities[i].EventTick(Time.deltaTime);
                
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