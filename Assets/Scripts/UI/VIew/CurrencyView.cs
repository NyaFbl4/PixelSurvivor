using TMPro;
using UnityEngine;

namespace PixelSurvivor
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currencyText;
        private long _lastCurrency;

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