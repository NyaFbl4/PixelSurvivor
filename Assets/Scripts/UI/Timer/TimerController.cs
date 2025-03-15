using TMPro;
using UnityEngine;
using Zenject;

namespace PixelSurvivor
{
    public class TimerController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timeText;
        
        private float _time;

        public void Update()
        {
            _time += Time.deltaTime;
            
            SetterTime(_time);
        }
        
        private void SetterTime(float time)
        {
            int min = Mathf.FloorToInt(time / 60);
            int sec = Mathf.FloorToInt(time % 60);

            // Интерполяция строк
            string timer = $"{min:00}:{sec:00}";

            _timeText.text = timer;
        }
    }
}