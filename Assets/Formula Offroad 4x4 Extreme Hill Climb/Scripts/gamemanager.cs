using UnityEngine;

public class gamemanager : MonoBehaviour
{


    public int target = 30;         //for FBS

    public static GameState gameState;
    public static GameObject CurrentCar;
    public static int ReloadValue = 0;
    public static bool SoundIsOn = true;
    public static float MusicSoundRise = 1f;
    public static string GameModeAccessSettingUp;
    public static int carSpeed;
    public static string[] EasyArray = new string[10];
    public static string[] NormalArray = new string[10];
    public static string[] HardArray = new string[10];
    public static string[] ExtremeArray = new string[10];

    // Use this for initialization

    void Start()
    {

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;    //for FBS



        SoundIsOn = System.Convert.ToBoolean(PlayerPrefs.GetInt("SoundSet"));

        MusicSoundRise = PlayerPrefs.GetFloat("MusicSet");



        DontDestroyOnLoad(this);   //this=gameobject   
    }

    void Update()
    {

        if (target != Application.targetFrameRate)
        {
            Application.targetFrameRate = target;
        }
    }

    public enum GameState
    {
        empty,
        playing,
        paused,
        Gameover
    }


}
