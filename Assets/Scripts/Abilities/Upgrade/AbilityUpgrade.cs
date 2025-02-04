using System;
using UnityEngine;

namespace PixelSurvivor
{
    public class AbilityUpgrade<TAbility> : Upgrade where TAbility : MonoBehaviour, IUpgradeable
    {
        [SerializeField] private TAbility _abilityPrefab; // Префаб способности

        public override void Apply(GameObject playerAbilities)
        {
            // Ищем способность среди дочерних объектов
            var ability = playerAbilities.GetComponentInChildren<TAbility>();

            if (ability == null)
            {
                // Если способность не найдена, создаём новую
                ability = Instantiate(_abilityPrefab, playerAbilities.transform.position, Quaternion.identity);
                ability.transform.SetParent(playerAbilities.transform, true);
            }
            else
            {
                // Если способность найдена, улучшаем её
                ability.UpgradeAbility();
            }
        }
    }

}