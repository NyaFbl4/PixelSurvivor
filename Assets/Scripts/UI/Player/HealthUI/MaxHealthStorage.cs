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

        public void AddCurrentHealth(long health)
        {
            _maxhealth.Value += health;
        }

        public void SpendCurrentHealth(long health)
        {
            _maxhealth.Value -= health;
        }
    }
}