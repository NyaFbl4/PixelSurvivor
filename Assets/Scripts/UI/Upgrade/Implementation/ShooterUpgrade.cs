using UnityEngine;

namespace PixelSurvivor
{
    public class ShooterUpgrade : Upgrade
    {
        [SerializeField] private Shooter _shooterPrefab;
        
        public override void Apply(GameObject playerAbilities)
        {
            var shooter = playerAbilities.GetComponentInChildren<Shooter>();

            if (shooter == null)
            {
                shooter = Instantiate(_shooterPrefab, playerAbilities.transform.position, Quaternion.identity);
                shooter.transform.SetParent(playerAbilities.transform, true);
            }
            else
            {
                shooter.UpgradeAbility();
            }
        }
    }
}