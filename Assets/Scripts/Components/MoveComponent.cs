using UnityEngine;

namespace PixelSurvivor
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _moveSpeed;
        
        private float _dirX = 0;
        private float _dirY = 0;
        
        private void OnEnable()
        {
            _inputManager.OnMoveX += OnMoveX;
            _inputManager.OnMoveY += OnMoveY;
        }

        private void OnDestroy()
        {
            _inputManager.OnMoveX -= OnMoveX;
            _inputManager.OnMoveY += OnMoveY;
        }
        
        private void FixedUpdate()
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