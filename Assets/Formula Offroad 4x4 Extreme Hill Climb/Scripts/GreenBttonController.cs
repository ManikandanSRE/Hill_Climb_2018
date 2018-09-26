using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GreenBttonController : MonoBehaviour
{
    ScoreBoardManager boardManager;

    public Button green;
    public SpriteRenderer FrontRing;//change color at run time...
    public SpriteRenderer BackRing;
    public GameObject FrontTyre;
    public GameObject BackTyre;
    public GameObject BRing;
    public GameObject Fring;


    public Text InfoText;
    public GameObject gameOverPanel;
    public static bool Buttonpressed;
    //public static bool isGameover;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(delayStart());
    }

    IEnumerator delayStart()
    {
        yield return new WaitForSeconds(1f);

        FrontTyre = GameObject.Find("FrontWheel");
        BackTyre = GameObject.Find("BackWheel");
        BRing = GameObject.Find("BackRing");
        Fring = GameObject.Find("FrontRing");

        BackRing = BRing.GetComponent<SpriteRenderer>();
        FrontRing = Fring.GetComponent<SpriteRenderer>();


        boardManager = new ScoreBoardManager();
        Buttonpressed = false;

        ScoreBoardManager.GoldCoins = 0;
        //isGameover = false;
        green.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TaskOnClick()
    {
        if (triggerdetection.CollusionStatus == "GreenRing")
        {
            boardManager.GoldCoinAccess();

            Buttonpressed = true;
            Destroy(triggerdetection.TriggeredGameObject);
            Buttonpressed = false;
            if (Random.Range(0, 100) > 50)
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
            Buttonpressed = true;
            Destroy(triggerdetection.TriggeredGameObject);
            Buttonpressed = false;

        }
        else if (triggerdetection.CollusionStatus == "none")
        {
           
           
            gameOverPanel.SetActive(true);
            gamemanager.gameState = gamemanager.GameState.Gameover;
            boardManager.SetHighScore();
           // isGameover = true;

        }
        else if (triggerdetection.CollusionStatus == "wrongButton")
        {
            
            gamemanager.gameState = gamemanager.GameState.Gameover;
            gameOverPanel.SetActive(true);
            boardManager.SetHighScore();
           // isGameover = true;
        }
        else if (triggerdetection.CollusionStatus == "RedRing")
        {
            gamemanager.gameState = gamemanager.GameState.Gameover;
            gameOverPanel.SetActive(true);
            boardManager.SetHighScore();
           // isGameover = true;
        }
        triggerdetection.CollusionStatus = "none";
    }
}
