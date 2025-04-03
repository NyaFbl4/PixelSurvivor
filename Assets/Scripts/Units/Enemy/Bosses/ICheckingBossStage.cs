using System.Collections.Generic;

namespace PixelSurvivor
{
    public interface ICheckingBossStage
    {
        public void CheckingBossStage(int health, int maxHealth);
    }
}