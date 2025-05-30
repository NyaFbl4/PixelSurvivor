﻿using System;
using UnityEngine;

namespace PixelSurvivor.NewAbilitySystem.Ability
{
    public class HealthAbility : PlayerAbility
    {
        [SerializeField] private int _healthCount;

        private GameObject _player;

        public HealthAbility(int healthCount)
        {
            _healthCount = healthCount;
        }

        public override void UpgradeAbility()
        {
            Debug.Log("Upgrade HealthAbility");
        }

        public override void Added(GameObject player)
        {
            _player = player;
        }

        public override void ApplyCast()
        {
            if (_player != null)
            {
                _player.GetComponent<PlayerHealthController>().AddHealth(_healthCount);
                ChangeCooldownTimer(CooldownTime);
                ChangeAbilityState(EAbilityState.Cooldown);
            }
        }

        public override void EventTick(float deltaTick)
        {
            if (AbilityState == EAbilityState.Cooldown)
            {
                ChangeCooldownTimer(CooldownTimer - deltaTick);

                if (CooldownTimer <= 0.0f)
                {
                    Debug.Log(EAbilityState.Ready);
                    
                    ChangeAbilityState(EAbilityState.Ready);
                }
            }
        }
    }
}