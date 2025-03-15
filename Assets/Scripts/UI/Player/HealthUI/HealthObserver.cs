using System;
using UniRx;
using Zenject;

namespace PixelSurvivor
{
    public class HealthObserver : IDisposable
    {
        private readonly ValueView _view;
        private readonly HealthStorage _storage;
        private readonly IDisposable _disposable;

        public HealthObserver(ValueView view, HealthStorage storage)
        {
            _view = view;
            _storage = storage;
            _disposable = _storage.Health.SkipLatestValueOnSubscribe().Subscribe(OnHealthChanget);
        }                                 

        public void Dispose()
        {
            _disposable.Dispose();
        }

        private void OnHealthChanget(long health)
        {
            _view.UpdateCurrency(health);
        }
    }
}