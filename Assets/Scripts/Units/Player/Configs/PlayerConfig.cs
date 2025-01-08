using UnityEngine;

namespace PixelSurvivor
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Player config", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _experience;
        [SerializeField] private int _health;
        [SerializeField] private int _score;

        public Sprite Icon => _icon;
        public int Experience => _experience;
        public int Health => _health;
        public int Score => _score;
    }
}