

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;


public class GameOverScript : MonoBehaviour
{

    public Text FinalScore;
    public Text BestScore;
    public Text GoldCoinBest;

  

    InterstitialAd interstitial;


    // Use this for initialization
    void Start()
    {

       

          
        RequestInterstitial();

    }

    
    void Update()
    {
      
        if (gamemanager.gameState == gamemanager.GameState.Gameover)
        {
            
            FinalScore.text = "Score : " + ScoreBoardManager.Score;
            BestScore.text = "Best : " + ScoreBoardManager.highscore;
            GoldCoinBest.text = "Your Gold : " + ScoreBoardManager.GoldCoins;
            gamemanager.gameState = gamemanager.GameState.empty;
        }
        
    }
    public void RestartButton()
    {
        
        if ((gamemanager.ReloadValue % 5) == 0)
        {
            if (interstitial.IsLoaded())
            {
       
                Debug.Log("Working");
                interstitial.Show();
            }
       
        }

        

       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  

        PlayerPrefs.SetInt("Goldcoin_Godown", PlayerPrefs.GetInt("Goldcoin_Godown") + ScoreBoardManager.GoldCoins);
        ScoreBoardManager.GoldCoins = 0;

    }

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
}