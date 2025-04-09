using System;
using UnityEngine;

namespace PixelSurvivor
{
    public class AbilityUpgrade<TAbility> : Upgrade where TAbility : MonoBehaviour, IUpgradeable
    {
        [SerializeField] private TAbility _abilityPrefab; // Префаб способности
        [SerializeField] private AbilityType _abilityType;

        public override GameObject Apply(GameObject playerAbilities)
        {
            // Ищем способность среди дочерних объектов
            var ability = playerAbilities.GetComponentInChildren<TAbility>();

            if (_abilityType == AbilityType.Ability)
            {
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
            else if (_abilityType == AbilityType.Buff)
            {
                
            }

            return ability.gameObject;
        }
    }
}