using UniRx;

namespace PixelSurvivor
{
    public class MaxExperienceStorage
    {
        public IReadOnlyReactiveProperty<long> MaxExperience => _maxExperience;

        private readonly ReactiveProperty<long> _maxExperience;
        
        public MaxExperienceStorage(long maxExperience)
        {
            _maxExperience = new LongReactiveProperty(maxExperience);
        }
        
        public void AddMaxExperience(long maxExperience)
        {
            _maxExperience.Value = maxExperience;
        }
    }
}