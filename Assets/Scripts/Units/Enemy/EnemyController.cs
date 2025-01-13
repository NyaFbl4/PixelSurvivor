using UnityEngine;

namespace PixelSurvivor
{
    public abstract class EnemyController : MonoBehaviour
    {
        protected Transform player;
        protected SpriteRenderer sprite;
        protected float moveSpeed;
        protected int damage;
        
        protected void FollowTarget()
        {
            if (player != null)
            {
                Vector3 vector3 = (player.position - transform.position).normalized;
                if (vector3.x > 0)
                {
                    sprite.flipX = true;
                }
                else if (vector3.x < 0)
                {
                    sprite.flipX = false;
                }

                transform.position += vector3 * moveSpeed * Time.deltaTime;
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