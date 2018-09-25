using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTerrainGenerating : MonoBehaviour
{

    public GameObject[] Terrain;
    public Transform TerrainPathHandler;
    public static float distance = 0f;
    float timer = 0.5f;

    public GameObject[] PlatesArray;
    public Transform obj;
    public float distancePlates;

  


    // Use this for initialization
    void Start()
    {
        distance = 0f;

        GameObject gb = Instantiate(Terrain[PlayerPrefs.GetInt("selectedMap") * 7], TerrainPathHandler.transform.position, Quaternion.identity) as GameObject;
        distance = 25.35f;
        //DynamicPlateCreating(3f);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {

            DynamicTerrainCreating();

        }
    }

    public void DynamicTerrainCreating()
    {
        TerrainPathHandler.transform.position = new Vector2(TerrainPathHandler.transform.position.x + distance, TerrainPathHandler.transform.position.y);
        
       
            int randomIndex = Random.Range(0, 6) + (PlayerPrefs.GetInt("selectedMap") * 7);  //incase we  need empty add(0,6)
            GameObject gb = Instantiate(Terrain[randomIndex], TerrainPathHandler.transform.position, Quaternion.identity) as GameObject;
        
        timer = 0.5f;
        distance = 25.35f;
       // DynamicPlateCreating(TerrainPathHandler.transform.position.x -8);

    }


    public void DynamicPlateCreating(float distancePlates)
    {
        distancePlates += Random.Range(1, 4);
        Instantiate(PlatesArray[Random.Range(0, PlatesArray.Length)] as GameObject, new Vector2(distancePlates, obj.transform.position.y), Quaternion.identity);

        distancePlates += Random.Range(2, 5);
        Instantiate(PlatesArray[Random.Range(0, PlatesArray.Length)] as GameObject, new Vector2(distancePlates, obj.transform.position.y), Quaternion.identity);


        distancePlates += Random.Range(2, 5);
        Instantiate(PlatesArray[Random.Range(0, PlatesArray.Length)] as GameObject, new Vector2(distancePlates, obj.transform.position.y), Quaternion.identity);


        //distancePlates += Random.Range(1, 4);
        //Vector2 pos = new Vector2(distancePlates, obj.transform.position.y);
        //pos.y = Terrain.
        //    //activeTerrain.SampleHeight(transform.position);
        //transform.position = pos;



        //Instantiate(PlatesArray[Random.Range(0, PlatesArray.Length)] as GameObject, new Vector2(distancePlates, obj.transform.position.y), Quaternion.identity);
        //distancePlates += Random.Range(2, 5);
        //
        //
        //Instantiate(PlatesArray[Random.Range(0, PlatesArray.Length)] as GameObject, new Vector2(distancePlates, obj.transform.position.y), Quaternion.identity);
        //distancePlates += Random.Range(2, 5);
        //
        //Instantiate(PlatesArray[Random.Range(0, PlatesArray.Length)] as GameObject, new Vector2(distancePlates, obj.transform.position.y), Quaternion.identity);
        //distancePlates += Random.Range(2, 5);

    }
}
