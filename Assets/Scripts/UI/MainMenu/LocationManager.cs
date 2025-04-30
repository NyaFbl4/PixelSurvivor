using System.Collections.Generic;
using PixelSurvivor.UI.MainMenu.Location;
using UnityEngine;

namespace PixelSurvivor.UI.MainMenu
{
    public class LocationManager : MonoBehaviour
    {
        [SerializeField] private LocationsConfig _locationsConfig;
        [SerializeField] private LocationPopupProvider _popupProvider;

        private List<LocationData> _locationDatas = new();
        private int _nomberLocation;

        private void SettupLocation()
        {
            _locationDatas = _locationsConfig.LocationDatas;
            _nomberLocation = 0;
        }

        private void ShowLocation(int nomber)
        {
            _popupProvider.TakeLocation(_locationDatas[nomber]);
        }
        
        
    }
}