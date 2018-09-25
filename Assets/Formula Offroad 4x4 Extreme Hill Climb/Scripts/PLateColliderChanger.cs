using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLateColliderChanger : MonoBehaviour
{
    BoxCollider2D boxCollider;
  
    // Use this for initialization
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        
        boxCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "TerrainHil")
        {

           // StartCoroutine(placePlate(col));
        }

    }
    void OnCollisionStay2D(Collision2D col)
    {
        
    }

    private IEnumerator placePlate(Collision2D col)
    {
        yield return new WaitForSeconds(0f);
        BoxCollider2D boxcolltemp = gameObject.AddComponent<BoxCollider2D>();
        boxcolltemp.isTrigger = true;
        
    }
}
