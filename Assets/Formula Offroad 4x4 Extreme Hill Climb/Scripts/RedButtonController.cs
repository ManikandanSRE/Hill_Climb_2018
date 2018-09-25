using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RedButtonController : MonoBehaviour
{
    ScoreBoardManager boardManager;

    public Button red;
    //public SpriteRenderer GreenRing;//change color at run time...
    //public SpriteRenderer RedRing;
    public GameObject FrontTyre;
    public GameObject BackTyre;

    public GameObject BRing;
    public GameObject Fring;

    public SpriteRenderer FrontRing;//change color at run time...
    public SpriteRenderer BackRing;

    public Text InfoText;

    public GameObject gameOverPanel;

    // Use this for initialization
    void Start()
    {

        StartCoroutine(delayStart());                            //for initialize issue after car...

    }

    IEnumerator delayStart()
    {
        yield return new WaitForSeconds(1f);

        boardManager = new ScoreBoardManager();
        //GreenBttonController.isGameover = false;
        
        ScoreBoardManager.GoldCoins = 0;

        red.onClick.AddListener(TaskOnClick);
        FrontTyre = GameObject.Find("FrontWheel");
        BackTyre = GameObject.Find("BackWheel");
        BRing = GameObject.Find("BackRing");
        Fring = GameObject.Find("FrontRing");

        BackRing = BRing.GetComponent<SpriteRenderer>();
        FrontRing = Fring.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void TaskOnClick()
    {


        if (triggerdetection.CollusionStatus == "RedRing")
        {

            boardManager.GoldCoinAccess();

            //Score.text = "yes it is correct(RED) so you get 1Point";
            GreenBttonController.Buttonpressed = true;
            Destroy(triggerdetection.TriggeredGameObject);
            GreenBttonController.Buttonpressed = false;
            if (Random.Range(0, 100) < 50)
            {

                Sprite temp;
                Sprite temp2;
                string temp1Tag;
                string temp2Tag;

                temp = FrontRing.sprite;
                temp2 = BackRing.sprite;
                temp1Tag = FrontTyre.tag;
                temp2Tag = BackTyre.tag;

                FrontRing.sprite = null;
                BackRing.sprite = null;
                FrontRing.sprite = temp2;
                BackRing.sprite = temp;


                FrontTyre.tag = temp2Tag;
                BackTyre.tag = temp1Tag;


            }


        }
        else if (triggerdetection.CollusionStatus == "GreenCoin" || triggerdetection.CollusionStatus == "RedCoin")
        {
            boardManager.GoldCoinAccess();
            GreenBttonController.Buttonpressed = true;
            Destroy(triggerdetection.TriggeredGameObject);
            GreenBttonController.Buttonpressed = false;

        }
        else if (triggerdetection.CollusionStatus == "none")
        {
            // InfoText.text = "GAME OVER!!!Don't press the button before";
            gameOverPanel.SetActive(true);
            boardManager.SetHighScore();
            //GreenBttonController.isGameover = true;
            gamemanager.gameState = gamemanager.GameState.Gameover;

        }
        else if (triggerdetection.CollusionStatus == "wrongButton")
        {
            gameOverPanel.SetActive(true);
            boardManager.SetHighScore();
           // GreenBttonController.isGameover = true;
            gamemanager.gameState = gamemanager.GameState.Gameover;
            //InfoText.text = "Game over! you pressing wrong button";

        }
        else if (triggerdetection.CollusionStatus == "GreenRing")
        {
            gameOverPanel.SetActive(true);
            boardManager.SetHighScore();
           // GreenBttonController.isGameover = true;
            gamemanager.gameState = gamemanager.GameState.Gameover;
            //InfoText.text = "Game over! you pressing wrong button";

        }

        triggerdetection.CollusionStatus = "none";


    }
}
