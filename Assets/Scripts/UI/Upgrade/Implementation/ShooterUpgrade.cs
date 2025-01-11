using UnityEngine;

namespace PixelSurvivor
{
    public class FireBallUpgrade : Upgrade
    {
        [SerializeField] private FireBall _shooterPrefab;
        
        public override void Apply(GameObject playerAbilities)
        {
            var shooter = playerAbilities.GetComponentInChildren<FireBall>();

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