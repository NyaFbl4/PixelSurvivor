using System;
using UniRx;

namespace PixelSurvivor
{
    public class ExperienceStorage
    {
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
        
        /*
        public IReadOnlyReactiveProperty<int> Experience => _experience;

        private readonly ReactiveProperty<int> _experience;
        
        public ExperienceStorage(int experience)
        {
            _experience = new IntReactiveProperty(experience);
        }
        
        public void AddExperience(int experience)
        {
            _experience.Value += experience;
        }

        public void SpendMoney(int experience)
        {
            _experience.SetValueAndForceNotify(_experience.Value - experience);
        }
        */
    }
}