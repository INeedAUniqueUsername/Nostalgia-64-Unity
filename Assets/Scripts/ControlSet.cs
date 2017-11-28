using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Control {
    public KeyCode key;
    public GameObject action;
}
public class ControlSet : MonoBehaviour {
    public Control[] controls;
}