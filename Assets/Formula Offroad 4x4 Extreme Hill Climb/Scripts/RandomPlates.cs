using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlates : MonoBehaviour {
    public GameObject[] Plates;
   public Transform obj;
    float distance = 0.5f;
    // Use this for initialization
    void Start () {
        

	}
	
	// Update is called once per frame
	void Update () {

        
    }

    public void DynamicPlateCreating() {
        obj.transform.position = new Vector2(transform.position.x + distance, obj.transform.position.y);
        Instantiate(Plates[Random.Range(0,Plates.Length)] as GameObject, obj.transform.position, Quaternion.identity);
        distance += 5;
    }
    
}
