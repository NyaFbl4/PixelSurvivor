using UnityEngine;

namespace PixelSurvivor
{
    public abstract class EnemyController : MonoBehaviour, IDamage
    {
        protected Transform player;
        protected float moveSpeed;
        protected int damage;
        protected int health;
        protected GameObject experience;
        protected EnemyDamageUI damageUI;
        
        protected IEnemyAnimation enemyAnimationController;


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
                
                if (Vector3.Distance(transform.position, player.position) > 0.1f)
                {
                    enemyAnimationController.SetMoving(true);
                }
                else if (Vector3.Distance(transform.position, player.position) == 0f)
                {
                    enemyAnimationController.SetMoving(false);
                }

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
                GameObject exp = Instantiate(experience, this.gameObject.transform.position, Quaternion.identity);
                Instantiate(experience);
            
                Destroy(gameObject);
            }
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