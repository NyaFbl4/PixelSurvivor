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
        [SerializeField] private List<Upgrade> _upgradesPool;

        [SerializeField] private AbilityPopupProvider _popupProvider;

        private void GetRandomAbilities(int count)
        {
            // Проверяем, что список не пуст и количество запрашиваемых элементов не превышает размер списка
            if (_abilityPool.Count == 0 || count <= 0 || count > _abilityPool.Count)
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
                int randomIndex = rand.Next(_abilityPool.Count);
                randomIndices.Add(randomIndex);
            }

            // Очищаем целевой список, если в нем уже есть элементы
            _upgradesPool.Clear();

            // Добавляем случайные элементы в новый список
            foreach (int index in randomIndices)
            {
                _upgradesPool.Add(_abilityPool[index]);
            }
        }

        public void SuggestUpgrades()
        {
            GetRandomAbilities(_maxPlayerAbilities);
            
            if (_upgradesPool.Count > 0)
            {
                Time.timeScale = 0;
                _uiManager.Show(_upgradesPool, _playerAbilitiesContainer);
            }
        }

        //ДОБАВЛЕНИЕ СПОСОБНОСТЕЙ ИЛИ ИХ УЛУЧШЕНИЕ
        public void OnUpgradeApplied(Upgrade appliedUpgrade)
        {
            _uiManager.Hide();
            
            _playerAbilities.Add(appliedUpgrade);
            
            Time.timeScale = 1;
        }
    }
}