using UnityEngine;

namespace PixelSurvivor
{
    public class SunStrikeUpgrade : Upgrade
    {
        [SerializeField] private SunStrike _sunStrikePrefab;
        
        public override void Apply(GameObject playerAbilities)
        {
            var sunSrike = Instantiate(_sunStrikePrefab, playerAbilities.transform.position, Quaternion.identity);
            sunSrike.transform.SetParent(playerAbilities.transform, true);
        }
    }
}