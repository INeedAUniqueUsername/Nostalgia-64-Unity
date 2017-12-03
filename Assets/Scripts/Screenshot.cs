using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour {
	public int multiplier = 1;
	void Update () {
		if(Input.GetKey(KeyCode.P)) {
            ScreenCapture.CaptureScreenshot("capture.png", multiplier);
        }
	}
}
