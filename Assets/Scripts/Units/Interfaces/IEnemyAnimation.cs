using UnityEngine;

namespace PixelSurvivor
{
    public interface IEnemyAnimation
    {
        public void FlipSpriteDirection(Vector3 direction);
        public void SetMoving(bool isMoving);
        public void TakeDamage();
    }
}