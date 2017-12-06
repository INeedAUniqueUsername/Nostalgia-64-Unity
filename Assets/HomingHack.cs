using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingHack : MonoBehaviour {
	private Transform target;
	public float radius;
	void Update () {
		if(target) {
			Vector2 posDiff = target.position - transform.position;
			Rigidbody2D rb = GetComponent<Rigidbody2D>();
			float speed = rb.velocity.magnitude;
			float angle = Mathf.Atan2(posDiff.y, posDiff.x) * Mathf.Rad2Deg;
			rb.velocity = Helper.PolarOffset2(angle, speed);
		} else {
			Transform owner = null;
			Projectile p = GetComponent<Projectile>();
			if(p) {
				owner = p.owner;
			}
			foreach(Collider2D other in Physics2D.OverlapCircleAll(transform.position, radius)) {
				if(other.gameObject != gameObject && !Helper.isRelated(owner, other.transform)) {
					IUsable usable = other.GetComponent<IUsable>();
					if(usable != null) {
						target = other.gameObject.transform;
						break;
					}
				}
			}
		}
	}
}
