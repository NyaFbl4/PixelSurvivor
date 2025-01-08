using System;
using UniRx;
using Zenject;

namespace PixelSurvivor
{
    public class ExperienceObserver : IInitializable, IDisposable
    {
        private readonly CurrencyView _view;
        private readonly ExperienceStorage _storage;

        public ExperienceObserver(ExperienceStorage storage, CurrencyView view)
        {
            _storage = storage;
            _view = view;
        }

        public void Initialize()
        {
            _storage.OnExperienceChanget += OnExperienceChanget;
            _view.SetupCurrency(_storage.Experience);
        }

        public void Dispose()
        {
            _storage.OnExperienceChanget -= OnExperienceChanget;
        }

        private void OnExperienceChanget(int exp)
        {
            _view.UpdateCurrency(exp);
        }
        
        /*
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

        private void OnExperienceChanged(int experience)
        {
            _view.UpdateCurrency(experience);
        }
        */
    }
}