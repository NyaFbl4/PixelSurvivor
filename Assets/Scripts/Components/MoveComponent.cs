using System;
using UnityEngine;

namespace PixelSurvivor
{
    public class MoveComponent : MonoBehaviour, IGameStartListener, 
        IGameFixedUpdateListener, IGameFinishListener
    {
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _moveSpeed;
        
        private float _dirX = 0;
        private float _dirY = 0;

        private void Start()
        {
            IGameListener.Register(this);
        }

        public void OnStartGame()
        {
            _inputManager.OnMoveX += OnMoveX;
            _inputManager.OnMoveY += OnMoveY;
        }

        public void OnFinishGame()
        {
            _inputManager.OnMoveX -= OnMoveX;
            _inputManager.OnMoveY += OnMoveY;
        }
        
        public void OnFixedUpdate(float deltaTime)
        {
            _rigidbody2D.velocity = new Vector2(_dirX, _dirY ) * _moveSpeed;
        }

        
        private void OnMoveX(float directionX)
        {
            _dirX = directionX;
            //Debug.Log(_dirX);
        }
        
        private void OnMoveY(float directionY)
        {
            _dirY = directionY;
            //Debug.Log(_dirZ);
        }
    }
}