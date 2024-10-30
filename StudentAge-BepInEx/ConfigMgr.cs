using System;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using TheEntity;
using BepInEx.Configuration;

namespace STCheat
{
    [BepInPlugin("com.github.yexkr.stcheatui", "作弊器UI", "1.0.0")]
    public class ConfigMgr : BaseUnityPlugin
    {
        public static ConfigEntry<bool> _cheatEnergy;
        public static ConfigEntry<bool> _cheatMoney;
        public static ConfigEntry<bool> _cheatMood;
        public static ConfigEntry<bool> _cheatTrust;
        public static ConfigEntry<bool> _cheatBook;
        public static ConfigEntry<bool> _cheatFavor;
        public static ConfigEntry<int> _attr_times;
        public static ConfigEntry<int> _favor_times;
        public void Initialize()
        {
            _cheatEnergy = Config.Bind("Cheat", "Energy", false, "Enable cheat for energy");
            _cheatMoney = Config.Bind("Cheat", "Money", false, "Enable cheat for money");
            _cheatMood = Config.Bind("Cheat", "Mood", false, "Enable cheat for mood");
            _cheatTrust = Config.Bind("Cheat", "Trust", false, "Enable cheat for trust");
            _cheatBook = Config.Bind("Cheat", "Book", false, "Enable cheat for book");
            _cheatFavor = Config.Bind("Cheat","Favor", false, "Enable cheat for favor");
            _attr_times = Config.Bind("Cheat", "Times for attr", 1, new ConfigDescription("cheat times",new AcceptableValueRange<int>(-5,5)));
            _favor_times = Config.Bind("Cheat", "Times for favor", 1, new ConfigDescription("cheat times", new AcceptableValueRange<int>(0, 5)));
        }

        void Start()
        {
            Initialize();
        }

    }
}
