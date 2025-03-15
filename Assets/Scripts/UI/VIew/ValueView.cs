using TMPro;
using UnityEngine;

namespace PixelSurvivor
{
    public class ValueView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currencyText;
        private long _lastCurrency;
        private float _lastTime;

        public void SetupCurrency(long currency)
        {
            Setter(currency);
            _lastCurrency = currency;
        }

        public void UpdateCurrency(long currency)
        {
            _lastCurrency = currency;
            Setter(_lastCurrency);
        }

        private void Setter(long value)
        {
            _currencyText.text = value.ToString();
        }
    }
}