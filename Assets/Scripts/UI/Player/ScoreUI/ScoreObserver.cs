using System;
using Zenject;

namespace PixelSurvivor
{
    public class ScoreObserver : IInitializable, IDisposable
    {
    private readonly ValueView _view;
    private readonly ScoreStorage _storage;

    public ScoreObserver(ScoreStorage storage, ValueView view)
    {
        _storage = storage;
        _view = view;
    }

    public void Initialize()
    {
        _storage.OnScoreChanget += OnScoreChanget;
        _view.SetupCurrency(_storage.Score);
    }

    public void Dispose()
    {
        _storage.OnScoreChanget -= OnScoreChanget;
    }

    private void OnScoreChanget(int exp)
    {
        _view.UpdateCurrency(exp);
    }
    }
}