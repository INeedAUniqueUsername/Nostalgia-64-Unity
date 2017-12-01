using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWrapZone : MonoBehaviour {
	private List<Collider2D> hit;
	Vector2 triggerDimensions;
	void Start() {
		hit = new List<Collider2D>();
		BoxCollider2D trigger = GetComponent<BoxCollider2D>();
		triggerDimensions = trigger.size;
		Vector2 pos = transform.position;
		foreach(Collider2D other in Physics2D.OverlapAreaAll(pos - triggerDimensions, pos + triggerDimensions, 0)) {
			OnTriggerEnter2D(other);
		}
	}
	void OnTriggerEnter2D(Collider2D col) {
		if(!hit.Contains(col) && col.gameObject.GetComponent<Rigidbody2D>()) {
			hit.Add(col);
		}
	}
	void OnTriggerExit2D(Collider2D col) {
		if(hit.Contains(col)) {
			hit.Remove(col);
		
			if(col.transform.position.x - 1 <= transform.position.x  - triggerDimensions.x/2) {
				col.gameObject.transform.position += new Vector3(triggerDimensions.x, 0);
			} else if(col.transform.position.x + 1 >= transform.position.x + triggerDimensions.y/2) {
				col.gameObject.transform.position += new Vector3(-triggerDimensions.x, 0);
			}
			if(col.transform.position.y - 1 <= transform.position.y - triggerDimensions.y/2) {
				col.gameObject.transform.position += new Vector3(0, triggerDimensions.y);
			} else if(col.transform.position.y + 1 >= transform.position.y + triggerDimensions.y/2) {
				col.gameObject.transform.position += new Vector3(0, -triggerDimensions.y);
			}
		}
	}
}
