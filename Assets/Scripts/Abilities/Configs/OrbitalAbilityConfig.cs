using UnityEngine;

namespace PixelSurvivor
{
    [CreateAssetMenu(fileName = "OrbitalAbilityConfig")]
    public class OrbitalAbilityConfig : ScriptableObject
    {
        public GameObject prefabProjectile;

        public int damage;
        public int currentProjectile;
        
        public float cooldown;
        public float radius;
        public float rotationSpeed;
        public float duration;
    }
}