﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollQuadBG : MonoBehaviour {

    public float speed = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * speed) % 1, 0f);
    }
}
