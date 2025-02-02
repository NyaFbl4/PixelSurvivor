using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;


namespace PixelSurvivor
{
    public class DamageUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _damageText;
        [SerializeField] private Animator _animator;
        [SerializeField] private string _stateName;

        public void Play(int damage)
        {
            _damageText.text = damage.ToString();
            _animator.Play(_stateName);
        }
    }
}