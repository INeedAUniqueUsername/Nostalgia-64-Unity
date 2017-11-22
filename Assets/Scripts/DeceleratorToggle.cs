using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeceleratorToggle : Decelerator {
    public bool firing = false;
    public override void Activate() {
        firing = !firing;
    }
    void Update() {
        if (firing)
            Decelerate();
    }
}
