using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenuScene : MonoBehaviour {
    public void MenuToStartpanel(string ClickToHome)
    {
        Application.LoadLevel(ClickToHome);
    }

    public void ReloadScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
       
    }

    

   // public void Quit()
   // {
   //     Application.Quit();
   //     Debug.Log("yes your exit now");
   // }
}
