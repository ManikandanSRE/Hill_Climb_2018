using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pasueButton : MonoBehaviour
{
    public bool Paused;
    public Button PlayorPauseButton;
    public Sprite pauseImage;
    public Sprite playImage;

    
    

    // Use this for initialization
    void Start()
    {
        Paused = false;
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PausedController()
    {

        Paused = !Paused;
        if (Paused)
        {
            PlayorPauseButton.image.sprite = playImage;
            PlayorPauseButton.image.preserveAspect = true;
            Time.timeScale = 0;

            
        }
        else if (!Paused)
        {
            PlayorPauseButton.image.sprite = pauseImage;

            PlayorPauseButton.image.preserveAspect = true;
            Time.timeScale = 1;
        }
    }

    
}
