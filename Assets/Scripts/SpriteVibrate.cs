using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteVibrate : MonoBehaviour {
    private Vector3 origin;
    public float radius;
    void Start() {
        print("Sprite Vibrate created");
        origin = transform.position;
    }
    void Update() {
        transform.position = origin + Helper.PolarOffset(Random.value * 360, Random.value * radius);
    }
}
