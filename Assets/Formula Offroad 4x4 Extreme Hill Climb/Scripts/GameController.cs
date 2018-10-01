using System.Collections;
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
  public   HingeJoint2D ft;
   public HingeJoint2D bt;
    private float CarSpeed;
    private float force = 0;

    public Sprite[] spritArray;




    private void Awake()
    {
        GameModeAccess = gamemanager.GameModeAccessSettingUp;
    }
    // Use this for initialization
   void Start()
    {
        
        Debug.Log(GameModeAccess);
        FrontWheel = GameObject.Find("FrontWheel");
        BackWheel = GameObject.Find("BackWheel");
        carbodycollider = gameObject.GetComponent<Collider2D>();
        frontwheelcollider = FrontWheel.GetComponent<Collider2D>();
        backwheelcollider = BackWheel.GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        ft = FrontWheel.GetComponent<HingeJoint2D>();
        bt = BackWheel.GetComponent<HingeJoint2D>();
        ft.useMotor = false;
        bt.useMotor = true;
        ///wheeljoint componet used to save inside the BT...true means,when the game start motor automatically on.


        StartCoroutine(delayedAssign());
       // if (GameModeAccess == "EASY")
       // {
           // CarSpeed = gamemanager.carSpeed;
           // JointMotor2D TempFront = ft.motor; /// this 3lines used for fornt wheel motor run;;;       
           // TempFront.motorSpeed = CarSpeed;
           // ft.motor = TempFront;
           //
           // JointMotor2D TempBack = bt.motor; /// this 3-lines used for Back wheel motor run;;;
           // TempBack.motorSpeed = CarSpeed;
           // bt.motor = TempBack;
     // }
     // if (GameModeAccess == "NORMAL")
     // {
     //     CarSpeed = 800f;
     //     JointMotor2D TempFront = ft.motor; /// this 3lines used for fornt wheel motor run;;;       
     //     TempFront.motorSpeed = CarSpeed;
     //     ft.motor = TempFront;
     //
     //     JointMotor2D TempBack = bt.motor; /// this 3-lines used for Back wheel motor run;;;
     //     TempBack.motorSpeed = CarSpeed;
     //     bt.motor = TempBack;
     // }
     // else if (GameModeAccess == "HARD")
     // {
     //     CarSpeed = 1000f;
     //     JointMotor2D TempFront = ft.motor; /// this 3lines used for fornt wheel motor run;;;       
     //     TempFront.motorSpeed = CarSpeed;
     //     ft.motor = TempFront;
     //
     //     JointMotor2D TempBack = bt.motor; /// this 3-lines used for Back wheel motor run;;;
     //     TempBack.motorSpeed = CarSpeed;
     //     bt.motor = TempBack;
     // }
     // else if (GameModeAccess == "EXTREME HARD")
     // {
     //     CarSpeed = 1200f;
     //     JointMotor2D TempFront = ft.motor; /// this 3lines used for fornt wheel motor run;;;       
     //     TempFront.motorSpeed = CarSpeed;
     //     ft.motor = TempFront;
     //
     //     JointMotor2D TempBack = bt.motor; /// this 3-lines used for Back wheel motor run;;;
     //     TempBack.motorSpeed = CarSpeed;
     //     bt.motor = TempBack;
     // }



    }
   IEnumerator delayedAssign()
    {
        yield return new WaitForSeconds(.5f);
        CarSpeed = gamemanager.carSpeed;
        Debug.Log(CarSpeed);
        JointMotor2D TempFront = ft.motor; /// this 3lines used for fornt wheel motor run;;;       
        TempFront.motorSpeed = CarSpeed;
        ft.motor = TempFront;

        JointMotor2D TempBack = bt.motor; /// this 3-lines used for Back wheel motor run;;;
        TempBack.motorSpeed = CarSpeed;
        bt.motor = TempBack;

    }
    void CarEngine()
    {
        if (gamemanager.gameState == gamemanager.GameState.Gameover)
        {
            carbodycollider.isTrigger = true;
            frontwheelcollider.isTrigger = true;
            backwheelcollider.isTrigger = true;
            ft.useMotor = false;
            bt.useMotor = false;
            RotateLeft();
            //gamemanager.gameState = gamemanager.GameState.empty;
            //CameraController.isalive = false;
        }

        


    }
    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        CarEngine();
=======
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
>>>>>>> a8eb7c22f0ac769ec4178419d3988669f1a96a09
    }
    void RotateLeft()
    {
        Time.timeScale = 0;
        //Quaternion theRotation = transform.localRotation;
        //theRotation.z *= 360;
        //transform.localRotation = theRotation;
        ////GreenBttonController.isGameover = false;
        GameModeAccess = "";
    }

    

}

