using System;
using UniRx;

namespace PixelSurvivor
{
    public class MaxExperienceObserver : IDisposable
    {
        private readonly ValueView _view;
        private readonly MaxExperienceStorage _storage;
        private readonly IDisposable _disposable;

        public MaxExperienceObserver(ValueView view, MaxExperienceStorage storage)
        {
            _view = view;
            _storage = storage;
            _disposable = _storage.MaxExperience.SkipLatestValueOnSubscribe().Subscribe(OnMaxExperienceChanged);
            
            OnMaxExperienceChanged(0);
        }
        
        public void Dispose()
        {
            _disposable.Dispose();
        }

        private void OnMaxExperienceChanged(long experience)
        {
            _view.UpdateCurrency(experience);
        }
    }
}