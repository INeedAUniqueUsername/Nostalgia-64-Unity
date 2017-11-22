using UnityEngine;
using System;
using System.Collections.Generic;

public static class Helper {
    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        //http://answers.unity3d.com/questions/532297/rotate-a-vector-around-a-certain-point.html
        return Quaternion.Euler(angles) * (point - pivot) + pivot;
    }
    public static Vector3 RotatePointAroundOrigin(Vector3 point, Vector3 angles)
    {
        //http://answers.unity3d.com/questions/532297/rotate-a-vector-around-a-certain-point.html
        return Quaternion.Euler(angles) * point;
    }
    public static Vector2 PolarOffset2(float angle, float distance) {
        return new Vector2(Mathf.Cos(angle*Mathf.Deg2Rad) * distance, Mathf.Sin(angle*Mathf.Deg2Rad)*distance);
    }
    public static Vector3 PolarOffset3(float angle, float distance) {
        Vector2 v = PolarOffset2(angle, distance);
        return new Vector3(v.x, v.y);
    }
    public static bool isRelated(Transform parent, Transform obj) {
        Transform objParent = obj;
        do {
            if (objParent == parent) {
                return true;
            }
            objParent = objParent.parent;
        } while (objParent);
        return false;
    }
    public static Transform getRootParent(Transform obj) {
        Transform parent = obj;
        Transform nextParent = parent.parent;
        while(nextParent) {
            parent = nextParent;
            nextParent = parent.parent;
        }
        return parent;
    }
    public static T InitializeComponent<T>(GameObject obj) {
        if (obj == null) {
            throw new Exception("Invalid Component object");
        }
        T result = obj.GetComponent<T>();
        if (result == null) {
            throw new Exception("Invalid Component instance");
        }
        return result;
    }
    public static List<T> InitializeComponent<T>(List<GameObject> objList) {
        List<T> result = new List<T>(objList.Count);
        for (int i = 0; i < objList.Count; i++) {
            GameObject obj = objList[i];
            if(obj == null) {
                throw new Exception("Invalid Component object");
            }
            T component = obj.GetComponent<T>();
            if(component == null) {
                throw new Exception("Invalid Component instance");
            }
            result.Add(component);
        }
        return result;
    }
    public static void TurnTo(GameObject obj, float degrees, float angledSpeed) {
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        float velocityAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        velocity += Helper.PolarOffset2(velocityAngle + 180, angledSpeed);
        velocity += Helper.PolarOffset2(degrees, angledSpeed);
        rb.velocity = velocity;
    }
    public static void DrawHexagon(Vector3 center, float rotation, float radius) {
        Vector3 previous = center + PolarOffset3(rotation, radius);
        for(int i = 1; i < 7; i ++) {
            float angle = rotation + i * 60;
            Vector3 point = center + PolarOffset3(angle, radius);
            Gizmos.DrawLine(previous, point);
            previous = point;
        }
    }
}