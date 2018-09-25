using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToStart : MonoBehaviour {
    public GameObject StartCanvas;
	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void HiddenButtonClick()
    {
        Time.timeScale = 1;
       //CameraController. isalive = true;
        StartCanvas.SetActive(false);
    }
}
