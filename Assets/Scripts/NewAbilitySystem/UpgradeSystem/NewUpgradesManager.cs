using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.UpgradeSystem
{
    public class NewUpgradesManager : MonoBehaviour
    {
        [SerializeField] private UpgradesUiManager _uiManager;
        [SerializeField] private AbilityStorage _abilityStorage;

        [SerializeField] private int _maxUpgradeAbility;
        
        [SerializeField] private List<NewAbility> _playerAbilities = new(); 
        
        
        
    }
}