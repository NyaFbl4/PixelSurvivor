using System;
using UnityEngine;

namespace PixelSurvivor
{
    public abstract class EnemyController : MonoBehaviour, IDamage
    {
        protected Transform player;
        protected bool elite;
        protected float moveSpeed;
        protected int damage;
        protected int health;
        protected int killReward;
        protected GameObject experience;
        protected EnemyDamageUI damageUI;
        
        protected IEnemyAnimation enemyAnimationController;
        
        public event Action<int> OnDeath;
        
        public abstract void Move();
        
        protected void MoveTowardsPlayer()
        {
            Vector3 vector3 = (player.position - transform.position).normalized;
                
            enemyAnimationController.FlipSpriteDirection(vector3);
        }
        
        protected void FollowTarget()
        {
            if (player != null)
            {
                Vector3 vector3 = (player.position - transform.position).normalized;

                MoveTowardsPlayer();
                
                transform.position += vector3 * moveSpeed * Time.deltaTime;
            }
        }
        
        public void TakeDamage(int damage)
        {
            enemyAnimationController.TakeDamage();
            damageUI.ShowDamage(damage);
                
            health -= damage;

            if (health <= 0)
            {
                if (elite)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Instantiate(experience, this.gameObject.transform.position, Quaternion.identity);
                    }
                }
                
                Defeat();
            }
        }

        private void Defeat()
        {
            Instantiate(experience, this.gameObject.transform.position, Quaternion.identity);
            OnDeath?.Invoke(killReward);
            
            Destroy(gameObject);
        }

        protected virtual void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                IDamage damageComponent = other.gameObject.GetComponent<IDamage>();
                if (damageComponent != null)
                {
                    damageComponent.TakeDamage(damage); 
                }
            }
        }
    }
}