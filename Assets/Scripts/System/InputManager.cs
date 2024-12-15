using System;
using UnityEngine;

namespace PixelSurvivor
{
    public class InputManager : MonoBehaviour
    {
        public event Action<float> OnMoveX;
        public event Action<float> OnMoveY;
        public event Action OnAttack;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnAttack();
            }

            float directionX = 0;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                directionX = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                directionX = 1;
            }
            else
            {
                directionX = 0;
            }

            float directionY = 0;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                directionY = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                directionY = -1;
            }
            else
            {
                directionY = 0;
            }

            OnMoveX?.Invoke(directionX);
            OnMoveY?.Invoke(directionY);
        }
    }
}