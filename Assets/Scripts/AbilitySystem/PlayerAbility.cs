using System;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem
{
    [Serializable]
    public class PlayerAbility
    {
        [SerializeField] private string _title;
        [SerializeField] private Sprite _iconImage;
        [SerializeField] private float _cooldownTime;
        [SerializeField] private float _cooldownTimer;
        //[SerializeField] private AbilityType _abilityType;
        
        private EAbilityState _abilityState;
        
        [SerializeField] protected int _damage;
        
        public string Title => _title;
        public Sprite IconImage => _iconImage;
        public int Damage => _damage;
        public float CooldownTime => _cooldownTime;
        public float CooldownTimer => _cooldownTimer;
        //public AbilityType AbilityType => _abilityType;
        public EAbilityState AbilityState => _abilityState;

        public event Action<float, float> EventChangeCooldownTimer; 
        
        public void SetDescription(string title, Sprite iconImage)
        {
            _title = title;
            _iconImage = iconImage;
        }
        
        public float SetCooldownTime(float cooldown) => _cooldownTime = cooldown;
        public void ChangeAbilityState(EAbilityState newState) => _abilityState = newState;
        public void ChangeCooldownTimer(float timer)
        {
            _cooldownTimer = Mathf.Clamp(timer, 0.0f, _cooldownTime);
            EventChangeCooldownTimer?.Invoke(CooldownTimer, CooldownTime);
        }
        public virtual void StartCast() { }
        public virtual void ApplyCast() { }
        public virtual void EventTick(float deltaTick) { }
        public virtual void CancelCast() { }
        public virtual void Added(GameObject player) { }
        public virtual void UpgradeAbility() { }

        public int GetDamage()
        {
            return _damage;
        }

        public void SetDamage(int newDamage)
        {
            _damage = newDamage;
        }
    }
}