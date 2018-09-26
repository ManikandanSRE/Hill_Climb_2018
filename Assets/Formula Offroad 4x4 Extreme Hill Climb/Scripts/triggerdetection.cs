using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerdetection : MonoBehaviour
{
    public Text Score;
    public GameObject gameoverpanel;

    public static string CollusionStatus = "none";
    public static GameObject TriggeredGameObject;
    // Use this for initialization
    void Start()
    {
        gameoverpanel = CameraController.GameOverPanel;        
    }

 void OnTriggerEnter2D(Collider2D col)
 {
     if (col.gameObject.tag.Contains("Ring"))                          //for plates
     {
         if (col.gameObject.tag == gameObject.tag)
         {
             CollusionStatus = col.gameObject.tag;
             TriggeredGameObject = col.gameObject;
             
         }
         else
         {
             CollusionStatus = "wrongButton";
         }
     }
     if (col.gameObject.tag.Contains("GoldCoin"))
     {
        
         if (col.gameObject.tag.Contains("Green") == gameObject.tag.Contains("Green")) //for goldcoins
         {
            
             CollusionStatus = "GreenCoin";
             TriggeredGameObject = col.gameObject;
            
         }
         else
         {
             CollusionStatus = "wrongButton";
         }
 
         if (col.gameObject.tag.Contains("Red") == gameObject.tag.Contains("Red"))     //for goldcoins
         {
            
 
             CollusionStatus = "RedCoin";
             TriggeredGameObject = col.gameObject;
            
         }
         else
         {
             CollusionStatus = "wrongButton";
         }
     }
 }
 
 void OnTriggerExit2D(Collider2D col)
 {
     if (col.gameObject.tag.Contains("Ring"))
     {
         CollusionStatus = "none";
     
         if (gameObject.tag == col.gameObject.tag)
         {
             if (!GreenBttonController.Buttonpressed)
             {
                 
                 Debug.Log("Plate Crossed but no button pressed");
                 
                 gamemanager.gameState = gamemanager.GameState.Gameover;
                 new ScoreBoardManager().SetHighScore();
                 gameoverpanel.SetActive(true);
     
             }
         }
     }
 }
}
