using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D col) {
        GetComponent<IDamageable>().Damage(col.relativeVelocity.magnitude * col.otherRigidbody.mass);
    }
}
