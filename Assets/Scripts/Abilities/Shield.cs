﻿using UnityEngine;

namespace PixelSurvivor
{
    public class Shield : MonoBehaviour
    {
        [SerializeField] private float _timeAbility;
        private float _currentTime;

        private void Start()
        {
            _currentTime = _timeAbility;
        }
        
        private void Update()
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("EnemyBullet"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}