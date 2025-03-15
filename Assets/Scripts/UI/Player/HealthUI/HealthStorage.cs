using System;
using UniRx;

namespace PixelSurvivor
{
    public class HealthStorage
    {
        public IReadOnlyReactiveProperty<long> Health => _health;

        private readonly ReactiveProperty<long> _health;

        public HealthStorage(long health)
        {
            _health = new LongReactiveProperty(health);
        }

        public void AddHealth(long health)
        {
            _health.Value += health;
        }

        public void SpendHealth(long health)
        {
            _health.Value -= health;
        }
    }
}