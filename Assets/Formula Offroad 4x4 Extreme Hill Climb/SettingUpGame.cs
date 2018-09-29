using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUpGame : MonoBehaviour
{
    [Header("Terms and Conditions")]
    public GameObject termspanel;



    [Header("Score")]
    public Text GoldCoinInMainPanel;

    public Text GoldCoinInShopPanel;

    public Text EasyHighScore;
    public Text NormalHighScore;
    public Text HardHighScore;
    public Text ExtremeHighScore;




    [Header("LeaderBoard")]
    public Text EasyHighScoreText;
    public Text NormalHighScoreText;
    public Text HardHighScoreText;
    public Text ExtremeHighScoreText;


    [Header("Top10 Score")]

    public List<Text> Top10HighScores = new List<Text>();

    // Use this for initialization


    private void Awake()

    {
        PlayerPrefs.DeleteAll();
        resetPlayerPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        EasyHighScoreText.text = PlayerPrefs.GetInt("HighScore_EASY").ToString();
        NormalHighScoreText.text = PlayerPrefs.GetInt("HighScore_NORMAL").ToString();
        HardHighScoreText.text = PlayerPrefs.GetInt("HighScore_HARD").ToString();
        ExtremeHighScoreText.text = PlayerPrefs.GetInt("HighScore_EXTREMEHARD").ToString();

        GoldCoinInMainPanel.text = "Gold Coin : " + PlayerPrefs.GetInt("Goldcoin_Godown");
        GoldCoinInShopPanel.text = "Gold Coin : " + PlayerPrefs.GetInt("Goldcoin_Godown");

        EasyHighScore.text = "HighScore \n " + PlayerPrefs.GetInt("HighScore_EASY");
        NormalHighScore.text = "HighScore\n " + PlayerPrefs.GetInt("HighScore_NORMAL");
        HardHighScore.text = "HighScore \n " + PlayerPrefs.GetInt("HighScore_HARD");
        ExtremeHighScore.text = "HighScore \n " + PlayerPrefs.GetInt("HighScore_EXTREMEHARD");
    }

    public void resetPlayerPrefs()
    {

        if (!PlayerPrefs.HasKey("EasyHighScores") && !PlayerPrefs.HasKey("NormalHighScores") && !PlayerPrefs.HasKey("HardHighScores") && !PlayerPrefs.HasKey("ExtremeHighScores"))
        {
            PlayerPrefs.SetString("EasyHighScores", "0,0,0,0,0,0,0,0,0,0");
            PlayerPrefs.SetString("NormalHighScores", "0,0,0,0,0,0,0,0,0,0");
            PlayerPrefs.SetString("HardHighScores", "0,0,0,0,0,0,0,0,0,0");
            PlayerPrefs.SetString("ExtremeHighScores", "0,0,0,0,0,0,0,0,0,0");
        }



        // //MapsList reset
        // if (!PlayerPrefs.HasKey("T1"))           //maps reset       
        // {
        //     PlayerPrefs.SetInt("T1", 0);
        // }
        // if (!PlayerPrefs.HasKey("T2"))
        // {
        //     PlayerPrefs.SetInt("T2", 0);
        // }
        // if (!PlayerPrefs.HasKey("T3"))
        // {
        //     PlayerPrefs.SetInt("T3", 0);
        // }
        // if (!PlayerPrefs.HasKey("T4"))
        // {
        //     PlayerPrefs.SetInt("T4", 0);
        // }
        // if (!PlayerPrefs.HasKey("T5"))
        // {
        //     PlayerPrefs.SetInt("T5", 0);
        // }
        // if (!PlayerPrefs.HasKey("T6"))
        // {
        //     PlayerPrefs.SetInt("T6", 0);
        // }


        if (!PlayerPrefs.HasKey("Goldcoin_Godown"))                 //shopGold Reset       
        {
            PlayerPrefs.SetInt("Goldcoin_Godown", 100000);
        }

        //PlayerPrefs.SetInt("Goldcoin_Godown", 0);    //for reseting goldgudown value
        if (!PlayerPrefs.HasKey("termspanel"))
        {
            termspanel.SetActive(true);
        }
        else
        {
            termspanel.SetActive(false);
        }

        if (!PlayerPrefs.HasKey("HighScore_EASY"))                    //highscore reset
        {
            PlayerPrefs.SetInt("HighScore_EASY", 0);
        }
        if (!PlayerPrefs.HasKey("HighScore_NORMAL"))
        {
            PlayerPrefs.SetInt("HighScore_NORMAL", 0);
        }
        if (!PlayerPrefs.HasKey("HighScore_HARD"))
        {
            PlayerPrefs.SetInt("HighScore_HARD", 0);
        }
        if (!PlayerPrefs.HasKey("HighScore_EXTREMEHARD"))
        {
            PlayerPrefs.SetInt("HighScore_EXTREMEHARD", 0);
        }


        //  if (!PlayerPrefs.HasKey("MOON"))
        //  {
        //      PlayerPrefs.SetInt("MOON", 1);
        //  }
        //
        //  if (!PlayerPrefs.HasKey("Dessert_BG"))
        //  {
        //      PlayerPrefs.SetInt("Dessert_BG", 1);
        //  }


        if (!PlayerPrefs.HasKey("selectedCar"))
        {
            PlayerPrefs.SetInt("selectedCar", 0);
        }

        if (!PlayerPrefs.HasKey("selectedMap"))
        {
            PlayerPrefs.SetInt("selectedMap", 0);
        }
    }

    public void GetHighScoreValues(string LevelName)
    {

        switch (LevelName)
        {
            case "Easy":
                gamemanager.EasyArray = PlayerPrefs.GetString("EasyHighScores").Split(',');



                for (int i = 0; i < gamemanager.EasyArray.Length; i++)
                {
                    Top10HighScores[i].text = gamemanager.EasyArray[i];
                }

                break;
            case "Normal":

                gamemanager.NormalArray = PlayerPrefs.GetString("NormalHighScores").Split(',');
                for (int i = 0; i < gamemanager.NormalArray.Length; i++)
                {
                    Top10HighScores[i].text = gamemanager.NormalArray[i];
                }
                break;
            case "Hard":

                gamemanager.HardArray = PlayerPrefs.GetString("HardHighScores").Split(',');


                for (int i = 0; i < gamemanager.HardArray.Length; i++)
                {
                    Top10HighScores[i].text = gamemanager.HardArray[i];
                }

                break;
            case "Extreme":

                gamemanager.ExtremeArray = PlayerPrefs.GetString("ExtremeHighScores").Split(',');
                for (int i = 0; i < gamemanager.ExtremeArray.Length; i++)
                {
                    Top10HighScores[i].text = gamemanager.ExtremeArray[i];
                }

                break;
        }
    }


    public void AcceptPressed()
    {
        PlayerPrefs.SetInt("termspanel", 1);
        termspanel.SetActive(false);
    }
    public void DeclinePressed()
    {
        Application.Quit();
    }


    public void Quit()
    {
        Application.Quit();
        Debug.Log("yes your exit now");
    }


    public void UrlOpener(string url)
    {
        Application.OpenURL(url);
    }
}
