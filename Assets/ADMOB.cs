using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class ADMOB : MonoBehaviour
{
    InterstitialAd interstitial;         //FullSize Admob
    GameOverScript GSCript;
    private RewardBasedVideoAd rewardBasedVideo;      //VideoAdmob

    public void Start()
    {

#if UNITY_ANDROID
        string appId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
            string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;


        //double up the goldcoins

        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;



        this.RequestRewardBasedVideo();  //videdo Admob


        RequestInterstitial();  //FullSize Admob
    }


    // fullSize Admob initialized

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }
    public void OnButtonCLicked()
    {
        if (interstitial.IsLoaded())
        {
            Debug.Log("Working");
            interstitial.Show();
        }
        else
            Debug.Log("NOt Working");
    }


    //video Admob initialized
    private void RequestRewardBasedVideo()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);


         
    }
    public  void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        
        ScoreBoardManager.GoldCoins = ScoreBoardManager.GoldCoins * 2;

        
        PlayerPrefs.SetInt("Goldcoin_Godown", PlayerPrefs.GetInt("Goldcoin_Godown") + ScoreBoardManager.GoldCoins);
        ScoreBoardManager.GoldCoins = 0;
    }

    public void GoldCoinVideoADMOB()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        }
    }
}









