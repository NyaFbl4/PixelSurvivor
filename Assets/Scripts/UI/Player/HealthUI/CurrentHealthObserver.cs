using System;
using UniRx;
using Zenject;

namespace PixelSurvivor
{
    public class CurrentHealthObserver : IDisposable
    {
        private readonly ValueView _view;
        private readonly CurrentHealthStorage _storage;
        private readonly IDisposable _disposable;

        public CurrentHealthObserver(ValueView view, CurrentHealthStorage storage)
        {
            _view = view;
            _storage = storage;
            _disposable = _storage.CurrentHealth.SkipLatestValueOnSubscribe().Subscribe(OnCurrentHealthChanget);
        }                                 

        public void Dispose()
        {
            _disposable.Dispose();
        }

        private void OnCurrentHealthChanget(long health)
        {
            _view.UpdateCurrency(health);
        }
    }
}