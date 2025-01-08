using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor
{
    public class TargetTrackerComponent : MonoBehaviour
    {
        [SerializeField] private float _detectionRadius;
        [SerializeField] private List<GameObject> _targets;

        public List<GameObject> GetCurrentTargets()
        {
            return _targets;
        }

        private void Update()
        {
            FindTarges();
        }

        private void FindTarges()
        {
            _targets.Clear();

            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _detectionRadius);

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Enemy"))
                {
                    _targets.Add(hitCollider.gameObject);
                }
            }
        }
        
        private void OnDrawGizmosSelected()
        {
            // Визуализация радиуса поиска в редакторе
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _detectionRadius);
        }
    }
}