using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Analytics;   

public class AnalyticsManager 
{
   private static void LogEvent(string eventName, params Parameter[]parameters)
    {
        // untuk method utama untuk menembakan firebase
        FirebaseAnalytics.LogEvent(eventName, parameters);
    }
    public static void LogUpgradeEvent (int resourceIndex, int level)
    {
        // untuk kita memakai event dan parameter yang tersedia di firebase(tidak memakai yang custom)
        // untuk agar dapat muncul sebagai report data di analityc firebase
        LogEvent(
            FirebaseAnalytics.EventLevelUp,
            new Parameter(FirebaseAnalytics.ParameterIndex, resourceIndex.ToString()),
            new Parameter(FirebaseAnalytics.ParameterLevel, level));
        // untuk karena resourceindex digunakan sebagai id, maka seharusnya kita menyimpannya sebagai string bukan integer
    }
    public static void LogUnlockEvent(int resourceIndex)
    {
        LogEvent(
            FirebaseAnalytics.EventUnlockAchievement, new Parameter(FirebaseAnalytics.ParameterIndex, resourceIndex.ToString()));   
    }
    public  static void SetUserProperties (string name, string value)
    {
        FirebaseAnalytics.SetUserProperty(name, value);
    }
}
