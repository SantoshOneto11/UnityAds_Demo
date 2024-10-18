
public static class StaticUrlScript
{
    public static bool isProd = true;
    public static bool isFromVideo = false;
    public static bool isLoggerEnabled = false;
    public static bool isAdsEnabled = true;
    public static bool isRewardUpdated = false;
    public static string fcmtoken;

    public static bool isTesting = false;
    public static string AppKey
    {
        get
        {
            if (!isTesting)
            {
                return "1e0a6fbcd"; // knifeHit Ironsource Appkey
            }
            else
            {
                return "85460dcd"; //Testing App key Ironsource
            }
        }
    }
    public static string AuthURL
    {
        get
        {
            if (isProd)
            {
                return "https://iauth.oneto11.com/api/";
            }
            else
            {
                return "https://auth.oneto11.com/api/";
            }
        }
    }
    public static string TransURL
    {
        get
        {
            if (isProd)
            {
                return "https://itrans.oneto11.com/api/";
            }
            else
            {
                return "https://trans.oneto11.com/api/";
            }
        }
    }

    public static string shareMessage;

    //Event Codes to send to Native 
    public static int ErrorInDownloadingBundleEventCode = -3;
    public static int ErrorInJoiningRoomEventCode = -2;
    public static int NoOpponentFoundEventCode = -1;
    public static int BundleDownloadEventCode = 1;
    public static int GameFinishEventCode = 2;
    public static int RoomFullEventCode = 3;
    public static int LeaveGameEventCode = 4;
    public static int JoinRoomFailedEventCode = 5;

#if UNITY_ANDROID
    public static string Ludo_BundleURL = "https://oneto11storageaccount.blob.core.windows.net/gameassests/ludo_android";
    public static string FruitSlice_BundleURL = "https://oneto11storageaccount.blob.core.windows.net/gameassests/fruit_android";
    public static string KnifeHit_BundleURL = "https://oneto11storageaccount.blob.core.windows.net/gameassests/knifehit_android";
    public static string Game2048_BundleURL = "https://firebasestorage.googleapis.com/v0/b/fir-2af34.appspot.com/o/2048?alt=media&token=74db3900-7100-4a3c-b611-4f7f0c684be0";
    public static string Rummy_BundleURL = "https://oneto11storageaccount.blob.core.windows.net/gameassests/rummy_android";

#elif UNITY_IOS
    public static string Ludo_BundleURL = "https://oneto11storageaccount.blob.core.windows.net/gameassests/ios/ludo_ios";
    public static string FruitSlice_BundleURL = "https://oneto11storageaccount.blob.core.windows.net/gameassests/ios/fruit_ios";
    public static string KnifeHit_BundleURL = "https://oneto11storageaccount.blob.core.windows.net/gameassests/ios/knifehit_ios";
    public static string Game2048_BundleURL = "https://firebasestorage.googleapis.com/v0/b/fir-7dd70.appspot.com/o/IOS%20Bundles%2Fgame_ios_2048?alt=media&token=fee41abb-ca64-4ae7-ae02-0e3b3901eed6";
    public static string Rummy_BundleURL = "https://oneto11storageaccount.blob.core.windows.net/gameassests/ios/rummy_ios";
#endif

}
