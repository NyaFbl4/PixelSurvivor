using Zenject;

namespace PixelSurvivor
{
    public class InstallerUI : MonoInstaller
    {
        public override void InstallBindings()
        {
            var view = FindObjectOfType<CurrencyViewProvider>();
            
            ExperienceBind(view.ExperienceView);
        }

        private void ExperienceBind(CurrencyView view)
        {
            Container
                .Bind<ExperienceStorage>()
                .AsSingle()
                .WithArguments(0)
                .NonLazy();

            Container
                .BindInterfacesTo<ExperienceObserver>()
                .AsSingle()
                .WithArguments(view)
                .NonLazy();
        }
    }
}