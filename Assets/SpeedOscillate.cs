using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedOscillate : MonoBehaviour {
	public float angledSpeed;
	public float period;
	private float time;
	void Update () {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		float currentfactor = Mathf.Cos(2 * time * Mathf.PI/period);
		float currentAngledSpeed = angledSpeed * currentfactor;
		rb.velocity += Helper.PolarOffset2(transform.eulerAngles.z + 180, currentAngledSpeed);
		time++;
		if(time > period) {
			time %= period;
		}
		float nextFactor = Mathf.Cos(2 * time * Mathf.PI/period);
		print("Factor: " + nextFactor);
		float nextAngledSpeed = angledSpeed * nextFactor;
		rb.velocity += Helper.PolarOffset2(transform.eulerAngles.z, nextAngledSpeed);
	}
}
