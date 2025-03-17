using System;
using UniRx;
using UnityEngine;

namespace PixelSurvivor
{
    public class MaxHealthObserver  : IDisposable
    {
        private readonly ValueView _view;
        private readonly MaxHealthStorage _storage;
        private readonly IDisposable _disposable;

        public MaxHealthObserver(ValueView view, MaxHealthStorage storage)
        {
            _view = view;
            _storage = storage;
            _disposable = _storage.MaxHealth.SkipLatestValueOnSubscribe().Subscribe(OnMaxHealthChanget);
        }                                 

        public void Dispose()
        {
            _disposable.Dispose();
        }

        private void OnMaxHealthChanget(long health)
        {
            _view.UpdateCurrency(health);
        }
    }
}