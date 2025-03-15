using UnityEngine;

namespace PixelSurvivor
{
    public class ValueViewProvider : MonoBehaviour
    {
        [SerializeField] private ValueView _currenExperienceView;
        [SerializeField] private ValueView _maxExperienceView;
        
        [SerializeField] private ValueView _healthView;
        [SerializeField] private ValueView _scoreView;
        [SerializeField] private ValueView _timeView;

        public ValueView CurrentExperienceView => _currenExperienceView;
        public ValueView MaxExperienceView => _maxExperienceView;
        
        public ValueView HealthView => _healthView;
        public ValueView ScoreView => _scoreView;
        public ValueView TimeView => _timeView;
    }
}