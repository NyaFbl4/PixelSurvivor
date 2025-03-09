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
        
        //[SerializeField] private List<Upgrade> _abilityPool;

        //[SerializeField] private GameObject _playerAbilitiesContainer;

        [SerializeField] private int _maxRandomAbilities;
        [SerializeField] private int _maxPlayerAbilities;
        
        //[SerializeField] private List<Upgrade> _playerAbilities;
        [SerializeField] private List<GameObject> _upgradesPool;

        [SerializeField] private AbilityPopupProvider _popupProvider;

        [SerializeField] private bool _isActiveAbility;

        private void GetRandomAbilities(int count)
        {
            var abilityPool = _abilityManager.GetAbilitiesPool();
            
            // Проверяем, что список не пуст и количество запрашиваемых элементов не превышает размер списка
            if (abilityPool.Count == 0 || count <= 0 || count > abilityPool.Count)
            {
                Debug.LogWarning("Невозможно получить случайные способности.");
                return;
            }

            // Создаем список для хранения случайных индексов
            HashSet<int> randomIndices = new HashSet<int>();
            System.Random rand = new System.Random();

            while (randomIndices.Count < count)
            {
                // Генерируем случайный индекс
                int randomIndex = rand.Next(abilityPool.Count);
                randomIndices.Add(randomIndex);
            }

            // Очищаем целевой список, если в нем уже есть элементы
            _upgradesPool.Clear();

            // Добавляем случайные элементы в новый список
            foreach (int index in randomIndices)
            {
                _upgradesPool.Add(abilityPool[index].PrefabAbility); //.GetComponent<Ability>());
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
                // Проверяем, является ли способность нужным типом и активирована ли она
                if (newAbility.GetType() == ability.GetType())
                {
                    return true; // Способность активна
                }
            }
            
            return false; // Способности нет или она не активна
        }

        //ДОБАВЛЕНИЕ СПОСОБНОСТЕЙ ИЛИ ИХ УЛУЧШЕНИЕ
        public void OnUpgradeApplied(GameObject ability, Sprite icon)
        {
            _uiManager.Hide();
            
            var newAbility = ability.GetComponentInChildren<Ability>();
            
            if (!СheckAbilityStatus(newAbility, _abilityManager.GetPlayerAbilities()))
            {
                Debug.Log("false");
                _abilityManager.AddAbility(newAbility);
                
                var popup = _popupProvider.GetAbilityPopup();
                popup.SetupCooldown(icon, newAbility);
            }
            else
            {
                //ability.
                Debug.Log("true");
            }
            
            //_abilityManager.AddAbility(ability);

            //var popup = _popupProvider.GetAbilityPopup();
            //popup.SetupCooldown(icon, ability);
            
            Time.timeScale = 1;
        }
    }
}