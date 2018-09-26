﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class RewardAdmob : MonoBehaviour
{
    public static bool videowatchedfully = false;

    private RewardBasedVideoAd rewardBasedVideo;      //RewardVideoAdmob

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

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        videowatchedfully = true;
      
    }

    public void GoldCoinVideoADMOB()
    {
        if (rewardBasedVideo.IsLoaded())
        {          
            rewardBasedVideo.Show();
        }
    }
}









