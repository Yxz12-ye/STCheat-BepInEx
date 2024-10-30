using System;
using System.ComponentModel;
using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using HarmonyLib;
using TheEntity;

namespace STCheat
{
    [BepInPlugin("com.github.yexkr.stcheatf", "作弊器f", "1.0.0")]
    public class Favor : BaseUnityPlugin
    {
        //public static ConfigEntry<bool> _cheatFavor;

        void Start()
        {
            //_cheatFavor = Config.Bind("Cheat","Favor", false, "Enable cheat for book");
        }
        //targe: float UpdateFavor(float _favor, float _efficiency = 1f, string _tag = null)
        [HarmonyPrefix,HarmonyPatch(typeof(Role), "UpdateFavor")]
        public static bool UpdateFavorPrefix(ref float _favor, float _efficiency = 1f, string _tag = null)
        {
            Debug.Log("addFavor:" + _favor + " efficiency:" + _efficiency + " tag:" + _tag);
            if (ConfigMgr._cheatFavor.Value)
            {
                _favor *= ConfigMgr._favor_times.Value;
                Debug.Log("好感增加倍率为:" + ConfigMgr._favor_times.Value);
            }
            return true;
        }
    }
}
