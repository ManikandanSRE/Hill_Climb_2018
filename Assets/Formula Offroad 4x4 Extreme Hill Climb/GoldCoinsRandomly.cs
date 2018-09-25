using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinsRandomly : MonoBehaviour
{

    CircleCollider2D circleCollider2D;
    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        rb.freezeRotation = false;
        rb.simulated = true;
        circleCollider2D.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Plate");


    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "TerrainHil")  // || (col.gameObject.tag == "Ring")
        {
            StartCoroutine(placePlate(col));
        }

    }

    private IEnumerator placePlate(Collision2D col)
    {
        yield return new WaitForSeconds(0.1f);
        CircleCollider2D Circlecolltemp = gameObject.AddComponent<CircleCollider2D>();
        Circlecolltemp.isTrigger = true;
        Destroy(rb);
        Destroy(circleCollider2D);
        //Debug.Log("I'm in Terrain");
    }

   
}
