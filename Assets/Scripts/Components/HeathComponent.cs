using UnityEngine;

namespace PixelSurvivor
{
    public class HeathComponent : MonoBehaviour, IDamage
    {
        [SerializeField] private int _health;

        public void TakeDamage(int damage)
        {
            _health -= damage;

            Debug.Log(_health);
            
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}