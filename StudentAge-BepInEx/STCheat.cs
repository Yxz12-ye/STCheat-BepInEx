using System;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using TheEntity;
using BepInEx.Configuration;

namespace STCheat
{
    [BepInPlugin("com.github.yexkr.stcheat", "STCheat", "1.0.0")]
    public class STCheat : BaseUnityPlugin
    {
        void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(STCheatUI));
            Harmony.CreateAndPatchAll(typeof(Favor));
            Harmony.CreateAndPatchAll(typeof(BookAndStudy));
            Debug.Log("STCheat loaded in Awake");
        }
    }

    [BepInPlugin("com.github.yexkr.stcheatui", "作弊器UI", "1.0.0")]
    public class STCheatUI : BaseUnityPlugin
    { 
        public static ConfigEntry<bool> _cheatEnergy;
        public static ConfigEntry<bool> _cheatMoney;
        public static ConfigEntry<bool> _cheatMood;
        public static ConfigEntry<bool> _cheatTrust;


        void Start()
        {
            _cheatEnergy = Config.Bind("Cheat", "Energy", false, "Enable cheat for energy");
            _cheatMoney = Config.Bind("Cheat", "Money", false, "Enable cheat for money");
            _cheatMood = Config.Bind("Cheat", "Mood", false, "Enable cheat for mood");
            _cheatTrust = Config.Bind("Cheat", "Trust", false, "Enable cheat for trust");

            //Role role = new TheEntity.Role();
            Debug.Log("STCheatUI loaded in Awake");

        }


        //targe: System.Single TheEntity.Role::UpdateAttr(System.Int32,System.Single,System.Single,System.String,System.Boolean)
        [HarmonyPrefix,HarmonyPatch(typeof(Role), "UpdateAttr")]
        public static bool UpdateAttrPrefix(ref int key, ref float addValue, float efficiency = 1f,  string _tag = null,  bool _toast = true)
        {
            Debug.Log("UpdateAttr key: " + key + " addValue: " + addValue + " efficiency: " + efficiency + " tag: " + _tag + " toast: " + _toast );
            if (_cheatMoney.Value && key == 30 && addValue < 0)//30 is money
            {
                addValue = 0;
                Debug.Log("addValue set to 0 for key 30 (money)");
            }
            if (_cheatEnergy.Value && key==7 && addValue < 0)//7 is energy
            {
                addValue = 0;
                Debug.Log("addValue set to 0 for key 7 (engrgy)");
            }
            if (_cheatMood.Value && key == 0 && addValue < 0)//0 is mood
            {
                addValue = 0;
                Debug.Log("addValue set to 0 for key 8 (mood)");
            }
            if(_cheatTrust.Value&& key == 0 &&addValue < 0)
            {
                addValue = 0;
                Debug.Log("addValue set to 0 for key 0 (trust)");
            }
            return true;
        }
    }

}

