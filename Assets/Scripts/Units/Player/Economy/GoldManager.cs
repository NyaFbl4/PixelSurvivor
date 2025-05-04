﻿using UnityEngine;

namespace PixelSurvivor.Units.Player.Economy
{
    public static class GoldManager
    {
        private const string GoldKey = "PlayerGold";

        public static int Gold
        {
            get => PlayerPrefs.GetInt(GoldKey, 0);

            set
            {
                PlayerPrefs.SetInt(GoldKey, value);
                PlayerPrefs.Save();
            }
        }
        
        public static void AddGold(int amount)
        {
            Gold += amount;
        }

        public static bool SpendGold(int amount)
        {
            if (Gold >= amount)
            {
                Gold -= amount;
                return true;
            }
            
            return false;
        }
    }
}