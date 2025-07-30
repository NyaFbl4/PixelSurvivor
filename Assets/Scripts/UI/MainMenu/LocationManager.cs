using System.Collections.Generic;
using PixelSurvivor.UI.MainMenu.Location;
using UnityEngine;
using Zenject;

namespace PixelSurvivor.UI.MainMenu
{
    public class LocationManager : MonoBehaviour
    {
        [SerializeField] private LocationsConfig _locationsConfig;
        [SerializeField] private LocationPopupProvider _popupProvider;

        [SerializeField] private List<LocationData> _locationDatas = new();
        [SerializeField] private int _nomberLocation;
        [SerializeField] private int _countLocation;

        private string _activeSceneName;
        public string ActiveSceneName => _activeSceneName;
        
        public void Start()
        {
            SettupLocation();
        }
        
        private void SettupLocation()
        {
            _locationDatas = _locationsConfig.LocationDatas;
            _countLocation = _locationDatas.Count;
            _nomberLocation = 0;

            ShowLocation(_nomberLocation);
        }

        private void ShowLocation(int nomber)
        {
            _popupProvider.TakeLocation(_locationDatas[nomber]);
            _activeSceneName = _locationDatas[nomber].LocationSceneName;
        }

        public void NextLocation()
        {
            _nomberLocation++;

            if (_nomberLocation >= _countLocation)
            {
                _nomberLocation = 0;
            }
            else if (_nomberLocation < 0)
            {
                _nomberLocation = _countLocation;
            }
            
            ShowLocation(_nomberLocation);
        }

        public void PerviousLocation()
        {
            _nomberLocation--;
            
            if (_nomberLocation > _countLocation)
            {
                _nomberLocation = 0;
            }
            else if (_nomberLocation < 0)
            {
                _nomberLocation = _countLocation - 1;
            }
            
            ShowLocation(_nomberLocation);
        }
    }
}