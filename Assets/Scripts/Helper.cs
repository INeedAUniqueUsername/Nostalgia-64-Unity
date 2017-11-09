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
    public static Vector3 PolarOffset(float angle, float distance) {
        return new Vector3(Mathf.Cos(angle*Mathf.Deg2Rad) * distance, Mathf.Sin(angle*Mathf.Deg2Rad)*distance);
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
    public static System.Collections.Generic.List<T> InitializeComponent<T>(List<GameObject> objList) {
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
}