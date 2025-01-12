using System;
using UnityEngine;

namespace PixelSurvivor
{
    public class RangedEnemy : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private int _damage;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private GameObject _attakcBall;
        
        [SerializeField] private float shootingRange = 5f;
        [SerializeField] private float _cooldown;
        [SerializeField] private Transform _player;

        private void Start()
        {
            GameObject character = GameObject.FindGameObjectWithTag("Player");

            if (character != null)
            {
                _player = character.transform;
            }
        }

        private void Update()
        {
            // Вычисляем расстояние до игрока
            float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

            if (distanceToPlayer > shootingRange)
            {
                // Если противник находится вне диапазона стрельбы, приближаемся к игроку
                MoveTowardsPlayer();
            }
            else
            {
                // Если противник в пределах диапазона стрельбы, стреляем по игроку
                Shoot();
            }
        }
        
        private void MoveTowardsPlayer()
        {
            // Движение к игроку
            Vector2 direction = (_player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, _player.position, _moveSpeed * Time.deltaTime);
        }

        private void Shoot()
        {
            Instantiate(_attakcBall, _firePoint.position, _firePoint.rotation);
        }
    }
}