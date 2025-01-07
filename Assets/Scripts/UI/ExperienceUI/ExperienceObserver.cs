using System;
using UniRx;

namespace PixelSurvivor
{
    public class ExperienceObserver : IDisposable
    {
        private readonly CurrencyView _view;
        private readonly ExperienceStorage _storage;
        private readonly IDisposable _disposable;

        public ExperienceObserver(CurrencyView view, ExperienceStorage storage)
        {
            _view = view;
            _storage = storage;
            _disposable = _storage.Experience.SkipLatestValueOnSubscribe().Subscribe(OnExperienceChanged);
        }
        
        public void Dispose()
        {
            _disposable.Dispose();
        }

        private void OnExperienceChanged(long experience)
        {
            _view.UpdateCurrency(experience);
        }
    }
}