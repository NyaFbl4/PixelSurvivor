using System.Collections.Generic;
using System.Linq;
using PixelSurvivor.UI;
using UnityEngine;

namespace PixelSurvivor
{
    public class UpgradesManager : MonoBehaviour
    {
        [SerializeField] private UpgradesUiManager _uiManager;
        [SerializeField] private AbilityManager _abilityManager;

        [SerializeField] private int _maxRandomAbilities;
        [SerializeField] private int _maxPlayerAbilities;
        
        [SerializeField] private List<GameObject> _upgradesPool;

        [SerializeField] private AbilityPopupProvider _popupProvider;

        [SerializeField] private bool _isActiveAbility;

        private void GetRandomAbilities(int count)
        {
            var abilityPool = _abilityManager.GetAbilitiesPool();
            
            if (abilityPool.Count == 0 || count <= 0 || count > abilityPool.Count)
            {
                Debug.LogWarning("Невозможно получить случайные способности.");
                return;
            }

            HashSet<int> randomIndices = new HashSet<int>();
            System.Random rand = new System.Random();

            while (randomIndices.Count < count)
            {
                int randomIndex = rand.Next(abilityPool.Count);
                randomIndices.Add(randomIndex);
            }

            _upgradesPool.Clear();
            
            foreach (int index in randomIndices)
            {
                _upgradesPool.Add(abilityPool[index].PrefabAbility); 
            }
        }

        public void SuggestUpgrades()
        {
            GetRandomAbilities(_maxPlayerAbilities);
            
            if (_upgradesPool.Count > 0)
            {
                Time.timeScale = 0;
                _uiManager.Show(_upgradesPool, _abilityManager.PlayerAbilitiesContainer);
            }
        }

        private bool СheckAbilityStatus(Ability newAbility,List<Ability> playerAbilities)
        {
            foreach (var ability in playerAbilities)
            {
                if (newAbility.GetType() == ability.GetType())
                {
                    return true;
                }
            }
            
            return false;
        }

        public void OnUpgradeApplied(GameObject ability, Sprite icon)
        {
            _uiManager.Hide();
            
            var newAbility = ability.GetComponentInChildren<Ability>();
            
            if (!СheckAbilityStatus(newAbility, _abilityManager.GetPlayerAbilities()))
            {
                _abilityManager.AddAbility(newAbility);
                
                var popup = _popupProvider.GetAbilityPopup();
                popup.SetupCooldown(icon, newAbility);
            }

            Time.timeScale = 1;
        }
    }
}