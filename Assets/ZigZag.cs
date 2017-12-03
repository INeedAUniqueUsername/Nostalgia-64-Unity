using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZag : MonoBehaviour {
    public int tick = 0;
	public int turnAngle;
    public int turnInterval;
    public Direction turnDirection;
    public float angledSpeed;
	void Update () {
        tick++;
        if(tick >= turnInterval) {
            tick = 0;
            ToggleDirection();
			if(turnDirection == Direction.LEFT) {
				Turn(turnAngle);
			} else if(turnDirection == Direction.RIGHT) {
				Turn(-turnAngle);
			}
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
		transform.eulerAngles = new Vector3(0, 0, velocityAngle + 90);
    }
    private void ToggleDirection() {
        if (turnDirection == Direction.LEFT)
            turnDirection = Direction.RIGHT;
        else if (turnDirection == Direction.RIGHT)
            turnDirection = Direction.LEFT;
    }
}
