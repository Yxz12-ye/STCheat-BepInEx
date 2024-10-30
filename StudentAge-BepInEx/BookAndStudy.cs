using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System;
using UnityEngine;

namespace STCheat
{
    [BepInPlugin("com.github.yexkr.stcheatbs", "作弊器bs", "1.0.0")]
    public class BookAndStudy : BaseUnityPlugin
    {
        //public static ConfigEntry<bool> _cheatBook;

        void Start()
        {
            //_cheatBook = Config.Bind("Cheat", "Book", false, "Enable cheat for book");
        }
        //targe:System.ValueTuple`2<System.Single,System.Single> BagMgr::GetReadBookWillAddProgress(BookData,System.Single)
        [HarmonyPrefix,HarmonyPatch(typeof(BagMgr), "GetReadBookWillAddProgress")]
        public static bool GetReadBookWillAddProgressPrefix(ref BookData _book, ref ValueTuple<float, float> __result, float _rate = 1f )
        {
            Debug.Log("bookdate:"+ _book.Name +"rate:"+_rate);
            if(ConfigMgr._cheatBook.Value)
            {
                _rate = 10f;
                _book.cur = _book.max;
                Debug.Log("rate set to 10 for cheatBook");
            }
            
            return true;
        }
    }
}