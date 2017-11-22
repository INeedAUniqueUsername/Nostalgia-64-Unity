using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour, IUsable {
    public GameObject obj;
    public float angularAcceleration;
    public float GetPowerUse() { return 0; }
    public void Activate() {
        obj.GetComponent<Rigidbody2D>().angularVelocity += angularAcceleration;
    }
}
