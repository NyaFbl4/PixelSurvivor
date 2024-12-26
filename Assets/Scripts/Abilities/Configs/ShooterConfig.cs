using UnityEngine;

namespace PixelSurvivor
{
    [CreateAssetMenu(fileName = "ShooterConfig")]
    public class ShooterConfig : ScriptableObject
    {
        public GameObject prefabProjectile;

        public int damage;
        public int currentProjectile;
        
        public float speedProjectile;
        public float cooldown;
    }
}