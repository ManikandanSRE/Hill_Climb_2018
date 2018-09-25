using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pasueButton : MonoBehaviour
{

    public GameObject camera;
    AudioSource audio;



    public bool Paused;
    public Button PlayorPauseButton;
    public Sprite pauseImage;
    public Sprite playImage;

    
    

    // Use this for initialization
    void Start()
    {


        audio =camera. GetComponent<AudioSource>();
        if (gamemanager.SoundIsOn)
        {
            audio.Play();

        }
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
            //pause the game
            PlayorPauseButton.image.sprite = playImage;
            PlayorPauseButton.image.preserveAspect = true;
            Time.timeScale = 0;
            gamemanager.gameState = gamemanager.GameState.paused;
            if (gamemanager.SoundIsOn&& gamemanager.gameState== gamemanager.GameState.paused)
            {
                audio.Pause();

            }



        }
        else if (!Paused)
        {
            //resumes the game
            PlayorPauseButton.image.sprite = pauseImage;

            PlayorPauseButton.image.preserveAspect = true;
            Time.timeScale = 1;
            gamemanager.gameState = gamemanager.GameState.playing;
            if (gamemanager.SoundIsOn && gamemanager.gameState == gamemanager.GameState.playing)
            {
                audio.Play();

            }
        }
    }

    
}
