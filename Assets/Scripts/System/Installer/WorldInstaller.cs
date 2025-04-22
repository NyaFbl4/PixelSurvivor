using PixelSurvivor.ScoreManager;
using Zenject;

namespace PixelSurvivor
{
    public class WorldInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            EnemyInstaller();
        }

        private void EnemyInstaller()
        {
            Container
                .Bind<EnemyRewardSystem>()
                .AsSingle();
        }
    }
}