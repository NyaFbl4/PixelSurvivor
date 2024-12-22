using System;
using UnityEditor.Tilemaps;
using UnityEngine;

namespace PixelSurvivor
{
    public class PlayerAnimationComponent : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _sprite;

        [SerializeField] private InputManager _inputManager;

        //private bool _isMove;
        private float _directionX;
        private float _directionY;
        
        private float _dirX = 0;

        private void OnEnable()
        {
            _inputManager.OnMoveX += OnMoveX;
            _inputManager.OnMoveY += OnMoveY;
        }

        private void OnDestroy()
        {
            _inputManager.OnMoveX -= OnMoveX;
            _inputManager.OnMoveY -= OnMoveY;
        }

        private void Update()
        {
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            if (_directionX != 0 || _directionY != 0)
            {
                _animator.SetBool("IsMove", true);
            }
            else
            {
                _animator.SetBool("IsMove", false);
            }
        }

        private void OnMoveX(float directionX)
        {
            _directionX = directionX;
            
            if (_directionX > 0)
            {
                _sprite.flipX = false;
            }
            else if (_directionX < 0)
            {
                _sprite.flipX = true;
            }
            else if (_directionX == 0)
            {
                //_directionX = directionX;
                return;
            }
        }

        private void OnMoveY(float directionY)
        {
            _directionY = directionY;
            
            if (directionY == 0)
            {
                //isMove = false;
                return;
            }
        }
    }
}