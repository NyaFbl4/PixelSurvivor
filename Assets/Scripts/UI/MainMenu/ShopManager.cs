using UnityEngine;

namespace PixelSurvivor.UI.MainMenu
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private GameObject _shop;

        public void OpenShop()
        {
            _shop.SetActive(true);
        }

        public void CloseShop()
        {
            _shop.SetActive(false);
        }
    }
}