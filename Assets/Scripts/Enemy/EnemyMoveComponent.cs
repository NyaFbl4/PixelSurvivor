using UnityEngine;

namespace PixelSurvivor
{
    public class EnemyMoveComponent : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Rigidbody2D _rigidbody;

        [SerializeField] private Transform _character;

        private void OnEnable()
        {
            GameObject character = GameObject.FindGameObjectWithTag("Player");

            if (character != null)
            {
                _character = character.transform;
            }
        }

        private void Update()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            if (_character != null)
            {
                float distance = Vector2.Distance(transform.position, _character.position);
                
                Vector3 direction = (_character.position - transform.position).normalized;
                
                transform.position += direction * _moveSpeed * Time.deltaTime;
            }
        }
    }
}