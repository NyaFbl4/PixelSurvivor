using UnityEngine;

namespace PixelSurvivor
{
    public class FireBallUpgrade : AbilityUpgrade<FireBall> { }
    /* : Upgrade
    {
        [SerializeField] private FireBall _fireBallPrefab;
        
        public override void Apply(GameObject playerAbilities)
        {
            var shooter = playerAbilities.GetComponentInChildren<FireBall>();

            if (shooter == null)
            {
                shooter = Instantiate(_fireBallPrefab, playerAbilities.transform.position, Quaternion.identity);
                shooter.transform.SetParent(playerAbilities.transform, true);
            }
            else
            {
                shooter.UpgradeAbility();
            }
        }
    }
    */
}