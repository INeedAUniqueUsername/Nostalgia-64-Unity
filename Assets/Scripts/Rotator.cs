using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour, IUsable {
    public float angularVelocity;
    public Transform rotatingObject;
    public void Activate() {
        //transform.eulerAngles += new Vector3(0, 0, velocity);
        rotatingObject.GetComponent<Rigidbody2D>().angularVelocity += angularVelocity;
    }
}
