using UnityEngine;

namespace PixelSurvivor
{
    public class ExperiencePickup : MonoBehaviour
    {
        [SerializeField] private int _experience;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                LvlComponent lvlComponent = other.gameObject.GetComponent<LvlComponent>();

                if (lvlComponent != null)
                {
                    lvlComponent.AddExperience(_experience);
                }
                
                Destroy(gameObject);
            }
        }
    }
}