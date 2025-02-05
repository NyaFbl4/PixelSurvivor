using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PixelSurvivor
{
    public class UpgradesManager : MonoBehaviour
    {
        [SerializeField] private UpgradesUiManager _uiManager;
        
        [SerializeField] private List<Upgrade> _abilityPool;

        [SerializeField] private GameObject _playerAbilitiesContainer;

        [SerializeField] private int _maxRandomAbilities;
        [SerializeField] private int _maxPlayerAbilities;
        
        [SerializeField] private List<Upgrade> _playerAbilities;
        [SerializeField] private List<Upgrade> _upgradesPool;
        
        private void Awake()
        {
            //_upgradesPool = _abilityPool;
        }
        
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
        
        /*
        private void GetRandomAbilities(int count)
        {
            // Проверка, заполнен ли список полученных способностей
            if (_playerAbilities.Count > 0)
            {
                Debug.Log("У персонажа уже есть способности. Новые способности недоступны.");
                return;
            }

            // Проверка на доступность способностей
            if (_abilityPool.Count == 0 || count <= 0 || count > _abilityPool.Count)
            {
                Debug.LogWarning("Невозможно получить случайные способности.");
                return;
            }

            HashSet<int> randomIndices = new HashSet<int>();
            System.Random rand = new System.Random();

            // Генерируем уникальные индексы для способностей
            while (randomIndices.Count < count)
            {
                int randomIndex = rand.Next(_abilityPool.Count);
                randomIndices.Add(randomIndex);
            }

            foreach (int index in randomIndices)
            {
                _playerAbilities.Add(_abilityPool[index]); // Добавляем способности в список персонажа
            }

            // Выводим полученные способности для проверки
            Debug.Log("Персонаж получил следующие способности:");
            foreach (var ability in _playerAbilities)
            {
                Debug.Log(ability.name); // Предполагая, что у Upgrade есть свойство name
            }
        }
        */
        
        public void SuggestUpgrades()
        {
            /*
            if (_upgradesPool.Count > _maxPlayerAbilities)
            {
                _upgradesPool.RemoveRange(_maxPlayerAbilities, _upgradesPool.Count - _maxPlayerAbilities);
            }
            */
            
            GetRandomAbilities(_maxPlayerAbilities);
            
            if (_upgradesPool.Count > 0)
            {
                Time.timeScale = 0;
                _uiManager.Show(_upgradesPool, _playerAbilitiesContainer);
            }
        }

        public void OnUpgradeApplied(Upgrade appliedUpgrade)
        {
            _uiManager.Hide();
            
            _playerAbilities.Add(appliedUpgrade);
            
            //_availableUpgrades.Remove(appliedUpgrade);
            Time.timeScale = 1;
        }
    }
}