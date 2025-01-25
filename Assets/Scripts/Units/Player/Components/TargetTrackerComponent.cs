using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor
{
    public class TargetTrackerComponent : MonoBehaviour
    {
        [SerializeField] private float _detectionRadius;
        [SerializeField] private List<GameObject> _targets;

        [SerializeField] private List<GameObject> _ignoreTargets;

        public List<GameObject> GetCurrentTargets()
        {
            return _targets;
        }

        public void GetIgnoreTarget(GameObject ignoreTarget)
        {
            Debug.Log("Add ignor targget");
            _ignoreTargets.Clear();
            _ignoreTargets.Add(ignoreTarget);
        }

        public void ClearIgnoreTargets()
        {
            _ignoreTargets.Clear();
        }

        public void ClearTargetsList()
        {
            _targets.Clear();
        }

        public GameObject GetFirstTarget()
        {
            if (_targets != null && _targets.Count > 0)
            {
                return _targets[0];
            }
            else
            {
                Debug.LogWarning("No targets available.");
                return null; // Или любое другое значение по умолчанию
            }
        }

        private void FixedUpdate()
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
                    foreach (var ignoreTarget in _ignoreTargets)
                    {
                        if (hitCollider.gameObject == ignoreTarget) ;
                        {
                            return;
                        }
                    }

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