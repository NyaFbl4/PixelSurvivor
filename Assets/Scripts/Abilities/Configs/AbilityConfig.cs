using UnityEngine;

namespace PixelSurvivor
{
    [CreateAssetMenu(fileName = "AbilityConfig")]
    public class AbilityConfig : ScriptableObject
    {
        public Sprite Icon;
        public GameObject PrefabAbility;
        //public Upgrade UpgradeAbility;
    }
}