using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soundcheck : MonoBehaviour {
    AudioSource audio;
   


	// Use this for initialization
	void Start () {
        
        audio = GetComponent<AudioSource>();
        if (gamemanager.SoundIsOn)
        {
            audio.Play();

        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
