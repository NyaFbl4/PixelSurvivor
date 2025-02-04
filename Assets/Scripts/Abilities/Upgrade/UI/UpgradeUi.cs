using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PixelSurvivor
{
    public class UpgradeUi : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Image _icon;

        private Action _applyAction;
        
        public void Setup(string title, Sprite icon, Action onApply)
        {
            this._title.text = title;
            this._icon.sprite = icon;
            this._applyAction = onApply;
        }

        public void Apply()
        {
            _applyAction?.Invoke();
        }
    }
}