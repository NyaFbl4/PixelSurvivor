using UniRx;
using UnityEngine;

namespace PixelSurvivor.Units.Player
{
    public class PlayerExperienceData
    {
        private readonly ReactiveProperty<long> _currentExperience;
        private readonly ReactiveProperty<long> _maxExperienceOnLvl;
        private readonly ReactiveProperty<long> _oldMaxExperience;
        
        public IReadOnlyReactiveProperty<long> CurrentExperience  => _currentExperience;
        public IReadOnlyReactiveProperty<long> MaxExperienceOnLvl => _maxExperienceOnLvl;
        public IReadOnlyReactiveProperty<long> OldMaxExperienceOnLvl => _oldMaxExperience;

        public PlayerExperienceData(long currentExperience, long maxExperienceOnLvl, long oldMaxExperience)
        {
            _currentExperience  = new LongReactiveProperty(currentExperience);
            _maxExperienceOnLvl = new LongReactiveProperty(maxExperienceOnLvl);
            _oldMaxExperience = new LongReactiveProperty(oldMaxExperience);
        }
        
        public void AddMaxExperienceOnLvl(long maxExperience)
        {
            _maxExperienceOnLvl.Value = maxExperience;
        }
        
        public void AddOldMaxExperienceOnLvl(long oldMaxExperience)
        {
            _oldMaxExperience.Value = oldMaxExperience;
        }
        
        public void AddExperience(long experience)
        {
            _currentExperience.Value += experience;
        }
    }
}