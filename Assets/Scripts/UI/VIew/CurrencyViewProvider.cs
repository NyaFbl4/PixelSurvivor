using UnityEngine;

namespace PixelSurvivor
{
    public class ValueViewProvider : MonoBehaviour
    {
        [SerializeField] private ValueView _currenExperienceView;
        [SerializeField] private ValueView _maxExperienceView;
        
        [SerializeField] private ValueView _currentHealthView;
        [SerializeField] private ValueView _maxHealthView;
        
        [SerializeField] private ValueView _scoreView;

        public ValueView CurrentExperienceView => _currenExperienceView;
        public ValueView MaxExperienceView => _maxExperienceView;
        public ValueView CurrentHealthView => _currentHealthView;
        public ValueView MaxHealthView => _maxHealthView;
        public ValueView ScoreView => _scoreView;
    }
}