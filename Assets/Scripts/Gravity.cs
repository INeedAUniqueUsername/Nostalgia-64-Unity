using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
    public float acceleration;
    public float distanceScale;
    public float maxDistance;
    
    void Update() {
        Collider2D[] affected = Physics2D.OverlapCircleAll(transform.position, maxDistance);
        for(int i = 0; i < affected.Length; i++) {
            if(affected[i].GetComponent<Rigidbody2D>() == null) {
                continue;
            }
            Vector3 pos_diff = transform.position - affected[i].transform.position;
            float accel = acceleration / (pos_diff.sqrMagnitude / (distanceScale * distanceScale));
            affected[i].GetComponent<Rigidbody2D>().velocity += Helper.PolarOffset2(Mathf.Atan2(pos_diff.y, pos_diff.x) * Mathf.Rad2Deg, accel);
        }
    }
    public float GetAcceleration(float distance) {
        return acceleration / ((distance * distance) / (distanceScale * distanceScale));
    }
    public float GetAcceleration(Vector3 position) {
        return acceleration / (((transform.position - position).sqrMagnitude) / (distanceScale * distanceScale));
    }
    public Vector3 GetAccelerationVector(Vector3 position) {
        Vector3 pos_diff = transform.position - position;
        return Helper.PolarOffset3(Mathf.Atan2(pos_diff.y, pos_diff.x) * Mathf.Rad2Deg, GetAcceleration(pos_diff.magnitude));
    }
    void OnDrawGizmosSelected() {
        float distance = 1;
        float ratio;
        do {
            //float accel = acceleration / ((i * i) / (distanceScale * distanceScale));
            float accel = GetAcceleration(distance);
            ratio = accel / acceleration;
            Gizmos.color = new Color(1, 1, 1, ratio);
            Gizmos.DrawWireSphere(transform.position, distance);
            distance *= 1.1f;
        } while (ratio > 0.01);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, distance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
