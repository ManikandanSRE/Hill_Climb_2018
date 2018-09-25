using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {
    public GameObject player;
    public float speed = 2.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float interpolation = speed * Time.deltaTime;
        Vector3 postion = this.transform.position;
        postion.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y, interpolation);
        postion.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, interpolation);
        this.transform.position = postion;
    }
}
