﻿using PixelSurvivor.NewAbilitySystem.UI;
using PixelSurvivor.Units.Player;
using UnityEngine;
using Zenject;

namespace PixelSurvivor
{
    public class InstallerUI : MonoInstaller
    {
        [SerializeField] private AbilitySlotsProvoder _abilitySlotsProvoder;
        //[SerializeField] private CooldownView _cooldownView;
        
        public override void InstallBindings()
        {
            var view = FindObjectOfType<ValueViewProvider>();

            CurrentHealthBind(view.CurrentHealthView);
            MaxHealthBind(view.MaxHealthView);

            ExperienceBind(view.CurrentExperienceView, view.MaxExperienceView);
            ScoreBind(view.ScoreView);
        }

        private void AbilitiesBind()
        {
            Container
                .Bind<AbilitySlotsProvoder>()
                .FromInstance(_abilitySlotsProvoder)
                .AsSingle();
        }

        private void ExperienceBind(ValueView CurrentView, ValueView MaxView)
        {
            Container
                .Bind<PlayerExperienceData>()
                .AsSingle()
                .WithArguments(0L, 0L)
                .NonLazy();

            Container
                .Bind<ExperienceObserver>()
                .AsSingle()
                .WithArguments(CurrentView, MaxView)
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
                .Bind<PlayerScoreData>()
                .AsSingle()
                .WithArguments(0L)
                .NonLazy();

            Container
                .BindInterfacesTo<ScoreObserver>()
                .AsSingle()
                .WithArguments(view)
                .NonLazy();
        }
    }
}