using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PixelSurvivor.UI.MainMenu.Location
{
    public class LocationPopup : MonoBehaviour
    {
        [SerializeField] private Image _locationImage;
        [SerializeField] private TextMeshProUGUI _locationName;
        [SerializeField] private GameObject _locketLocation;

        public void SetPopup(LocationData locationData)
        {
            if (locationData.LocationActive == true)
            {
                _locketLocation.SetActive(true);
            }
            else
            {
                _locketLocation.SetActive(false);
            }

            _locationImage.sprite = locationData.LocationImage;
            _locationName.text = locationData.LocationName;
        }

        public void HidePopup()
        {
            gameObject.SetActive(false);
        }
    }
}