using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayTImeCheck : MonoBehaviour {
    public Text Text;
    public int time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Text.text=Time.unscaledDeltaTime.ToString();
	}
    public void StopGame()
    {
        StartCoroutine(waittime(time));
       

    }

    private IEnumerator waittime(int value)
    {
        Time.timeScale = 0;
       
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1;
    }
}
