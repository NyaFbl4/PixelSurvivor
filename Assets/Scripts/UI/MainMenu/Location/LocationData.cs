using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PixelSurvivor.UI.MainMenu.Location
{
    [Serializable]
    public class LocationData
    {
        [SerializeField] private string _locationName;
        [SerializeField] private Sprite _locationImage;
        [SerializeField] private string _locationSceneName;
        [SerializeField] private bool _locationActive;

        public string LocationName => _locationName;
        public Sprite LocationImage => _locationImage;
        public string LocationSceneName => _locationSceneName;
        public bool LocationActive => _locationActive;
    }
}