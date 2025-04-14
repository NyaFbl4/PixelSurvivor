using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.UI
{
    public class AbilityUpgradeManager : MonoBehaviour
    {
        [SerializeField] private AbilityUpgradeUIProvider _uiProvider;
        [SerializeField] private AbilityStorage _abilityStorage;
        //[SerializeField] private AbilityCastHandler _castHandler;

        [SerializeField] private int _maxRandomAbilities;
        [SerializeField] private int _maxPlayerAbilities;
        
        [SerializeField] private List<NewAbility> _upgradesPool;

        [Button]
        public void SuggestUpgrades()
        {
            _uiProvider.Hide();
            
            _uiProvider.Show(_abilityStorage.GetAbilities, _abilityStorage);

            //var newAbility = 
        }
        
        private void OnClickApply(NewAbility ability)
        {
            //_castHandler.TakeNewAbility(ability);
            
            //var upgrade = ability.GetComponent<Upgrade>();
            //var upgrade = ability.GetComponent<Upgrade>();
            //ability = upgrade.Apply(playerAbilityContainer);
            //_upgradesManager.OnUpgradeApplied(ability , upgrade.icon);
        }
        
        /*
        private void GetRandomAbilities(int count)
        {
            var abilityPool = _abilityStorage.GetAbilityConfigs;

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
                //_upgradesPool.Add(abilityPool[index].PrefabAbility); 
            }
        }
        */
    }
}