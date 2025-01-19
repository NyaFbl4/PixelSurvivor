using System;
using UnityEngine;

namespace PixelSurvivor
{
    public class EnemyComponent : EnemyController
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private int _damage = 1;
        [SerializeField] private int _health;
        [SerializeField] private GameObject _experience;
        [SerializeField] private Transform _player;
        [SerializeField] private MiliEnemyAnimationController _enemyAnimationController;

        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                _player = player.transform;
            }

            base.health = _health;
            base.player = _player;
            base.moveSpeed = _moveSpeed;
            base.experience = _experience;
            base.damage = _damage;
            base.enemyAnimationController = _enemyAnimationController;
        }

        //public void Update(float deltaTime)
        public void Update()
        {
            FollowTarget();
            
            /*
            // Меняем анимацию в зависимости от состояния противника
            if (base.health <= 0)
            {
                _enemyAnimationController.PlayDeathAnimation();
            }
            else if (base.IsAttacking())
            {
                _enemyAnimationController.PlayAttackAnimation();
            }
            else if (base.IsMoving())
            {
                _enemyAnimationController.PlayWalkAnimation();
            }
            else
            {
                _enemyAnimationController.PlayIdleAnimation();
            }
            */
        }
    }
}