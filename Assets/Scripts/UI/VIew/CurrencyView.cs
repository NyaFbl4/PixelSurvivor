using TMPro;
using UnityEngine;

namespace PixelSurvivor
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currencyText;
        private int _lastCurrency;

        public void SetupCurrency(int currency)
        {
            Setter(currency);
            _lastCurrency = currency;
        }

        public void UpdateCurrency(int currency)
        {
            _lastCurrency = currency;
            Setter(_lastCurrency);
        }

        private void Setter(int value)
        {
            _currencyText.text = value.ToString();
        }
    }
}