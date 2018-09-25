using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainmenuAccess : MonoBehaviour
{

    public GameObject termspanel;


    void Start()
    {
        if (!PlayerPrefs.HasKey("termspanel"))
        {
            termspanel.SetActive(true);
        }
        else
        {
            termspanel.SetActive(false);
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

  //public void playgame(string ClickforMode)
  //{
  //    //Application.LoadLevel(ClickforMode);
  //    SceneManager.LoadScene(ClickforMode);
  //
  //}

    public void Quit()
    {
        Application.Quit();
        Debug.Log("yes your exit now");
    }

    public void LikeButton()
    {
        Application.OpenURL("https://play.google.com/store/search?q=steamroll%20east&c=apps");
    }

    public void TermsCondition()
    {
        Application.OpenURL("https://www.cargoramp.com/terms-of-service");
    }
    public void PrivacyPolicy()
    {
        Application.OpenURL("https://www.cargoramp.com/privacy-policy");
    }

   //public void LoadWebsite(string value)
   //{
   //    Application.OpenURL(value);
   //}
}
