using UnityEngine;

namespace PixelSurvivor
{
    [CreateAssetMenu(fileName = "FireBallConfig")]
    public class FireBallConfig : ScriptableObject
    {
        public GameObject prefabProjectile;

        public int damage;
        public int currentProjectile;
        
        public float speedProjectile;
        public float cooldown;
    }
}