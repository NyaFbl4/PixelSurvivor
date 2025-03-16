using UnityEngine;
using Zenject;

namespace PixelSurvivor
{
    public class InstallerUI : MonoInstaller
    {
        [SerializeField] private CooldownView _cooldownView;
        
        public override void InstallBindings()
        {
            var view = FindObjectOfType<ValueViewProvider>();
            
            CurrentExperienceBind(view.CurrentExperienceView);
            MaxExperienceBind(view.MaxExperienceView);

            //HealthBind(view.HealthView);
            //ScoreBind(view.ExperienceView);
        }

        private void CooldownBind()
        {
            Container
                .Bind<CooldownObserver>()
                .AsTransient()
                .WithArguments(_cooldownView)
                .NonLazy();

            Container
                .Bind<Ability>()
                .AsTransient()
                .NonLazy();
        }
        
        private void CurrentExperienceBind(ValueView view)
        {
            Container
                .Bind<CurrentExperienceStorage>()
                .AsSingle()
                .WithArguments(0L)
                .NonLazy();

            Container
                .BindInterfacesTo<CurrentExperienceObserver>()
                .AsSingle()
                .WithArguments(view)
                .NonLazy();
        }
        
        private void MaxExperienceBind(ValueView view)
        {
            Container
                .Bind<MaxExperienceStorage>()
                .AsSingle()
                .WithArguments(0L)
                .NonLazy();

            Container
                .BindInterfacesTo<MaxExperienceObserver>()
                .AsSingle()
                .WithArguments(view)
                .NonLazy();
        }

        private void CurrentHealthBind(ValueView view)
        {
            Container
                .Bind<HealthStorage>()
                .AsSingle()
                .WithArguments(0L)
                .NonLazy();

            Container
                .BindInterfacesTo<HealthObserver>()
                .AsSingle()
                .WithArguments(view)
                .NonLazy();
        }
        
        private void ScoreBind(ValueView view)
        {
            Container
                .Bind<ScoreStorage>()
                .AsSingle()
                .WithArguments(0)
                .NonLazy();

            Container
                .BindInterfacesTo<ScoreObserver>()
                .AsSingle()
                .WithArguments(view)
                .NonLazy();
        }
    }
}