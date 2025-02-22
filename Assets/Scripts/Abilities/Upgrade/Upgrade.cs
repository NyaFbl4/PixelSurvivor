using UnityEngine;

namespace PixelSurvivor
{
    public abstract class Upgrade : MonoBehaviour
    {
        [SerializeField] public string title;
        [SerializeField] public Sprite icon;
        
        public abstract void Apply(GameObject playerAbilities);
    }
}