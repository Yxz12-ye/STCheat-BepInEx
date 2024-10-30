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
            Harmony.CreateAndPatchAll(typeof(ConfigMgr));
            Harmony.CreateAndPatchAll(typeof(STCheatUI));
            Harmony.CreateAndPatchAll(typeof(Favor));
            Harmony.CreateAndPatchAll(typeof(STCheat));
            Harmony.CreateAndPatchAll(typeof(BookAndStudy));
            Debug.Log("STCheat loaded in Awake");
        }
    }
    [BepInPlugin("com.github.yexkr.stcheatm", "作弊器m", "1.0.0")]
    public class STCheatUI : BaseUnityPlugin
    { 
        //public static ConfigEntry<bool> _cheatEnergy;
        //public static ConfigEntry<bool> _cheatMoney;
        //public static ConfigEntry<bool> _cheatMood;
        //public static ConfigEntry<bool> _cheatTrust;


        void Start()
        {
            //ConfigMgr._cheatEnergy = Config.Bind("Cheat", "Energy", false, "Enable cheat for energy");
            //ConfigMgr._cheatMoney = Config.Bind("Cheat", "Money", false, "Enable cheat for money");
            //ConfigMgr._cheatMood = Config.Bind("Cheat", "Mood", false, "Enable cheat for mood");
            //ConfigMgr._cheatTrust = Config.Bind("Cheat", "Trust", false, "Enable cheat for trust");

            //Role role = new TheEntity.Role();
            Debug.Log("STCheatUI loaded in Awake");

        }


        //targe: System.Single TheEntity.Role::UpdateAttr(System.Int32,System.Single,System.Single,System.String,System.Boolean)
        [HarmonyPrefix,HarmonyPatch(typeof(Role), "UpdateAttr")]
        public static bool UpdateAttrPrefix(ref int key, ref float addValue,ref Role __instance, float efficiency = 1f,  string _tag = null,  bool _toast = true)
        {
            Debug.Log("UpdateAttr key: " + key + " addValue: " + addValue + " efficiency: " + efficiency + " tag: " + _tag + " toast: " + _toast );
            Debug.Log("Role: " + __instance.Name);
            if (ConfigMgr._cheatMoney.Value && key == 30)//30 is money
            {
                if(addValue < 0)
                {
                    addValue = 0;
                    Debug.Log("钱币不减生效");
                }
                else
                {
                    addValue *= ConfigMgr._attr_times.Value;
                }
            }
            if (ConfigMgr._cheatEnergy.Value && key==7 && addValue < 0)//7 is energy
            {
                if (addValue < 0)
                {
                    addValue = 0;
                    Debug.Log("能量不减生效");
                }
                else
                {
                    addValue *= ConfigMgr._attr_times.Value;
                }
            }
            if (ConfigMgr._cheatMood.Value && key == 0 && addValue < 0)//0 is mood
            {
                if (addValue < 0)
                {
                    addValue = 0;
                    Debug.Log("心情不减生效");
                }
                else
                {
                    addValue *= ConfigMgr._attr_times.Value;
                }
            }
            if(ConfigMgr._cheatTrust.Value&& key == 0 &&addValue < 0)
            {
                if (addValue < 0)
                {
                    addValue = 0;
                    Debug.Log("信任不减生效");
                }
                else
                {
                    addValue *= ConfigMgr._attr_times.Value;
                }
            }
            return true;
        }
    }

}

