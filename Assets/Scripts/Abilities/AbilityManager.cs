using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PixelSurvivor
{
    public class AbilityManager : MonoBehaviour
    {
        [SerializeField] private List<AbilityConfig> _allAbilitiesPool;
        
        [SerializeField] private List<GameObject> _gameObjects;
        
        [SerializeField] private GameObject _playerAbilitiesContainer;
        [SerializeField] private List<Ability> _playerAbilities;
        [SerializeField] private List<Ability> _playerBuffs;
        [SerializeField] private int _maxPlayerAbilities;

        public int MaxPlayerAbilities => _maxPlayerAbilities;

        public GameObject PlayerAbilitiesContainer => _playerAbilitiesContainer;

        [Button]
        private void Test(GameObject count)
        {
            var obj = count.GetComponent<Upgrade>();

            if (obj != null)
            {
                Debug.Log("yes");
            }
            else
            {
                Debug.Log("No");
            }
        }
        
        public List<AbilityConfig> GetAbilitiesPool()
        {
            return _allAbilitiesPool;
        }

        public List<Ability> GetPlayerAbilities()
        {
            return _playerAbilities;
        }

        public void AddAbility(Ability newAbility)
        {
            _playerAbilities.Add(newAbility);
        }

        public List<Ability> GetPlayerBuffs()
        {
            return _playerBuffs;
        }

        public void AddBuff(Ability newAbility)
        {
            _playerBuffs.Add(newAbility);
        }
    }
}