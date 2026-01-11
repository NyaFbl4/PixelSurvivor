using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PixelSurvivor
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField, Unity.Collections.ReadOnly] 
        private GameState _gameState;

        private readonly List<IGameListener> _gameListeners = new();
        private readonly List<IGameUpdateListener> _gameUpdateListeners = new();
        private readonly List<IGameFixedUpdateListener> _gameFixedUpdateListeners = new();

        public event Action OnStartGame;

        private void Awake()
        {
            _gameState = GameState.Off;

            IGameListener.onRegister += AddListener;
            IGameListener.onUnregister += RemoveListener;
        }

        private void Start()
        {
            StartGame();
        }

        private void OnDestroy()
        {
            _gameState = GameState.Finish;
            
            IGameListener.onRegister -= AddListener;
            IGameListener.onUnregister -= RemoveListener;
        }

        private void Update()
        {
            if (_gameState != GameState.Play)
            {
                return;
            }

            var deltaTime = Time.deltaTime;
            for (int i = 0; i < _gameUpdateListeners.Count; i++)
            {
                _gameUpdateListeners[i].OnUpdate(deltaTime);
            }
        }
        
        private void FixedUpdate()
        {
            if (_gameState != GameState.Play)
            {
                return;
            }

            var deltaTime = Time.deltaTime;
            for (int i = 0; i < _gameFixedUpdateListeners.Count; i++)
            {
                _gameFixedUpdateListeners[i].OnFixedUpdate(deltaTime);
            }
        }

        private void AddListener(IGameListener gameListener)
        {
            _gameListeners.Add(gameListener);

            if (gameListener is IGameUpdateListener gameUpdateListener)
            {
                _gameUpdateListeners.Add(gameUpdateListener);
            }

            if (gameListener is IGameFixedUpdateListener gameFixedUpdateListener)
            {
                _gameFixedUpdateListeners.Add(gameFixedUpdateListener);
            }
        }

        private void RemoveListener(IGameListener gameListener)
        {
            _gameListeners.Remove(gameListener);
            
            if (gameListener is IGameUpdateListener gameUpdateListener)
            {
                _gameUpdateListeners.Remove(gameUpdateListener);
            }

            if (gameListener is IGameFixedUpdateListener gameFixedUpdateListener)
            {
                _gameFixedUpdateListeners.Remove(gameFixedUpdateListener);
            }
        }

        [Button]
        public void StartGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameStartListener gameStartListener)
                {
                    gameStartListener.OnStartGame();
                }
            }

            _gameState = GameState.Play;
            Time.timeScale = 1;
            Debug.Log("START GAME");
        }

        [Button]
        public void FinishGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameFinishListener gameFinishListener)
                {
                    gameFinishListener.OnFinishGame();
                }
            }
            
            Time.timeScale = 0;
            _gameState = GameState.Finish;
            Debug.Log("FINISH");
        }
        
        [Button]
        public void PauseGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGamePauseListener gamePauseListener)
                {
                    gamePauseListener.OnPauseGame();
                }
            }
            
            Time.timeScale = 0;
            _gameState = GameState.Pause;
            Debug.Log("PAUSE");
        }
        
        [Button]
        public void ResumeGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameResumeListener gameResumeListener)
                {
                    gameResumeListener.OnResumeGame();
                }
            }
            
            Time.timeScale = 1;
            _gameState = GameState.Play;
            Debug.Log("RESUME");
        }
    }
}