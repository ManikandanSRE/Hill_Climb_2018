﻿using System;
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
<<<<<<< HEAD

    //public Text HighScoreText1;
    //public Text HighScoreText2;
    //public Text HighScoreText3;
    //public Text HighScoreText4;
    //public Text HighScoreText5;
    //public Text HighScoreText6;
    //public Text HighScoreText7;
    //public Text HighScoreText8;
    //public Text HighScoreText9;
    //public Text HighScoreText10;
=======
   
>>>>>>> 7aca0c74f281cf0ad8befc376fc1bec2bd9979c1




    // Use this for initialization
    private void Awake()
    {


       

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
        //if (!PlayerPrefs.HasKey("EasyPanel"))
        //{
        //    PlayerPrefs.SetInt("EasyPanel", 0);
        //}

        //if (!PlayerPrefs.HasKey("NormalPanel"))
        //{
        //    PlayerPrefs.SetInt("NormalPanel", 0);
        //}

        //if (!PlayerPrefs.HasKey("HardPanel"))
        //{
        //    PlayerPrefs.SetInt("HardPanel", 0);
        //}

        //if (!PlayerPrefs.HasKey("ExtremePanel"))
        //{
        //    PlayerPrefs.SetInt("ExtremePanel", 0);
        //}




        if (!PlayerPrefs.HasKey("EasyHighScores") && !PlayerPrefs.HasKey("NormalHighScores") && !PlayerPrefs.HasKey("HardHighScores") && !PlayerPrefs.HasKey("ExtremeHighScores"))
        {
            PlayerPrefs.SetString("EasyHighScores", "0,0,0,0,0,0,0,0,0,0");
            PlayerPrefs.SetString("NormalHighScores", "0,0,0,0,0,0,0,0,0,0");
            PlayerPrefs.SetString("HardHighScores", "0,0,0,0,0,0,0,0,0,0");
            PlayerPrefs.SetString("ExtremeHighScores", "0,0,0,0,0,0,0,0,0,0");           
        }
<<<<<<< HEAD
        //Debug.Log("car1 " + PlayerPrefs.GetInt("car1"));         //carlist reset
        //Debug.Log("car2 " + PlayerPrefs.GetInt("car2"));
        //Debug.Log("car3 " + PlayerPrefs.GetInt("car3"));
        //Debug.Log("car4 " + PlayerPrefs.GetInt("car4"));
        //Debug.Log("car5 " + PlayerPrefs.GetInt("car5"));
        // PlayerPrefs.SetInt("car1", 0);
        // PlayerPrefs.SetInt("car2", 0);
        // PlayerPrefs.SetInt("car3", 0);
        // PlayerPrefs.SetInt("car4", 0);
        // PlayerPrefs.SetInt("car5", 0);
        if (!PlayerPrefs.HasKey("car1"))              //car reset
        {
            //PlayerPrefs.SetString("CarDetails", "[{\"carname\":\"car1\",\"isbought\":\"0\"},{\"carname\":\"car2\",\"isbought\":\"0\"},{\"carname\":\"car3\",\"isbought\":\"0\"},{\"carname\":\"car4\",\"isbought\":\"0\"},{\"carname\":\"car5\",\"isbought\":\"0\"}]");
            PlayerPrefs.SetInt("car1", 0);
        }

        if (!PlayerPrefs.HasKey("car2"))
        {
            PlayerPrefs.SetInt("car2", 0);
        }

        if (!PlayerPrefs.HasKey("car3"))
        {
            PlayerPrefs.SetInt("car3", 0);

        }

        if (!PlayerPrefs.HasKey("car4"))
        {

            PlayerPrefs.SetInt("car4", 0);

        }

        if (!PlayerPrefs.HasKey("car5"))
        {

            PlayerPrefs.SetInt("car5", 0);                              //carlist reset
        }
=======


   
>>>>>>> 7aca0c74f281cf0ad8befc376fc1bec2bd9979c1



        //MapsList reset
        if (!PlayerPrefs.HasKey("T1"))           //maps reset       
        {
            PlayerPrefs.SetInt("T1", 0);
        }
        if (!PlayerPrefs.HasKey("T2"))
        {
            PlayerPrefs.SetInt("T2", 0);
        }
        if (!PlayerPrefs.HasKey("T3"))
        {
            PlayerPrefs.SetInt("T3", 0);
        }
        if (!PlayerPrefs.HasKey("T4"))
        {
            PlayerPrefs.SetInt("T4", 0);
        }
        if (!PlayerPrefs.HasKey("T5"))
        {
            PlayerPrefs.SetInt("T5", 0);
        }
        if (!PlayerPrefs.HasKey("T6"))
        {
            PlayerPrefs.SetInt("T6", 0);
        }


        if (!PlayerPrefs.HasKey("Goldcoin_Godown"))                 //shopGold Reset       
        {
            PlayerPrefs.SetInt("Goldcoin_Godown", 1000);
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


        if (!PlayerPrefs.HasKey("MOON"))
        {
            PlayerPrefs.SetInt("MOON", 1);
        }

        if (!PlayerPrefs.HasKey("Dessert_BG"))
        {
            PlayerPrefs.SetInt("Dessert_BG", 1);
        }


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
