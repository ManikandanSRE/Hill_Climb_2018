using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDestroyed : MonoBehaviour {

    public GameObject TerrainDestructor;
	// Use this for initialization
	void Start () {
        TerrainDestructor = GameObject.Find("TerrainDestructorPoint");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < TerrainDestructor.transform.position.x)
        {
            Destroy(gameObject);
        }
	}
}
