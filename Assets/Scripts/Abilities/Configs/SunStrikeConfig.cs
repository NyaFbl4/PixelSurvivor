using UnityEngine;

namespace PixelSurvivor
{
    [CreateAssetMenu(fileName = "SunStrikeConfig")]
    public class SunStrikeConfig : ScriptableObject
    {
        public GameObject prefabProjectile;

        public int damage;
        public int currentProjectile;
        
        public float radius;
        public float cooldown;
    }
}