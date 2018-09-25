using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickForModes : MonoBehaviour {

	public void ClickForModeStart(string SceneName)
    {
        Application.LoadLevel(SceneName);
    }
}
