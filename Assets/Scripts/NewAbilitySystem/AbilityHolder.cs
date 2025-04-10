using Unity.VisualScripting;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem
{
    public class AbilityHolder : MonoBehaviour
    {
        [SerializeField] private NewAbility _ability;
        [SerializeField] private float _cooldownTime;
        private float _cooldown;
        [SerializeField] private KeyCode _keyCode;

        private EAbilityState _state = EAbilityState.Ready;

        private void Start()
        {
            _cooldown = _cooldownTime;
        }
        
        private void Update()
        {
            /*
            switch (_state)
            {
                case EAbilityState.Ready:
                    
                    //_ability.ActiveAbility();
                    _state = EAbilityState.Cooldown;
                    Debug.Log(_ability.Title + " active");
                    
                    break;
                case EAbilityState.Active:
                    
                    Debug.Log(_ability.Title + " cooldown");
                    _state = EAbilityState.Cooldown;

                    break;
                case EAbilityState.Cooldown:

                    if (_cooldown > 0)
                    {
                        _cooldown -= Time.deltaTime;
                    }
                    else
                    {
                        _cooldown = _cooldownTime;
                        _state = EAbilityState.Ready;
                        Debug.Log(_ability.Title + " ready");
                    }
                    
                    break;
            }
            */
        }
    }
}