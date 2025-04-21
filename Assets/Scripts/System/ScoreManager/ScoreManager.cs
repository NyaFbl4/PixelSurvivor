using PixelSurvivor.Units.Player;

namespace PixelSurvivor.ScoreManager
{
    public class ScoreManager
    {
        private readonly PlayerScoreData _scoreData;

        public ScoreManager(PlayerScoreData scoreData)
        {
            _scoreData = scoreData;
        }
    }
}