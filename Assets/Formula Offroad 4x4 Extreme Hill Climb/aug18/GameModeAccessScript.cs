using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeAccessScript : MonoBehaviour
{
    

    public void SelectedLevel(int carspeed)
    {
        gamemanager.carSpeed = carspeed;
    }

    public void SelectedLevelName(string mode)
    {
        gamemanager.GameModeAccessSettingUp = mode;
        SceneManager.LoadSceneAsync(2);
    }



}
