using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeAccessScript : MonoBehaviour {

    private string mode;
    public void SelectedLevel()
    {
        mode = gameObject.name;
        gamemanager.GameModeAccessSettingUp = mode;
        SceneManager.LoadScene(2);
    }

    public void CarSpeedChanger(int carspeed)
    {
        gamemanager.carSpeed = carspeed;
    }
}
