using UnityEngine;
using Zenject;

namespace PixelSurvivor
{
    public class InstallerUI : MonoInstaller
    {
        [SerializeField] private CooldownView _cooldownView;
        
        public override void InstallBindings()
        {
            var view = FindObjectOfType<CurrencyViewProvider>();
            
            ExperienceBind(view.ExperienceView);
            //HealthBind(view.ExperienceView);
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
        
        private void ExperienceBind(CurrencyView view)
        {
            Container
                .Bind<ExperienceStorage>()
                .AsSingle()
                .WithArguments(0L)
                .NonLazy();

            Container
                .BindInterfacesTo<ExperienceObserver>()
                .AsSingle()
                .WithArguments(view)
                .NonLazy();
        }

        private void HealthBind(CurrencyView view)
        {
            Container
                .Bind<HealthStorage>()
                .AsSingle()
                .WithArguments(0)
                .NonLazy();

            Container
                .BindInterfacesTo<HealthObserver>()
                .AsSingle()
                .WithArguments(view)
                .NonLazy();
        }
        
        private void ScoreBind(CurrencyView view)
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