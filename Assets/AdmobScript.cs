using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class AdmobScript : MonoBehaviour {
    //BannerView bannerAd;
    // InterstitialAd interstitialAd;
    //void Start()
    //{
    //
    //    showBannerAd();
    //
    //}
    //
    //private void showBannerAd()
    //{
    //    string adID = "ca-app-pub-3940256099942544/6300978111";
    //
    //    //***For Testing in the Device***
    //    AdRequest request = new AdRequest.Builder()
    //   .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
    //   .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")  // My test device.
    //   .Build();
    //
    //
    //
    //     //***For Production When Submit App***
    //     //AdRequest request = new AdRequest.Builder().Build();
    //     
    //   bannerAd = new BannerView(adID, AdSize.MediumRectangle, AdPosition.Bottom);
    //   bannerAd.LoadAd(request);
    //
    //    
    //}
    //
    //public void onSceneLoaded()
    //{
    //     
    //   bannerAd.Hide();
    //}           

    private BannerView bannerView;

    [SerializeField] private string AppId = "ca-app-pub-7338837470800808~7359101499";
    [SerializeField] private string bannerId = "ca-app-pub-7338837470800808/1120996205";
    [SerializeField] private string regularAdId = "ca-app-pub-7338837470800808/1018738635";


    void Awake()
    {
        MobileAds.Initialize(AppId);
    }

    public void OnClickRegularAdd()
    {
        this.RequestForRegularAdd();
    }
    public void OnClickBannerAdd()
    {
        this.RequestForBannerAdd();
    }

    private void RequestForRegularAdd()
    {
        InterstitialAd FullSizeAd = new InterstitialAd(regularAdId);

        AdRequest request = new AdRequest.Builder().Build();

        FullSizeAd.LoadAd(request);

    }
    private void RequestForBannerAdd()
    {
        BannerView bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }

}

