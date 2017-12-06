using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScaleOscillate : MonoBehaviour {
	public float period;
	private float time;
	void Start() {
		time = 0;
		if(period <= 0) {
			throw new System.Exception("Period cannot be 0");
		}
	}
	void Update() {
		time++;
		if(time > period) {
			time %= period;
		}
		float factor = Mathf.Cos(2 * time * Mathf.PI/period);
		transform.localScale = new Vector3(factor, factor, factor);
	}
}
