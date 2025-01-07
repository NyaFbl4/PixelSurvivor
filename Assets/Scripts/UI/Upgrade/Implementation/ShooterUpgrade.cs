using UnityEngine;

namespace PixelSurvivor
{
    public class ShooterUpgrade : Upgrade
    {
        [SerializeField] private Shooter _shooterPrefab;
        
        public override void Apply(GameObject playerAbilities)
        {
            Debug.Log("ShooterUpgrade");
            
            var shooter = Instantiate(_shooterPrefab, playerAbilities.transform.position, Quaternion.identity);
            shooter.transform.SetParent(playerAbilities.transform, true); 
        }
    }
}