using UniRx;

namespace PixelSurvivor.Units.Player
{
    public class PlayerScoreData
    {
        private readonly ReactiveProperty<long> _currentScore;

        public IReadOnlyReactiveProperty<long> CurrentScore => _currentScore;

        public PlayerScoreData(long currentScore)
        {
            _currentScore = new LongReactiveProperty(currentScore);
        }

        public void AddScore(long score)
        {
            _currentScore.Value += score;
        }
    }
}