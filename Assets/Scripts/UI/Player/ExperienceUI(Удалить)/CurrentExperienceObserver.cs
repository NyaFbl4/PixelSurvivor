using System;
using UniRx;

namespace PixelSurvivor
{
    public class CurrentExperienceObserver : IDisposable
    {
        private readonly ValueView _view;
        private readonly CurrentExperienceStorage _storage;
        private readonly IDisposable _disposable;

        public CurrentExperienceObserver(ValueView view, CurrentExperienceStorage storage)
        {
            _view = view;
            _storage = storage;
            _disposable = _storage.Experience.SkipLatestValueOnSubscribe().Subscribe(OnExperienceChanged);
            
            OnExperienceChanged(0);
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