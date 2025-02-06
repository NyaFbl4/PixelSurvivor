using UniRx;

namespace PixelSurvivor
{
    public class CooldownStorage
    {
        public IReadOnlyReactiveProperty<float> MaxCooldown => _maxCooldown;
        public IReadOnlyReactiveProperty<float> CurrentCooldown => _currentCooldown;

        private readonly ReactiveProperty<float> _maxCooldown;
        private readonly ReactiveProperty<float> _currentCooldown;
        
        public CooldownStorage(float maxCooldown, float currentCooldown)
        {
            _maxCooldown = new FloatReactiveProperty(maxCooldown);
            _currentCooldown = new FloatReactiveProperty(currentCooldown);
        }

        public void AddCurrentCooldown(float currentCooldown)
        {
            _currentCooldown.Value = currentCooldown;
        }
        
        public void AddMaxCooldown(float maxCooldown)
        {
            _maxCooldown.Value = maxCooldown;
        }
    }
}