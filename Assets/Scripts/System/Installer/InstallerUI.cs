using PixelSurvivor.NewAbilitySystem.UI;
using UnityEngine;
using Zenject;

namespace PixelSurvivor
{
    public class InstallerUI : MonoInstaller
    {
        [SerializeField] private AbilitySlotsProvoder _abilitySlotsProvoder;
        [SerializeField] private CooldownView _cooldownView;
        
        public override void InstallBindings()
        {
            var view = FindObjectOfType<ValueViewProvider>();
            
            CurrentExperienceBind(view.CurrentExperienceView);
            MaxExperienceBind(view.MaxExperienceView);
            
            CurrentHealthBind(view.CurrentHealthView);
            MaxHealthBind(view.MaxHealthView);

            //HealthBind(view.HealthView);
            //ScoreBind(view.ExperienceView);
        }

        private void AbilitiesBind()
        {
            Container
                .Bind<AbilitySlotsProvoder>()
                .FromInstance(_abilitySlotsProvoder)
                .AsSingle();
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
                .Bind<CurrentHealthStorage>()
                .AsSingle()
                .WithArguments(0L)
                .NonLazy();

            Container
                .BindInterfacesTo<CurrentHealthObserver>()
                .AsSingle()
                .WithArguments(view)
                .NonLazy();
        }
        
        private void MaxHealthBind(ValueView view)
        {
            Container
                .Bind<MaxHealthStorage>()
                .AsSingle()
                .WithArguments(0L)
                .NonLazy();

            Container
                .BindInterfacesTo<MaxHealthObserver>()
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