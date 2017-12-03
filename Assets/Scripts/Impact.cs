using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour, IDamage {
	public float force;
	public float speedScale;
	public void Damage(GameObject other) {
		Rigidbody2D rb_other = other.GetComponent<Rigidbody2D>();
		if(rb_other) {
			Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
			float speed = velocity.magnitude;
			Vector2 normal = velocity.normalized;
			Vector2 force_vector = (normal * speed * speedScale) + (normal * force);
			Vector2 pos_impact = other.GetComponent<Collider2D>().bounds.ClosestPoint(GetComponent<Collider2D>().bounds.center);
			rb_other.AddForceAtPosition(force_vector, pos_impact);
		}
	}
}
