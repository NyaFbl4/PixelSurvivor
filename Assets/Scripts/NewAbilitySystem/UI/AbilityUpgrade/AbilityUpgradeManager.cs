using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.UI
{
    public class AbilityUpgradeManager : MonoBehaviour
    {
        [SerializeField] private AbilityUpgradeUIProvider _uiProvider;
        [SerializeField] private AbilityStorage _abilityStorage;

        [SerializeField] private int _maxRandomAbilities;
        [SerializeField] private int _maxPlayerAbilities;
        
        [SerializeField] private List<NewAbilityConfig> _upgradesPool;

        [Button]
        public void SuggestUpgrades()
        {
            GetRandomAbilities(_maxRandomAbilities);
            _uiProvider.Hide();
            
            _uiProvider.Show(_upgradesPool, _abilityStorage);
        }
        
        private void GetRandomAbilities(int count)
        {
            var abilityPool = _abilityStorage.GetAbilities;
            
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
                _upgradesPool.Add(abilityPool[index]); 
            }
        }
    }
}