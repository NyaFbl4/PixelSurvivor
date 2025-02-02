using UnityEngine;

namespace PixelSurvivor
{
    public class EnemyDamageUI : MonoBehaviour
    {
        [SerializeField] private DamageUI _damageUI;

        public void ShowDamage(int damage)
        {
            _damageUI.Play(damage);
        }
    }
}