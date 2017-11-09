using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle : MonoBehaviour {
    public float width;
    public float height;
    public float depth = 0;

    public float lineSize = 0.1f;

    public Transform shape;
	// Use this for initialization
	void Start () {
        Transform left = Instantiate(shape, transform);
        left.localPosition = new Vector2(-width, 0);
        left.localScale = new Vector3(lineSize, height * 2, depth);

        Transform right = Instantiate(shape, transform);
        right.localPosition = new Vector2(width, 0);
        right.localScale = new Vector3(lineSize, height * 2, depth);

        Transform up = Instantiate(shape, transform);
        up.localPosition = new Vector2(0, height);
        up.localScale = new Vector3(width * 2, lineSize, depth);

        Transform down = Instantiate(shape, transform);
        down.localPosition = new Vector2(0, -height);
        down.localScale = new Vector3(width * 2, lineSize, depth);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
