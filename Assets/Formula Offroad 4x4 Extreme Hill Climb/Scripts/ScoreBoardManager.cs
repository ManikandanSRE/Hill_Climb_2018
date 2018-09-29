

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;


public class ScoreBoardManager : MonoBehaviour
{   
    public GameObject[] RGCoins;

    public GameObject InstatiatePlace;
    int requiredPlate = 2;

    public static bool createCoin;

    public static int Score;
    public static int highscore;

    public static int GoldGodown;      //total gold coins in shop 
    public static int GoldCoins;      //inside the game.... current gold coins counting...



    public static int LevelsCounter;     //level counting numbers....
    int MultiforScore =2;
    public GameObject LevelsTextObj;
    public GameObject NextLevelTextObj;

    public GameObject GoldCoinText;
    Text GoldCoinValue;

    public GameObject ScoreText;
    Text ScoreValues;

    public GameObject HighScoreText;
    Text HighScorevalue;

    void Awake()
    {
        HighScoreText = GameObject.Find("High Score Board");

        GoldGodown = PlayerPrefs.GetInt("Goldcoin_Godown");


        if (GameController.GameModeAccess == "EASY")
        {
            highscore = PlayerPrefs.GetInt("HighScore_EASY", highscore);
        }
        else if (GameController.GameModeAccess == "NORMAL")
        {
            highscore = PlayerPrefs.GetInt("HighScore_NORMAL", highscore);
        }
        else if (GameController.GameModeAccess == "HARD")
        {
            highscore = PlayerPrefs.GetInt("HighScore_HARD", highscore);
        }
        else if (GameController.GameModeAccess == "EXTREME HARD")
        {
            highscore = PlayerPrefs.GetInt("HighScore_EXTREMEHARD", highscore);
        }

        HighScorevalue = HighScoreText.GetComponent<Text>();
        HighScorevalue.text = "High Score : " + highscore.ToString();
        Score = 0;
        GoldCoins = 0;
        LevelsCounter = 0;

    }
    // Use this for initialization
    void Start()
    {
        createCoin = true;
        LevelsTextObj.GetComponent<Text>().text = "";  //while start game text hidden inside the game.
        NextLevelTextObj.GetComponent<Text>().text = ""; //while start game text hidden inside the game.
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gamemanager.gameState == gamemanager.GameState.playing)
        {
            if (GameController.GameModeAccess == "EASY")
            {

                if (Score != 0 && (Score % 25) == 0 && createCoin)
                {

                    GameObject Gb = Instantiate(RGCoins[Random.Range(0, RGCoins.Length)], InstatiatePlace.transform.position, Quaternion.identity) as GameObject;
                    createCoin = false;

                }
                if ((Score % 25) == 5)
                {
                    createCoin = true;
                }

            }

            else if (GameController.GameModeAccess == "NORMAL")
            {

                if (Score != 0 && (Score % 20) == 0 && createCoin)
                {

                    GameObject Gb = Instantiate(RGCoins[Random.Range(0, RGCoins.Length)], InstatiatePlace.transform.position, Quaternion.identity) as GameObject;
                    createCoin = false;

                }
                if ((Score % 20) == 5)
                {
                    createCoin = true;
                }

            }

            else if (GameController.GameModeAccess == "HARD")
            {

                if (Score != 0 && (Score % 15) == 0 && createCoin)
                {

                    GameObject Gb = Instantiate(RGCoins[Random.Range(0, RGCoins.Length)], InstatiatePlace.transform.position, Quaternion.identity) as GameObject;
                    createCoin = false;

                }
                if ((Score % 15) == 5)
                {
                    createCoin = true;
                }

            }

            else if (GameController.GameModeAccess == "EXTREME HARD")
            {

                if (Score != 0 && (Score % 10) == 0 && createCoin)
                {

                    GameObject Gb = Instantiate(RGCoins[Random.Range(0, RGCoins.Length)], InstatiatePlace.transform.position, Quaternion.identity) as GameObject;
                    createCoin = false;

                }
                if ((Score % 10) == 5)
                {
                    createCoin = true;
                }

            }
        }
    }
    public void GoldCoinAccess()
    {
        ScoreText = GameObject.Find("Score");
        ScoreValues = ScoreText.GetComponent<Text>();


        GoldCoinText = GameObject.Find("GOLD COIN");

        Debug.Log(GoldCoinText.name);
        GoldCoinValue = GoldCoinText.GetComponent<Text>();


        if (triggerdetection.CollusionStatus == "RedCoin" || triggerdetection.CollusionStatus == "GreenCoin")
        {
            Debug.Log("SCoreBoardManager");
            GoldCoinValue.text = "GoldCoin : " + ++GoldCoins;

        }
        else
        {
            Score += 1;
            ScoreValues.text = "Score : " + Score;
            LevelPopPup();
        }

        if (GameController.GameModeAccess == "EASY")
        {
            if (Score != 0 && (Score % 10) == 0)
            {
                GoldCoins += 1;
                GoldCoinValue.text = "Gold Coins : " + GoldCoins;
            }

        }
        else if (GameController.GameModeAccess == "NORMAL")
        {
            if (Score != 0 && (Score % 10) == 0)
            {
                GoldCoins += 2;
                GoldCoinValue.text = "Gold Coins : " + GoldCoins;
            }
        }
        else if (GameController.GameModeAccess == "HARD")
        {
            if (Score != 0 && (Score % 10) == 0)
            {
                GoldCoins += 3;
                GoldCoinValue.text = "Gold Coins : " + GoldCoins;

            }
        }
        else if (GameController.GameModeAccess == "EXTREME HARD")
        {
            if (Score != 0 && (Score % 10) == 0)
            {
                GoldCoins += 4;
                GoldCoinValue.text = "Gold Coins : " + GoldCoins;

            }
        }

    }

    public void LevelPopPup()
    {

        LevelsTextObj = GameObject.Find("LEVELS");

        if ((Score%2==0))
        {                     
            LevelsTextObj.gameObject.SetActive(true);            
            LevelsCounter += 1;
            LevelsTextObj.GetComponent<Text>().text = "Level: " + LevelsCounter + " completed";          
        }
    }


   


    public void SetHighScore()
    {

        ++gamemanager.ReloadValue;

        GoldGodown = GoldGodown + GoldCoins;


        string[] ScoresArray;
        if (GameController.GameModeAccess == "EASY")
        {
            ScoresArray = gamemanager.EasyArray;

        }

        else if (GameController.GameModeAccess == "NORMAL")
        {
            ScoresArray = gamemanager.NormalArray;
        }

        else if (GameController.GameModeAccess == "HARD")
        {
            ScoresArray = gamemanager.HardArray;
        }

        else
        {
            ScoresArray = gamemanager.ExtremeArray;
        }


        for (int i = 0; i < ScoresArray.Length; i++)
        {
            if (Score > System.Convert.ToInt32(ScoresArray[i]))
            {
                for (int j = ScoresArray.Length - 1; j < i; j--)
                {
                    ScoresArray[j] = ScoresArray[j - 1];
                }
                ScoresArray[i] = Score.ToString();
                break;
            }

        }
        string ScoreStrings = ScoresArray[0];
        for (int i = 1; i < ScoresArray.Length; i++)
        {
            ScoreStrings = ScoreStrings + "," + ScoresArray[i];

        }
        if (GameController.GameModeAccess == "EASY")
        {

            PlayerPrefs.SetString("EasyHighScores", ScoreStrings);


        }

        else if (GameController.GameModeAccess == "NORMAL")
        {
            PlayerPrefs.SetString("NormalHighScores", ScoreStrings);
        }

        else if (GameController.GameModeAccess == "HARD")
        {
            PlayerPrefs.SetString("HardHighScores", ScoreStrings);
        }

        else
        {
            PlayerPrefs.SetString("ExtremeHighScores", ScoreStrings);
        }



        if (Score > highscore)
        {
            HighScoreText = GameObject.Find("High Score Board");
            HighScorevalue = HighScoreText.GetComponent<Text>();
            HighScorevalue.text = highscore.ToString();

            HighScorevalue.text = "High Score : " + Score.ToString();
            highscore = Score;


            if (GameController.GameModeAccess == "EASY")
            {
                PlayerPrefs.SetInt("HighScore_EASY", Score);

            }
            else if (GameController.GameModeAccess == "NORMAL")
            {
                PlayerPrefs.SetInt("HighScore_NORMAL", Score);
            }
            else if (GameController.GameModeAccess == "HARD")
            {
                PlayerPrefs.SetInt("HighScore_HARD", Score);
            }
            else if (GameController.GameModeAccess == "EXTREME HARD")
            {
                PlayerPrefs.SetInt("HighScore_EXTREMEHARD", Score);
            }
        }
    }
}



