using UnityEngine;

namespace PixelSurvivor
{
    public abstract class Upgrade : MonoBehaviour
    {
        [SerializeField] public string _title;
        [SerializeField] public Sprite _icon;
        
        public abstract void Apply();
    }
}