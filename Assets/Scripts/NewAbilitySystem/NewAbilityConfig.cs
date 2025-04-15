using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem
{
    public class NewAbilityConfig : ScriptableObject
    {
        [SerializeField] private string _title;
        [SerializeField] private Sprite _iconImage;
        [SerializeField] private float _cooldownTime;
        [SerializeField] private AbilityType _abilityType;

        public AbilityType AbilityType => _abilityType;
        public string Title => _title;
        public Sprite IconImage => _iconImage;
        public float CooldownTime => _cooldownTime;

        public virtual AbilityBuilder GetBuilder() => new AbilityBuilder(this);
    }
}