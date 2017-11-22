using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexSpiral : MonoBehaviour {
    public float direction;
    public float turnRate;
    public float angledSpeed;
	// Use this for initialization
	void Start () {
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        direction = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
	}
	void Update () {
        direction += turnRate;
        float z = transform.eulerAngles.z;
        //Round to the nearest 60 degree interval according to our facing
        TurnTo(z + Mathf.RoundToInt((direction - z) / 60) * 60);
	}
    void Turn(float degrees) {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        float velocityAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        velocity += Helper.PolarOffset2(velocityAngle + 180, angledSpeed);
        velocity += Helper.PolarOffset2(velocityAngle + degrees, angledSpeed);
        rb.velocity = velocity;
    }
    void TurnTo(float degrees) {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        float velocityAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        velocity += Helper.PolarOffset2(velocityAngle + 180, angledSpeed);
        velocity += Helper.PolarOffset2(degrees, angledSpeed);
        rb.velocity = velocity;
    }
}
