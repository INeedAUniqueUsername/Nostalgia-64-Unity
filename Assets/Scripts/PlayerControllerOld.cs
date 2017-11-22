using UnityEngine;
using System;
public class PlayerControllerOld : MonoBehaviour {
    private Control[] controls;
    void Start() {
        controls = GetComponent<ControlSet>().controls;
    }
    void Update() {
        for(int i = 0; i < controls.Length; i++) {
            if(Input.GetKey(controls[i].key)) {
                //print(controls[i].key + " key activated");
                controls[i].action.GetComponent<IUsable>().Activate();
            }
        }
    }
}