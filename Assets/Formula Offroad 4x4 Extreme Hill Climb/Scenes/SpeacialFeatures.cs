using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeacialFeatures : MonoBehaviour
{
    public static bool AutoPilot = false;
    public static bool AutoHarvest = false;


    public void AutoPilotPlates()                            //autopilot
    {
        AutoPilot = true;
        
    }
    public void AutoHarvestGoldCoin()                        //autoharvest
    {
        AutoHarvest = true;
    }

    public void SlowMotionButton()                           //slowmotion
    {
        StartCoroutine("ReduceSpeed");
    }

    public void StopFewSecButtton()                          //stop
    {
        StartCoroutine("StopFewSec");
    }

    IEnumerator ReduceSpeed()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
    }

    IEnumerator StopFewSec()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
    }
}
