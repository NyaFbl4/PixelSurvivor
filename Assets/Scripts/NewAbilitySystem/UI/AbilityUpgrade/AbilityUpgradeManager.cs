using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.UI
{
    public class AbilityUpgradeManager : MonoBehaviour
    {
        [SerializeField] private AbilityUpgradeUIProvider _uiProvider;
        [SerializeField] private AbilityStorage _abilityStorage;
        [SerializeField] private AbilityCastHandler _castHandler;
        
        [SerializeField] private int _maxRandomAbilities;
        [SerializeField] private int _maxPlayerAbilities;
        
        [SerializeField] private List<NewAbility> _upgradesPool;

        [Button]
        public void Test()
        {
            _uiProvider.Hide();
            
            _uiProvider.Show(_abilityStorage.GetAbilities(), _castHandler);
            
            //var newAbility = 
        }
    }
}