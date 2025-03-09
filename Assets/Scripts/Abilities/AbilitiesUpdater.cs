using UnityEngine;

namespace PixelSurvivor
{
    public class AbilitiesUpdater : MonoBehaviour
    {
        public void InstantiateAbility(Ability ability, GameObject abilitiesContainer)
        {
            var newAbility = abilitiesContainer.GetComponentInChildren<Ability>();
            
            newAbility = Instantiate(ability, abilitiesContainer.transform.position, Quaternion.identity);
            newAbility.transform.SetParent(ability.transform, true);
        }

        public void UpgradeAbility(Ability ability)
        {
            //ability.Upg;
        }
    }
}