using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {
    public float moveAcceleration = 0;
    public float moveDeceleration = 0;
    public float moveSpeed = 0;

    public GameObject target;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        Vector3 pos_target = target.GetComponent<Transform>().position;
        Vector3 pos_diff = new Vector3(pos_target.x - pos.x, pos_target.y - pos.y);
        if (moveAcceleration > 0) {
            float posDisplacement = pos_diff.magnitude;
            float moveDistance = moveSpeed * Time.deltaTime;
            if (posDisplacement > moveDistance) {
                pos_diff = pos_diff.normalized * moveDistance;
            }
            float targetSpeed = target.GetComponent<Rigidbody2D>().velocity.magnitude;
            //float diffSpeed = Mathf.Abs(targetSpeed - moveSpeed);
            //float accel = Mathf.Min(diffSpeed, moveAcceleration);

            float decelDistance = Mathf.Pow(moveSpeed, 2) / (2 * moveDeceleration);

            if (decelDistance < posDisplacement)
                moveSpeed += moveAcceleration;
            else if(decelDistance > posDisplacement)
                moveSpeed -= moveDeceleration;
        }
        
        transform.Translate(translation: pos_diff);
    }
}
