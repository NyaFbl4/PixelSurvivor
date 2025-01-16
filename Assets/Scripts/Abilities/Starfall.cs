using UnityEngine;

namespace PixelSurvivor
{
    public class Starfall : MonoBehaviour
    {
        [SerializeField] private TargetTrackerComponent _targetTracker;
        [SerializeField] private Transform _shootPoint;
        
        [SerializeField] private int _projectileDamage;
        [SerializeField] private int _maxCurrentShots;
        
        [SerializeField]  private float _projectileSpeed;
        [SerializeField] private float _cooldown;

        public void Update()
        {
            Debug.Log("!!!!");
        }
    }
}