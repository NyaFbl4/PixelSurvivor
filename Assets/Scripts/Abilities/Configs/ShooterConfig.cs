using UnityEngine;

namespace PixelSurvivor
{
    [CreateAssetMenu(fileName = "ShooterConfig")]
    public class ShooterConfig : ScriptableObject
    {
        public GameObject prefabProjectile;

        public int damage;
        public int maxCurrentProjectile;
        
        public float cooldown;
        public float radius;
        public float rotationSpeed;
        public float duration;
    }
}