using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTerrainGenerating : MonoBehaviour
{

    public GameObject[] Terrain;
    public Transform TerrainPathHandler;
    public static float distance = 0f;
    float timer = 0.5f;

  

  


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

        if (gamemanager.gameState == gamemanager.GameState.playing)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {

                DynamicTerrainCreating();

            }
        }
    }

    public void DynamicTerrainCreating()
    {
        TerrainPathHandler.transform.position = new Vector2(TerrainPathHandler.transform.position.x + distance, TerrainPathHandler.transform.position.y);
        
       
            int randomIndex = Random.Range(0, 6) + (PlayerPrefs.GetInt("selectedMap") * 7);  //incase we  need empty add(0,6)
            GameObject gb = Instantiate(Terrain[randomIndex], TerrainPathHandler.transform.position, Quaternion.identity) as GameObject;
        
        timer = 0.5f;
        distance = 25.35f;

    }
}
