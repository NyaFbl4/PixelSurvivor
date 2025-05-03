using System;
using UnityEngine;

namespace PixelSurvivor.UI.MainMenu.Location
{
    public class LocationPopupProvider : MonoBehaviour
    {
        [SerializeField] private RectTransform _widgetContainer;
        [SerializeField] private LocationPopup _locationPopup;

        public void TakeLocation(LocationData locationData)
        {
            foreach (Transform  child in _widgetContainer)
            {
                Destroy(child.gameObject);
            }
            
            var widget = Instantiate(_locationPopup, _widgetContainer);
            
            widget.SetPopup(locationData);
        }
    }
}