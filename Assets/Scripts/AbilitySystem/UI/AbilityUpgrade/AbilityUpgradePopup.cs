﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PixelSurvivor.NewAbilitySystem.UI
{
    public class AbilityUpgradePopup : MonoBehaviour
    {
        [SerializeField] private Image _displayImage;
        [SerializeField] private TextMeshProUGUI _title;
        
        private Action _applyAction;

        public void Setup(Sprite displayImage, string title, Action onApply)
        {
            _displayImage.sprite = displayImage;
            _title.text = title;
            _applyAction = onApply;
        }
        
        public void Apply()
        {
            _applyAction?.Invoke();
        }
    }
}