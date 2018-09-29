using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
public class Timer : MonoBehaviour
{
    //  public int timeLeft = 5;
      public Text countdownText;



    public void Stopplay()
    {
        
        StartCoroutine("timeing");
    }

    float Starttime = 0;
    float endtime = 3;

    IEnumerator timeing()
    {
        Time.timeScale = 0;
        
        float s = Time.deltaTime;
        while (endtime > Starttime)
        {
            Starttime = (Starttime + Time.deltaTime);
            Debug.Log("" + (int)Starttime);
            countdownText.text = Starttime.ToString();
            yield return null;
        }
        Time.timeScale = 1;
    } 
    
    // Use this for initialization
 //  void Start()
 //  {
 //      StartCoroutine("LoseTime");
 //  }
 //
 //  // Update is called once per frame
 //  void Update()
 //  {
 //      countdownText.text = ("Time Left = " + timeLeft);
 //
 //      if (timeLeft <= 0)
 //      {
 //          StopCoroutine("LoseTime");
 //          countdownText.text = "Times Up!";
 //      }
 //  }
 //
 //  IEnumerator LoseTime()
 //  {
 //      while (true)
 //      {
 //          yield return new WaitForSeconds(1);
 //          timeLeft--;
 //      }
 //  }
}