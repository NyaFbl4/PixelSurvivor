using System;
using Zenject;

namespace PixelSurvivor
{
    public class HealthObserver : IInitializable, IDisposable
    {
        private readonly CurrencyView _view;
        private readonly HealthStorage _storage;

        public HealthObserver(HealthStorage storage, CurrencyView view)
        {
            _storage = storage;
            _view = view;
        }
        
        public void Initialize()
        {
            _storage.OnHealthChanget += OnHealthChanget;
            _view.SetupCurrency(_storage.Health);
        }

        public void Dispose()
        {
            _storage.OnHealthChanget -= OnHealthChanget;
        }

        private void OnHealthChanget(int exp)
        {
            _view.UpdateCurrency(exp);
        }
    }
}