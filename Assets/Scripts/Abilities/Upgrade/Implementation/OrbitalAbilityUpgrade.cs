using UnityEngine;

namespace PixelSurvivor
{
    public class OrbitalAbilityUpgrade : AbilityUpgrade<OrbitalAbility> { }
    
        /*
        [SerializeField] private OrbitalAbility _orbitalAbilityPrefab;
        
        public override void Apply(GameObject playerAbilities)
        {
            var orbitalAbility = playerAbilities.GetComponentInChildren<OrbitalAbility>();

            if (orbitalAbility == null)
            {
                orbitalAbility = Instantiate(_orbitalAbilityPrefab, playerAbilities.transform.position, Quaternion.identity);
                orbitalAbility.transform.SetParent(playerAbilities.transform, true);
            }
            else
            {
                orbitalAbility.UpgradeAbility();
            }

        }
    }
    */
}