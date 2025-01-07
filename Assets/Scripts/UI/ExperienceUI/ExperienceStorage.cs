using UniRx;

namespace PixelSurvivor
{
    public class ExperienceStorage
    {
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

        public void SpendExperience(long experience)
        {
            _experience.SetValueAndForceNotify(_experience.Value - experience);
        }
    }
}