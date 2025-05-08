using System;
using PixelSurvivor.NewAbilitySystem.UI;
using UnityEngine;

namespace PixelSurvivor.EntryPoints
{
    public class SceneEntryPoint : MonoBehaviour
    {
        [SerializeField] private AbilityUpgradeManager _upgradeManager;

        private void Start()
        {
            //_upgradeManager.SuggestUpgrades();
        }
    }
}