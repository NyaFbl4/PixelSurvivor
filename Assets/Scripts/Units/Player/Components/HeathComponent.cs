﻿using System;
using UnityEngine;

namespace PixelSurvivor
{
    public class HeathComponent : MonoBehaviour, IDamage
    {
        [SerializeField] private int _health;
        [SerializeField] private GameObject _experience;

        public void TakeDamage(int damage)
        {
            _health -= damage;

            Debug.Log(_health);
            
            if (_health <= 0)
            {
                GameObject exp = Instantiate(_experience, this.gameObject.transform.position, Quaternion.identity);
                Instantiate(_experience);
                
                Destroy(gameObject);
            }
        }
    }
}