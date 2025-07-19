using System.Collections;
using PixelSurvivor.NewAbilitySystem.Projectiles;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class LaserProjectile : ProjectilesController
    {
        [SerializeField] private Animator _animator;
        private bool _isAnimating = false;
        
        private void Start()
        {
            Execute();
        }

        private void Execute()
        {
            if (!_isAnimating)
            {
                _isAnimating = true;
                StartCoroutine(DestroyAfterAnimation());
            }
        }
        
        private IEnumerator DestroyAfterAnimation()
        {
            yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);

            //base._pool.ReturnProjectile(this.gameObject);
            Destroy(gameObject);
        }
    }
}