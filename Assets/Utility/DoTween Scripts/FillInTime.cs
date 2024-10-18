using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class FillInTime : MonoBehaviour
{
    [Header("Auto Reference for getting image component automatically")]
    [SerializeField] private bool _autoReference = true;
    [Space]
    [SerializeField] private Image _imageToFill;
    [SerializeField] private float _timeToFill = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (_autoReference) _imageToFill = GetComponent<Image>();
        //if (GamesAssistant.gameID == 2) EnableSliderFilling();
        //AdsController.Instance.OnRewardAdCloseEvent.RemoveAllListeners();
        //AdsController.Instance.OnRewardAdCloseEvent.AddListener(() => { LoadSpinWheelScene(); });
        //AdsController.Instance.OnRewardAdFailedEvent.RemoveAllListeners();
        //AdsController.Instance.OnRewardAdFailedEvent.AddListener(() => { LoadSpinWheelScene(); });

        //IronSourceAdsController.Instance.OnInterstitialAdClosedEvent.RemoveAllListeners();
        //IronSourceAdsController.Instance.OnInterstitialAdClosedEvent.AddListener(() => { LoadSpinWheelScene(); });
        //IronSourceAdsController.Instance.OnInterstitialAdFailedEvent.RemoveAllListeners();
        //IronSourceAdsController.Instance.OnInterstitialAdFailedEvent.AddListener(() => { LoadSpinWheelScene(); });

    }

    public void EnableSliderFilling()
    {
        if (StaticUrlScript.isAdsEnabled)
        {
            //AdsController.Instance.DestroyBannerAd();
            //IronSource.Agent.destroyBanner();
            //if (Screen.orientation == ScreenOrientation.Portrait)
            //    IronSourceAdsController.Instance.LoadBannerAd(IronSourceBannerSize.BANNER, placementName: StringConstants.Result_Banner_PlacementName);//AdsController.Instance.LoadBannerAd();
            //else
            //    AdsController.Instance.LoadBannerAd(GoogleMobileAds.Api.AdSize.IABBanner, GoogleMobileAds.Api.AdPosition.Top);
        }
        _imageToFill.DOFillAmount(1, _timeToFill).From(0).OnComplete(() =>
        {
            if (StaticUrlScript.isAdsEnabled)
            {
                LoadInterstitialAd();
            }
            else
            {
                LoadSpinWheelScene();
            }
        });

    }

    public void LoadInterstitialAd()
    {
        //AdsController.Instance.DestroyBannerAd();
        //AdsController.Instance.ShowRewardedAd();
        //IronSource.Agent.destroyBanner();
        //var isAvailable = IronSourceAdsController.Instance.ShowInterstitialAd(placementName: StringConstants.GameScreen_Interstitial_PlacementName);
        //if (!isAvailable)
        //{
        //    LoadSpinWheelScene();
        //}
    }

    private static void LoadSpinWheelScene()
    {
        //Firebase.Analytics.FirebaseAnalytics.LogEvent(StringConstants.Firebase_GameSpinWheelEvent);
        //SceneManager.LoadSceneAsync(StringConstants.SpinWheel);
    }
    private static void LoadDashboard()
    {
        //SceneManager.LoadSceneAsync(StringConstants.Dashboard);
    }
}
