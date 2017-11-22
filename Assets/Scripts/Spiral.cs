using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiral : MonoBehaviour {
    public float turnRate;
    public float angledSpeed;
    void Update() {
        Turn(turnRate);
    }
    void Turn(float degrees) {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        float velocityAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        velocity += Helper.PolarOffset2(velocityAngle + 180, angledSpeed);
        velocity += Helper.PolarOffset2(velocityAngle + degrees, angledSpeed);
        rb.velocity = velocity;
    }
}
