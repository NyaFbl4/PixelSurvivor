using UnityEngine;

namespace PixelSurvivor
{
    [CreateAssetMenu(fileName = "StarfallConfig")]
    public class StarfallConfig : ScriptableObject
    {
        public GameObject prefabProjectile;
        public int damage;
        public int maxCurrentProjectile;
        public int ricochetShots;
        public float speedProjectile;
        public float cooldown;
    }
}