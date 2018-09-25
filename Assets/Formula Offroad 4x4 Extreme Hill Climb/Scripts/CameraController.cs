using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [Header("Background")]
    public Image BackroundImageLoader;
    public List<Sprite> BackgroundSprites;

    public static GameObject GameOverPanel;

    public GameObject player;
    public Transform trans;

    public List<GameObject> ListBG1;
      
    public float BG1Speed;
    
    public GameObject emptyGameObject;

    public static bool isalive = false;
   
    public List<GameObject> CarPrefabs = new List<GameObject>();


   private void Start()
    {

        Debug.Log(PlayerPrefs.GetInt("selectedMap"));

        GameOverPanel = GameObject.Find("GameOverPanel");
        GameOverPanel.SetActive(false);      
        gamemanager.CurrentCar = CarPrefabs[PlayerPrefs.GetInt("selectedCar")];
        GameObject NewCar = Instantiate(gamemanager.CurrentCar, trans.position, trans.rotation, player.transform) as GameObject;
       
        BackroundImageLoader.sprite = BackgroundSprites[PlayerPrefs.GetInt("selectedMap")];
               
        Vector3 temp = new Vector3(player.transform.position.x + 2f, this.transform.position.y, this.transform.position.z);
        this.transform.position = temp;       
    }    
    void Update()
    {       
        if (isalive)
        {
            if (player != null)
            {
                GameObject Cars = GameObject.FindGameObjectWithTag("Car");              
                Vector3 temp = new Vector3(Cars.transform.position.x + 2, this.transform.position.y, this.transform.position.z);
                this.transform.position = temp;

            }
        }
    }



}
