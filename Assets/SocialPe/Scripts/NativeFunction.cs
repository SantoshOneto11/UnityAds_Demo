using System;
using UnityEngine;
public static class NativeFunction
{
    public static void UnloadApp()
    {
        Debug.Log("NativeFunction --> Unload App");
        try
        {
#if UNITY_ANDROID && !UNITY_EDITOR
                        AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                        AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                        currentActivity.Call("UnloadAppByNative");

#elif UNITY_IOS && !UNITY_EDITOR
                        string jsonData = "{\"gameID\":" + 0 + ",\"gameversion\":" + 0 + ",\"GameStatus\":" + 202 + ",\"Response\":\"" + "" + "\"}";
                        NativeAPI.sendMessageToMobileApp(jsonData);
                        Application.Unload();
#endif
        }
        catch (Exception E)
        {
            Utility.myLogError(string.Format("{0} Exception caught.", E));
        }
    }

    public static void EnablePortrait()
    {
#if UNITY_ANDROID
        Screen.orientation = ScreenOrientation.Portrait;

#elif UNITY_IOS
                Debug.Log("<--- Request for Portrait IOS  ---> ");
                string jsonData = "{\"orientation\":" + 1 + "}";
                NativeAPI.sendMessageToMobileApp(jsonData);
#endif
    }

    public static void EnableLandscape()
    {
#if UNITY_ANDROID
        Screen.orientation = ScreenOrientation.LandscapeLeft;

#elif UNITY_IOS
                Debug.Log("<--- Request for Portrait IOS  ---> ");
                string jsonData = "{\"orientation\":" + 2 + "}";
                NativeAPI.sendMessageToMobileApp(jsonData);
#endif
    }

    public static void ShareImage(string path, string message)
    {
        Utility.myLog("ShareImage -> " + path);
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            currentActivity.Call("shareImage", path, message);
        
#elif UNITY_IOS && !UNITY_EDITOR
            string jsonData = "{\"gameID\":0,\"gameversion\":0,\"GameStatus\":207,\"Response\":{\"ImagePath\":\"" + path + "\",\"ImageMessage\":\"" + "" + "\"}}";
        NativeAPI.sendMessageToMobileApp(jsonData);
#endif
    }

    //    public static void SpinWheelConsumed(int type)
    //    {
    //        Utility.myLog("SpinWheelConusmed -> " + type);
    //#if UNITY_ANDROID && !UNITY_EDITOR
    //            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    //            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    //            currentActivity.Call("spinWheelConsumed", type);

    //#elif UNITY_IOS && !UNITY_EDITOR
    //           // Todo
    //#endif
    //    }


    public static void UpdateCoins(double finalCoins)
    {
        Utility.myLog("UpdateCoins -> " + finalCoins);
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            currentActivity.Call("updateCoins", finalCoins);

#elif UNITY_IOS && !UNITY_EDITOR
           // Todo
#endif
    }

    public static void SendNativeData(int gameId, bool Data)
    {
        Utility.myLog("SendNativeData-->" + gameId + "  " + Data);
        //        try
        //        {
        //#if UNITY_ANDROID && !UNITY_EDITOR
        //            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        //            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        //            currentActivity.Call("shouldOpenGame",gameId, Data);

        //#endif
        //        }
        //        catch (Exception E)
        //        {
        //            Utility.myLogError(string.Format("{0} Exception caught.", E));
        //        }
    }

    public static void ShowInterstitialAd()
    {
        Utility.myLog("ShowInterstitialAd -> ");
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            currentActivity.Call("showInterstitialAd");

#elif UNITY_IOS && !UNITY_EDITOR
           // Todo
#endif

    }
    public static void ShowRewardedAd()
    {
        Utility.myLog("ShowRewardedAd -> ");
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            currentActivity.Call("showRewardedAd");

#elif UNITY_IOS && !UNITY_EDITOR
           // Todo
#endif

    }
    public static string GetDeviceId()
    {
        string data = "";
        Utility.myLog("GetDeviceId -> ");
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
           data =  currentActivity.Call<string>("getDeviceId");

#elif UNITY_IOS && !UNITY_EDITOR
           // Todo
#endif
        return data;
    }

    public static string GetXToken()
    {
        string data = "";
        Utility.myLog("GetXToken -> ");
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
           data =  currentActivity.Call<string>("getXToken");

#elif UNITY_IOS && !UNITY_EDITOR
           // Todo
#endif
        return data;
    }

    public static bool IsOnline()
    {
        bool online = false;
        Utility.myLog("GetXToken -> ");
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
           online =  currentActivity.Call<bool>("isOnline");

#elif UNITY_IOS && !UNITY_EDITOR
           // Todo
#endif
        return online;
    }
}
