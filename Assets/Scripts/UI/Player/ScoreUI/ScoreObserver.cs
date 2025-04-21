using System;
using PixelSurvivor.Units.Player;
using UniRx;
using Zenject;

namespace PixelSurvivor
{
    public class ScoreObserver : IDisposable
    {
        private readonly ValueView _view;
        private readonly PlayerScoreData _data;

        private readonly IDisposable _disposableScore;

        public ScoreObserver(PlayerScoreData scoreData, ValueView view)
        {
            _data = scoreData;
            _view = view;

            _disposableScore = _data.CurrentScore.SkipLatestValueOnSubscribe().
                Subscribe(OnScoreChanget);
            
            OnScoreChanget(0);
        }

        public void Dispose()
        {
            _disposableScore.Dispose();
        }

        private void OnScoreChanget(long newScore)
        {
            _view.UpdateCurrency(newScore);
        }
    }
}