using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static string GameModeAccess;

    //public Camera playerCamera;
    public Rigidbody2D rb;
    public Collider2D carbodycollider;
    public Collider2D frontwheelcollider;
    public Collider2D backwheelcollider;

    public GameObject PlayerPosition;

    public SpriteRenderer GreenRing;//change color at run time...using timer....
    public SpriteRenderer RedRing;

    //Car movement using motor....
    public GameObject FrontWheel;
    public GameObject BackWheel;
    HingeJoint2D ft;
    HingeJoint2D bt;
    private float CarSpeed;
    private float force = 0;

    public Sprite[] spritArray;

    // Use this for initialization
    void Start()
    {
        GameModeAccess = gamemanager.GameModeAccessSettingUp;
       // GameObject[] carBody = GameObject.FindObjectsOfTypeIncludingAssets();
       // Debug.Log("new car : " + carBody);
       //
       // GameObject obj = Instantiate(carBody, PlayerPosition.transform.position, Quaternion.identity);

        FrontWheel = GameObject.Find("FrontWheel");
        BackWheel = GameObject.Find("BackWheel");
        carbodycollider = gameObject.GetComponent<Collider2D>();
        frontwheelcollider = FrontWheel.GetComponent<Collider2D>();
        backwheelcollider = BackWheel.GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        ft = FrontWheel.GetComponent<HingeJoint2D>();
        bt = BackWheel.GetComponent<HingeJoint2D>();
        ft.useMotor = false;
        bt.useMotor = true;///wheeljoint componet used to save inside the BT...true means,when the game start motor automatically on.
    }

    void CarEngine()
    {
        if (GreenBttonController.isGameover)
        {
            carbodycollider.isTrigger = true;
            frontwheelcollider.isTrigger = true;
            backwheelcollider.isTrigger = true;
            ft.useMotor = false;
            bt.useMotor = false;
            RotateLeft();

            CameraController.isalive = false;
        }

     //  //Debug.Log(rb.velocity.x);
     //
     //  if (rb.velocity.x < .5)
     //  {
     //      rb.AddForce(new Vector2(0, 0));
     //  }
     //
     //  else if (rb.velocity.x < 2)
     //  {
     //      rb.AddForce(new Vector2(500, 0));
     //  }
     //  else if (rb.velocity.x < -1)
     //  {
     //      rb.AddForce(new Vector2(800, 0));
     //  }
     //  else
     //  {
     //
     //  }

        // car speed accessed by game mode...

        if (GameModeAccess == "EASY")
        {
            CarSpeed = 650f;
            JointMotor2D TempFront = ft.motor; /// this 3lines used for fornt wheel motor run;;;       
            TempFront.motorSpeed = CarSpeed;
            ft.motor = TempFront;

            JointMotor2D TempBack = bt.motor; /// this 3-lines used for Back wheel motor run;;;
            TempBack.motorSpeed = CarSpeed;
            bt.motor = TempBack;
        }
        if (GameModeAccess == "NORMAL")
        {
            CarSpeed = 800f;
            JointMotor2D TempFront = ft.motor; /// this 3lines used for fornt wheel motor run;;;       
            TempFront.motorSpeed = CarSpeed;
            ft.motor = TempFront;

            JointMotor2D TempBack = bt.motor; /// this 3-lines used for Back wheel motor run;;;
            TempBack.motorSpeed = CarSpeed;
            bt.motor = TempBack;
        }
        else if (GameModeAccess == "HARD")
        {
            CarSpeed = 1000f;
            JointMotor2D TempFront = ft.motor; /// this 3lines used for fornt wheel motor run;;;       
            TempFront.motorSpeed = CarSpeed;
            ft.motor = TempFront;

            JointMotor2D TempBack = bt.motor; /// this 3-lines used for Back wheel motor run;;;
            TempBack.motorSpeed = CarSpeed;
            bt.motor = TempBack;
        }
        else if (GameModeAccess == "EXTREME HARD")
        {
            CarSpeed = 1200f;
            JointMotor2D TempFront = ft.motor; /// this 3lines used for fornt wheel motor run;;;       
            TempFront.motorSpeed = CarSpeed;
            ft.motor = TempFront;

            JointMotor2D TempBack = bt.motor; /// this 3-lines used for Back wheel motor run;;;
            TempBack.motorSpeed = CarSpeed;
            bt.motor = TempBack;
        }
        else
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            CarEngine();
        }
        else
        {
            ft.useMotor = false;
            bt.useMotor = false;
           // bt.breakForce = 1000;
            
        }        
    }
    void RotateLeft()
    {
        Quaternion theRotation = transform.localRotation;
        theRotation.z *= 360;
        transform.localRotation = theRotation;
       GreenBttonController.isGameover = false;
       GameModeAccess = "";
    }

}

