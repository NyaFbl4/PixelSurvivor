using System;

namespace PixelSurvivor
{
    public class HealthStorage
    {
        public event Action<int> OnHealthChanget;
        
        public int Health { get; private set; }

        public HealthStorage(int health)
        {
            Health = health;
        }

        public void AddHealth(int health)
        {
            Health += health;
            OnHealthChanget?.Invoke(Health);
        }

        public void SpendHealth(int health)
        {
            Health -= health;
            OnHealthChanget?.Invoke(Health);
        }
    }
}