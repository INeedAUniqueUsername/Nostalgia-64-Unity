using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiFollower : MonoBehaviour {

	public List<Transform> targets;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 center = Vector2.zero;
		int count = targets.Count;
		for(int i = 0; i < count; i++) {
			center += targets[i].position;
		}
		center /= count;
		
		Vector3 dest = new Vector3(center.x, center.y, transform.position.z);
		transform.position += (dest - transform.position)/10;
		return;

		//https://answers.unity.com/answers/230205/view.html
		Camera c = GetComponent<Camera>();
		float height = 2f * c.orthographicSize;
 		float width = height * c.aspect;

		Vector2 pos = transform.position;

		for(int i = 0; i < count; i++) {
			Vector2 pos_target = targets[i].position;
			height = Mathf.Max(height, Mathf.Abs(pos.y - pos_target.y));
			width = Mathf.Max(width, Mathf.Abs(pos.x - pos_target.x));
		}

		float height2 = width / c.aspect;
	}
}
