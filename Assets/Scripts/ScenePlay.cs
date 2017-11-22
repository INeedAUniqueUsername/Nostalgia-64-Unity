using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePlay : MonoBehaviour {
	void Start () {
        #if UNITY_EDITOR
        UnityEditor.SceneView.FocusWindowIfItsOpen(typeof(UnityEditor.SceneView));
        #endif
    }
}
