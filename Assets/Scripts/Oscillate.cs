using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate : MonoBehaviour {
    public float turnRate;
    public int tick = 0;
    public int halfPeriod;
    public Direction turnDirection;
    public float angledSpeed;
    public enum Direction {
        LEFT,
        RIGHT
    }
	void Update () {
        if(turnDirection == Direction.LEFT) {
            Turn(turnRate);
        } else if(turnDirection == Direction.RIGHT) {
            Turn(-turnRate);
        }

        tick++;
        if(tick >= halfPeriod) {
            tick = 0;
            ToggleDirection();
        }
	}
    private void Turn(float degrees) {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        float velocityAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        velocity += Helper.PolarOffset2(velocityAngle + 180, angledSpeed);
        //velocityAngle = Mathf.Atan2(velocity.y, velocity.x);
        velocity += Helper.PolarOffset2(velocityAngle + degrees, angledSpeed);
        rb.velocity = velocity;
    }
    private void ToggleDirection() {
        if (turnDirection == Direction.LEFT)
            turnDirection = Direction.RIGHT;
        else if (turnDirection == Direction.RIGHT)
            turnDirection = Direction.LEFT;
    }
}
