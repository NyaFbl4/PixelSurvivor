using System.Collections;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Projectiles
{
    public class SunstrikeProjectile : ProjectilesController
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

            Destroy(gameObject);
        }
    }
}