using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tractor : MonoBehaviour, IDamage {
    public float force;
    public void Damage(GameObject other) {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null) {
            print("Tractor Damage");
            Vector2 velocity = rb.velocity;
            rb.AddForce(Helper.PolarOffset2(transform.eulerAngles.z + 180, force));
        } else {
            print("Tractor hit does not have Rigidbody2D");
        }
    }
    void Destroy() {
        print("Tractor Destroyed");
    }
}
