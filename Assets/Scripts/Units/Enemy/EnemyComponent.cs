using System;
using UnityEngine;

namespace PixelSurvivor
{
    public class EnemyComponent : EnemyController
    {
        [SerializeField] private bool _elite;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private int _damage = 1;
        [SerializeField] private int _health;
        [SerializeField] private GameObject _experience;
        [SerializeField] private Transform _player;
        [SerializeField] private MiliEnemyAnimationController _enemyAnimationController;
        [SerializeField] private EnemyDamageUI _enemyDamageUI;

        //[SerializeField] private bool _isMoving = true;

        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                _player = player.transform;
            }

            base.damageUI = _enemyDamageUI;
            base.elite = _elite;
            base.health = _health;
            base.player = _player;
            base.moveSpeed = _moveSpeed;
            base.experience = _experience;
            base.damage = _damage;
            base.enemyAnimationController = _enemyAnimationController;
        }

        public override void Move()
        {
            FollowTarget();
        }
        
        public void FixedUpdate()
        {
            /*
            if (_isMoving)
            {
                if (!_enemyAnimationController.isHurt)
                {
                    //MoveTowardsPlayer();
                    FollowTarget();
                }
            }
            */
        }
    }
}