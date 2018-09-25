using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour {
    public  bool SoundOn;
    public Button OnOffbutton;
    public Sprite OnImage;
    public Sprite OffImage;

    public static bool SoundManager;

   AudioSource audioSource;

   public Scrollbar MusicScroller;    //music

    // Use this for initialization
    void Start () {
        audioSource=GetComponent<AudioSource>();          //sound
        
        if (!gamemanager.SoundIsOn)
        {
            OnOffbutton.image.sprite = OffImage;
        }
        else
            OnOffbutton.image.sprite =  OnImage;


        audioSource.volume = gamemanager.MusicSoundRise;   //music       
        MusicScroller.value = gamemanager.MusicSoundRise;

       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SoundOnOffController()
    {

        
        
        gamemanager.SoundIsOn = !gamemanager.SoundIsOn;
        if (!gamemanager.SoundIsOn)
        {
            OnOffbutton.image.sprite = OffImage;
            OnOffbutton.image.preserveAspect = true;

            PlayerPrefs.SetInt("SoundSet", 0);
            gamemanager.SoundIsOn = false;
        }
        if (gamemanager.SoundIsOn)
        {
            OnOffbutton.image.sprite = OnImage;            
            OnOffbutton.image.preserveAspect = true;
            PlayerPrefs.SetInt("SoundSet", 1);
            gamemanager.SoundIsOn = true;
        }
    }

    public void OnMusicValueChanged()
    {

        PlayerPrefs.SetFloat("MusicSet",MusicScroller.value);
        gamemanager.MusicSoundRise = MusicScroller.value;
        audioSource.volume = gamemanager.MusicSoundRise;
    }
}
