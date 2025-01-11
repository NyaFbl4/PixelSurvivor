using UnityEngine;

namespace PixelSurvivor
{
    public class CurrencyViewProvider : MonoBehaviour
    {
        [SerializeField] private CurrencyView _experienceView;
        [SerializeField] private CurrencyView _healthView;
        [SerializeField] private CurrencyView _scoreView;

        public CurrencyView ExperienceView => _experienceView;
        public CurrencyView HealthView => _healthView;
        public CurrencyView ScoreView => _scoreView;
    }
}