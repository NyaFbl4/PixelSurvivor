using System;
using UniRx;

namespace PixelSurvivor
{
    public class CurrentHealthStorage
    {
        public IReadOnlyReactiveProperty<long> CurrentHealth => _currenthealth;

        private readonly ReactiveProperty<long> _currenthealth;

        public CurrentHealthStorage(long health)
        {
            _currenthealth = new LongReactiveProperty(health);
        }

        public void AddCurrentHealth(long health)
        {
            _currenthealth.Value += health;
        }

        public void SpendCurrentHealth(long health)
        {
            _currenthealth.Value -= health;
        }
    }
}