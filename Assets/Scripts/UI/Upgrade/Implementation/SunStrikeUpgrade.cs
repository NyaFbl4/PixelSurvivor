using UnityEngine;

namespace PixelSurvivor
{
    public class SunStrikeUpgrade : Upgrade
    {
        [SerializeField] private SunStrike _sunStrikePrefab;
        
        public override void Apply(GameObject playerAbilities)
        {
            var sunStrike = playerAbilities.GetComponentInChildren<SunStrike>();
            
            if (sunStrike == null)
            {
                sunStrike = Instantiate(_sunStrikePrefab, playerAbilities.transform.position, Quaternion.identity);
                sunStrike.transform.SetParent(playerAbilities.transform, true);
            }
            else
            {
                sunStrike.UpgradeAbility();
                Debug.Log("Upgrade SunStrike");
            }
        }
    }
}