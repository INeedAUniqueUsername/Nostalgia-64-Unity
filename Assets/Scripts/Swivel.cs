using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swivel : MonoBehaviour {
    public float turnSpeed;
    public float center;
    public float maxLeft;
    public float maxRight;
    float getAngleDiffRight() {
        return modDegrees(center - transform.localEulerAngles.z);
    }
    float getAngleDiffLeft() {
        return modDegrees(transform.localEulerAngles.z - center);
    }
    static float modDegrees(float degrees) {
        float result = degrees;
        while(result < 0) {
            result += 360;
        }
        while(result > 360) {
            result -= 360;
        }
        return result;
    }
    //maxTurn is the amount that we want to turn (in case our turnSpeed is high)
	void TurnLeft(float maxTurn) {
        float diffLeft = getAngleDiffLeft();
        float diffRight = getAngleDiffRight();
        print("Left Difference: " + diffLeft);
        print("Right Difference: " + diffRight);
        if (diffLeft < maxLeft+1) {
            float remainingLeft = maxLeft - diffLeft;                   //The degrees we can turn left until we must stop turning
            float turn = Mathf.Min(maxTurn, remainingLeft, turnSpeed);
            print("Turning Left: " + turn + " degrees");
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + turn);
        } else if(diffLeft > maxLeft && diffRight <= maxRight+1) {
            //Check if we are angled to the right
            float remainingLeft = maxLeft + diffRight;
            float turn = Mathf.Min(maxTurn, remainingLeft, turnSpeed);
            print("Turning Left: " + turn + " degrees");
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + turn);
        } else {
            print("Cannot turn left");
        }
    }
    //maxTurn is the amount that we want to turn (in case our turnSpeed is high)
    void TurnRight(float maxTurn) {
        float diffLeft = getAngleDiffLeft();
        float diffRight = getAngleDiffRight();
        print("Left Difference: " + diffLeft);
        print("Right Difference: " + diffRight);
        if (diffRight < maxRight + 1) {
            float remainingRight = maxRight - diffRight;                   //The degrees we can turn left until we must stop turning
            float turn = Mathf.Min(maxTurn, remainingRight, turnSpeed);
            print("Turning Right: " + turn + " degrees");
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z - turn);
        } else if (diffRight > maxRight && diffLeft <= maxLeft+1) {
            //Check if we are angled to the right
            float remainingRight = maxRight + diffLeft;
            float turn = Mathf.Min(maxTurn, remainingRight, turnSpeed);
            print("Turning Right: " + turn + " degrees");
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z - turn);
        } else {
            print("Cannot turn right");
        }
    }
}
