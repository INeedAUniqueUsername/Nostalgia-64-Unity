using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitVelocity : MonoBehaviour {
    //Centripetal acceleration = (tangent velocity)^2 / radius
    //a = v^2 / r
    //v^2 = a * r
    //v = sqrt(a * r)
    public Transform primary;
    private bool started = false;
    void Start() {
        started = true;
        GetComponent<Rigidbody2D>().velocity += GetInitialVelocity();
    }
    Vector2 GetInitialVelocity() {
        Vector2 pos_diff = transform.position - primary.transform.position;
        float angle = Mathf.Atan2(pos_diff.y, pos_diff.x);
        //Point the angle counterclockwise
        angle += 90;
        Gravity gravity = primary.GetComponent<Gravity>();
        float distance = pos_diff.magnitude;

        //Multiply by 60 in case of time
        float velocity = Mathf.Sqrt(gravity.GetAcceleration(distance) * 60 * distance);
        return Helper.PolarOffset2(angle, velocity);
    }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.white;
        Vector3 position = transform.position;
        Vector3 velocity = GetInitialVelocity();
        if (started) {
            velocity = GetComponent<Rigidbody2D>().velocity;
        }        
        for(int i = 0; i < 100; i++) {
            velocity += primary.GetComponent<Gravity>().GetAccelerationVector(position)*60;
            Vector3 nextPosition = position + velocity;
            Gizmos.DrawLine(position, nextPosition);
            
            position = nextPosition;
        }
    }
}
