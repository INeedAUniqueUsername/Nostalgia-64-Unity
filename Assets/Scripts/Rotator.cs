using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour, IUsable {
    public float velocity;
    public void Activate() {
        transform.eulerAngles += new Vector3(0, 0, velocity);
    }
}
