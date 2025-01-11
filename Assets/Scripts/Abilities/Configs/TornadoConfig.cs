using UnityEngine;

namespace PixelSurvivor
{
    [CreateAssetMenu(fileName = "SunStrikeConfig")]
    public class TornadoConfig : ScriptableObject
    {
        public GameObject prefabProjectile;
        
        public int damage;
        public float speed = 5f; // Скорость движения торнадо
        public float changeDirectionInterval = 2f; 
        
        public int currentProjectile;
        public float radius;
        public float cooldown;
    }
}