using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem
{
    public class AbilityCastHandler : MonoBehaviour
    {
        [SerializeField] private AbilityStorage _abilityStorage;

        private List<NewAbility> _abilities;
        private NewAbility _currentAbility;

        private void Start()
        {
            _abilityStorage.Init();
            _abilities.AddRange(_abilityStorage.GetAbilities());
        }

        public void OnAbilityActive(int abilityIndex)
        {
            _currentAbility?.CancelCast();

            switch (_abilities[abilityIndex].AbilityState)
            {
                case EAbilityState.Ready:

                    _currentAbility = _abilities[abilityIndex];
                    _currentAbility.StartCast();
                    
                    break;
                case EAbilityState.Cooldown: 
                    break;
                default:
                    break;
            }
        }

        private void Update()
        {
            foreach (var ability in _abilities)
            {
                ability.EventTick(Time.deltaTime);
            }

            if (_currentAbility != null)
            {
                _currentAbility.ApplyCast();
                _currentAbility = null;
            }
        }
    }
}