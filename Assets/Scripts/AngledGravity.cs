using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngledGravity : MonoBehaviour {
    public float acceleration;
    public float width;
    public float height;
    public float angle;
    void Update() {
        float z = transform.eulerAngles.z;
        Collider2D[] objects = Physics2D.OverlapBoxAll(transform.position, new Vector2(height, width), z);
        for(int i = 0; i < objects.Length; i++) {
            Rigidbody2D rb = objects[i].GetComponent<Rigidbody2D>();
            if (rb != null) {
                rb.velocity += Helper.PolarOffset2(angle, acceleration);
            }
        }
    }
    void OnDrawGizmos() {
        float z = transform.eulerAngles.z;
        Vector3 cornerNW = transform.position + Helper.PolarOffset3(z + 90, width / 2) + Helper.PolarOffset3(z, height / 2);
        Vector3 cornerNE = cornerNW + Helper.PolarOffset3(z - 90, width);
        Vector3 cornerSW = cornerNW + Helper.PolarOffset3(z - 180, height);
        Vector3 cornerSE = cornerNE + Helper.PolarOffset3(z + 180, height);
        Gizmos.color = Color.white;
        Gizmos.DrawLine(cornerNW, cornerNE);
        Gizmos.DrawLine(cornerNE, cornerSE);
        Gizmos.DrawLine(cornerSE, cornerSW);
        Gizmos.DrawLine(cornerSW, cornerNW);

        Gizmos.DrawLine(transform.position, transform.position + Helper.PolarOffset3(angle, 10));
    }
}
