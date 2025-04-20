using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem
{
    public class AbilityConfig : ScriptableObject
    {
        [SerializeField] private string _title;
        [SerializeField] private Sprite _iconImage;
        [SerializeField] private float _cooldownTime;
        [SerializeField] private float _liveTime;
        [SerializeField] private AbilityType _abilityType;

        public AbilityType AbilityType => _abilityType;
        public string Title => _title;
        public Sprite IconImage => _iconImage;
        public float CooldownTime => _cooldownTime;
        public float LiveTime => _liveTime;
        public virtual AbilityBuilder GetBuilder() => new AbilityBuilder(this);
    }
}