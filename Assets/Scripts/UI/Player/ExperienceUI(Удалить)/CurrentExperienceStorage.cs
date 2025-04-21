using System;
using UniRx;

namespace PixelSurvivor
{
    public class CurrentExperienceStorage
    {
        public IReadOnlyReactiveProperty<long> Experience => _experience;

        private readonly ReactiveProperty<long> _experience;
        
        public CurrentExperienceStorage(long experience)
        {
            _experience = new LongReactiveProperty(experience);
        }
        
        public void AddExperience(long experience)
        {
            _experience.Value += experience;
        }
    }
}