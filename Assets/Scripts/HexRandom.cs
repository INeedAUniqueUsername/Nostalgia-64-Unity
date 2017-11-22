using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexRandom : MonoBehaviour {
    public float direction;
    public float angleRange;
    public float angledSpeed;
    // Use this for initialization
    void Start() {
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        direction = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
    }
    void Update() {
        float nextDirection = direction + Random.Range(-angleRange, angleRange);
        float z = transform.eulerAngles.z;
        Helper.TurnTo(gameObject, z + Mathf.RoundToInt((nextDirection - z) / 60) * 60, angledSpeed);
    }
}
