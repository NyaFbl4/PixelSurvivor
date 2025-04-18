using System;
using System.Collections;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class ShieldAbility : NewAbility
    {
        [SerializeField] private GameObject _shield;
        [SerializeField] private float _timeAbility;
        
        private MonoBehaviour _monobeh;
        
        private GameObject _player;
        
        public ShieldAbility(float timeAbility, GameObject shieldObject)
        {
            _shield = shieldObject;
            _timeAbility = timeAbility;
        }
        
        public override void Added(GameObject player)
        {
            _player = player;
            
            _monobeh = _player.GetComponent<MonoBehaviour>();
        }
        
        public override void ApplyCast()
        {
            if (_player != null)
            { 
                GameObject shield = UnityEngine.Object.Instantiate(
                    _shield, 
                    _player.transform.position, 
                    _player.transform.rotation, 
                    _player.transform);

                _monobeh.StartCoroutine(DestroyShield());

                ChangeCooldownTimer(CooldownTime);
                ChangeAbilityState(EAbilityState.Cooldown);
            }
        }

        public override void EventTick(float deltaTick)
        {
            if (AbilityState == EAbilityState.Cooldown)
            {
                ChangeCooldownTimer(CooldownTimer - deltaTick);

                if (CooldownTimer <= 0.0f)
                {
                    Debug.Log(EAbilityState.Ready);
                    
                    ChangeAbilityState(EAbilityState.Ready);
                }
            }
        }

        private IEnumerator DestroyShield()
        {
            float abilityTime = 0f;
            while (abilityTime < _timeAbility)
            {
                abilityTime += Time.deltaTime;
                yield return null;
            }
            
            UnityEngine.Object.Destroy(_shield);
        }
    }
}