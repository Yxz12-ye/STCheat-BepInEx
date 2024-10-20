using System;
using System.ComponentModel;
using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using HarmonyLib;
using TheEntity;

namespace STCheat
{
    [BepInPlugin("com.github.yexkr.stcheatuiF", "作弊器UIF", "1.0.0")]
    public class Favor : BaseUnityPlugin
    {
        public static ConfigEntry<bool> _cheatFavor;

        void Start()
        {
            _cheatFavor = Config.Bind("Cheat","Favor", false, "Enable cheat for book");
        }
        //targe: float UpdateFavor(float _favor, float _efficiency = 1f, string _tag = null)
        [HarmonyPrefix,HarmonyPatch(typeof(Role), "UpdateFavor")]
        public static bool UpdateFavorPrefix(ref float _favor, float _efficiency = 1f, string _tag = null)
        {
            Debug.Log("addFavor:" + _favor + " efficiency:" + _efficiency + " tag:" + _tag);
            if (_cheatFavor.Value)
            {
                _favor = 10f;
                Debug.Log("addFavor set to 10 for cheatFavor");
            }
            return true;
        }
    }
}
