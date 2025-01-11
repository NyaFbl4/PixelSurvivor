using System;

namespace PixelSurvivor
{
    public class ScoreStorage
    {
        public event Action<int> OnScoreChanget;
        
        public int  Score { get; private set; }

        public ScoreStorage(int score)
        {
            Score = score;
        }

        public void AddScore(int score)
        {
            Score += score;
            OnScoreChanget?.Invoke(Score);
        }
    }
}