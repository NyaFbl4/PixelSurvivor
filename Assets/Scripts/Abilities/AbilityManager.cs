using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor
{
    public class AbilityManager : MonoBehaviour
    {
        [SerializeField] private List<Upgrade> _playerAbilities;

        [SerializeField] private int _maxPlayerAbilities;
        [SerializeField] private List<Ability> _playerAbilites;

        public void AddAbility(Ability ability)
        {
            _playerAbilites.Add(ability);
        }
    }
}