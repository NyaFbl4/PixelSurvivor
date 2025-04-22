namespace PixelSurvivor.ScoreManager
{
    public interface IEnemyRewardsSystem
    {
        public void AddScore(int points);
        public void RegisterEnemy(EnemyController enemy);
    }
}