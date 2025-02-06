using System;
using UniRx;

namespace PixelSurvivor
{
    public class CooldownObserver : IDisposable
    {
        private readonly CooldownView _view;
        private readonly CooldownStorage _storage;
        private readonly IDisposable _disposableMaxCooldown;
        private readonly IDisposable _disposableCurrentCooldown;

        public CooldownObserver(CooldownView view, CooldownStorage storage)
        {
            _view = view;
            _storage = storage;
            _disposableMaxCooldown = _storage.MaxCooldown.SkipLatestValueOnSubscribe().Subscribe(OnMaxCooldownChanged);
            _disposableCurrentCooldown = _storage.CurrentCooldown.SkipLatestValueOnSubscribe().Subscribe(OnCurrentCooldownChanged);
        }
        
        private void OnCurrentCooldownChanged(float currentCooldown)
        {
            _view.UpdateCurrentCooldown(currentCooldown);
        }
        
        private void OnMaxCooldownChanged(float maxCooldown)
        {
            _view.UpdateMaxCooldown(maxCooldown);
        }

        public void Dispose()
        {
            _disposableMaxCooldown.Dispose();
            _disposableCurrentCooldown.Dispose();
        }
    }
}