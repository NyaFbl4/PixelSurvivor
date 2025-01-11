using System;
using UniRx;

namespace PixelSurvivor
{
    public class ExperienceStorage
    {
        /*
        public event Action<int> OnExperienceChanget;
        
        public int Experience { get; private set; }

        public ExperienceStorage(int exp)
        {
            Experience = exp;
        }

        public void AddExperience(int exp)
        {
            Experience += exp;
            OnExperienceChanget?.Invoke(Experience);
        }
        */
        
        
        public IReadOnlyReactiveProperty<long> Experience => _experience;

        private readonly ReactiveProperty<long> _experience;
        
        public ExperienceStorage(long experience)
        {
            _experience = new LongReactiveProperty(experience);
        }
        
        public void AddExperience(long experience)
        {
            _experience.Value += experience;
        }

        public void SpendMoney(int experience)
        {
            _experience.SetValueAndForceNotify(_experience.Value - experience);
        }
        
    }
}