using System.Collections.Generic;
using UnityEngine;

namespace PixelSurvivor.UI.MainMenu.Location
{
    [CreateAssetMenu(menuName = "Game/Location", fileName = "LocationsConfig")]
    public class LocationsConfig : ScriptableObject
    {
        [SerializeField] private List<LocationData> _locationDatas;

        public List<LocationData> LocationDatas => _locationDatas;
    }
}