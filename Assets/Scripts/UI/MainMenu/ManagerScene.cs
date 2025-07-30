using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelSurvivor.UI.MainMenu
{
    public class ManagerScene : MonoBehaviour
    {
        [SerializeField] private LocationManager _locationManager;
        
        public void LoadScene()
        {
            SceneManager.LoadScene(_locationManager.ActiveSceneName);
        }
    }
}