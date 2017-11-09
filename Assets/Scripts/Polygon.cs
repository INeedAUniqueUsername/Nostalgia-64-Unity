using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polygon : MonoBehaviour {

    public float lineSize = 0.1f;

    public float apothem;
    public float depth = 0;
    public int sideCount = 3;
    public Transform shape;
    // Use this for initialization
    void Start()
    {
        float sideLength = (2 * apothem * Mathf.Tan(Mathf.Deg2Rad*180.0f / sideCount));
        float interval = 360 / sideCount;
        print("Sides: " + sideCount);
        print("Apothem: " + apothem);
        print("Side Length: " + sideLength);
        print("Interval: " + interval);
        for (float angle = 180; angle < 360+180; angle += interval)
        {
            print("Angle: " + angle);
            Transform side = Instantiate(shape, transform);
            side.localPosition = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * apothem, Mathf.Sin(angle * Mathf.Deg2Rad) * apothem, 0);
            side.eulerAngles = new Vector3(0, 0, angle);
            side.localScale = new Vector3(lineSize, sideLength, depth);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
