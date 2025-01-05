using System;

namespace PixelSurvivor
{
    public interface IGameListener
    {
        public static event Action<IGameListener> onRegister;

        public static void Reginster(IGameListener gameListener)
        {
            if (onRegister != null)
            {
                onRegister.Invoke(gameListener);
            }
        }
    }
    
    public interface IGameStartListener : IGameListener
    {
        void OnStartGame();
    }
    
    public interface IGameFinishListener : IGameListener
    {
        void OnFinishGame();
    } 
    
    public interface IGamePauseListener : IGameListener
    {
        void OnPauseGame();
    }
    
    public interface IGameResumeListener : IGameListener
    {
        void OnResumeGame();
    }
    
    public interface IGameUpdateListener : IGameListener
    {
        void OnUpdate(float deltaTime);
    }

    public interface IGameFixedUpdateListener : IGameListener
    {
        void OnFixedUpdate(float deltaTime);
    }
}