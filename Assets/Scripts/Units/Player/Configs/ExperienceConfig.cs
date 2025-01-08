using UnityEngine;

namespace PixelSurvivor.Units.Player.Configs
{
    [CreateAssetMenu(fileName = "ExperienceConfig", menuName = "Experience config", order = 0)]
    public class ExperienceConfig : ScriptableObject
    {
        public int[] experienceLvl;
    }
}