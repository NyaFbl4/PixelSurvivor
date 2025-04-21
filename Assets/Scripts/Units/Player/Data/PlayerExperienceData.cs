using UniRx;

namespace PixelSurvivor.Units.Player
{
    public class PlayerExperienceData
    {
        private readonly ReactiveProperty<long> _currentExperience;
        private readonly ReactiveProperty<long> _maxExperienceOnLvl;
        
        public IReadOnlyReactiveProperty<long> CurrentExperience  => _currentExperience;
        public IReadOnlyReactiveProperty<long> MaxExperienceOnLvl => _maxExperienceOnLvl;

        public PlayerExperienceData(long currentExperience, long maxExperienceOnLvl)
        {
            _currentExperience  = new LongReactiveProperty(currentExperience);
            _maxExperienceOnLvl = new LongReactiveProperty(maxExperienceOnLvl);
        }
        
        public void AddMaxExperienceOnLvl(long maxExperience)
        {
            _maxExperienceOnLvl.Value = maxExperience;
        }
        
        public void AddExperience(long experience)
        {
            _currentExperience.Value += experience;
        }
    }
}