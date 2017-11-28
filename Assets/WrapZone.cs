using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapZone : MonoBehaviour {
	public const int WRAP_CLONE_LAYER = 8;
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
			WrapCloneTracker tracker = col.gameObject.GetComponent<WrapCloneTracker>();
			if(tracker == null) {
				tracker = col.gameObject.AddComponent<WrapCloneTracker>();
			}
			tracker.EnterZone(GetComponent<BoxCollider2D>().size);
			hit.Add(col);
		}
	}
	void OnTriggerExit2D(Collider2D col) {
		WrapCloneTracker tracker = col.gameObject.GetComponent<WrapCloneTracker>();
		if(tracker != null) {
			tracker.ExitZone();
		}
		hit.Remove(col);
		if(col.transform.position.x < transform.position.x - triggerDimensions.x/2) {
			col.gameObject.transform.position += new Vector3(triggerDimensions.x, 0);
		} else if(col.transform.position.x > transform.position.x + triggerDimensions.y/2) {
			col.gameObject.transform.position += new Vector3(-triggerDimensions.x, 0);
		}
		if(col.transform.position.y < transform.position.y - triggerDimensions.y/2) {
			col.gameObject.transform.position += new Vector3(0, triggerDimensions.y);
		} else if(col.transform.position.y > transform.position.y + triggerDimensions.y/2) {
			col.gameObject.transform.position += new Vector3(0, -triggerDimensions.y);
		}
	}
}
class WrapCloneTracker : MonoBehaviour {
	GameObject	upLeft,		up,			upRight,
				left,					right,
				downLeft,	down,		downRight;
	public void EnterZone(Vector2 dimensions) {
		upLeft =	Clone(new Vector2(-dimensions.x,	dimensions.y));
		up = 		Clone(new Vector2(0,				dimensions.y));
		upRight =	Clone(new Vector2(dimensions.x,		dimensions.y));
		
		left =		Clone(new Vector2(-dimensions.x,	0));
		right = 	Clone(new Vector2(dimensions.x,		0));

		downLeft =	Clone(new Vector2(-dimensions.x,	-dimensions.y));
		down =		Clone(new Vector2(0,				-dimensions.y));
		downRight = Clone(new Vector2(dimensions.x,		-dimensions.y));
	}
	GameObject Clone(Vector2 offset) {
		GameObject clone = Instantiate(gameObject);
		//clone.layer = WrapZone.WRAP_CLONE_LAYER;
		Helper.SetLayer(clone.transform, WrapZone.WRAP_CLONE_LAYER);
		foreach(MonoBehaviour mb in clone.GetComponents<MonoBehaviour>()) {
			mb.enabled = false;
		}
		WrapClone wrap = clone.AddComponent<WrapClone>();
		wrap.parent = gameObject;
		wrap.offset = offset;
		return clone;
	}
	
	public void ExitZone() {
		GameObject[] clones = {
				upLeft,		up,			upRight,
				left,					right,
				downLeft,	down,		downRight,
		};
		foreach(GameObject clone in clones) {
			Destroy(clone);
		}
		this.enabled = false;
	}
}
class WrapClone : MonoBehaviour {
	public GameObject parent;
	public Vector3 offset;
	void Update() {
		transform.eulerAngles = parent.transform.eulerAngles;
		transform.position = parent.transform.position + offset;
	}
}