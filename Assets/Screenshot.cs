using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.P)) {
            ScreenCapture.CaptureScreenshot("png", 1);
        }
	}
}
