using UniRx;

namespace PixelSurvivor
{
    public class MaxHealthStorage
    {
        public IReadOnlyReactiveProperty<long> MaxHealth => _maxhealth;

        private readonly ReactiveProperty<long> _maxhealth;

        public MaxHealthStorage(long health)
        {
            _maxhealth = new LongReactiveProperty(health);
        }

        public void AddMaxHealth(long health)
        {
            _maxhealth.Value += health;
        }

        public void SpendMaxHealth(long health)
        {
            _maxhealth.Value -= health;
        }
    }
}