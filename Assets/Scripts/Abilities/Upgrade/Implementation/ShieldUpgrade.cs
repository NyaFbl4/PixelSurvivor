using UnityEngine;

namespace PixelSurvivor
{
    public class ShieldUpgrade : Upgrade
    {
        [SerializeField] private Shield _shieldPrefab;

        public override void Apply(GameObject playerAbilities)
        {
            var shield = playerAbilities.GetComponentInChildren<Shield>();

            if (shield == null)
            {
                shield = Instantiate(_shieldPrefab, playerAbilities.transform.position, Quaternion.identity);
                shield.transform.SetParent(playerAbilities.transform, true);
            }
            else
            {
                shield.UpgradeAbility();
            }
        }
    }
}