using UnityEditor.Tilemaps;
using UnityEngine;

namespace PixelSurvivor
{
    public class PlayerAnimationComponent : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _sprite;

        [SerializeField] private InputManager _inputManager;
        
        private float _dirX = 0;

        private void OnEnable()
        {
            _inputManager.OnMoveX += OnMoveX;
        }

        private void OnDestroy()
        {
            _inputManager.OnMoveX -= OnMoveX;
        }

        private void OnMoveX(float directionX)
        {
            if (directionX > 0)
            {
                _sprite.flipX = false;
            }
            else if (directionX < 0)
            {
                _sprite.flipX = true;
            }
            else
            {
                return;
            }
        }

    }
}