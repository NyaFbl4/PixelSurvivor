using UnityEngine;

namespace PixelSurvivor
{
    public class OrbitalAbilityUpgrade : Upgrade
    {
        [SerializeField] private OrbitalAbility _orbitalAbilityPrefab;
        
        public override void Apply(GameObject playerAbilities)
        {
            Debug.Log("SunStrike");

            var orbitalAbility = Instantiate(_orbitalAbilityPrefab, playerAbilities.transform.position, Quaternion.identity);
            orbitalAbility.transform.SetParent(playerAbilities.transform, true); 
        }
    }
}