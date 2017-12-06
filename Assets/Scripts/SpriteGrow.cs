using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteGrow : MonoBehaviour {
	public float growRate;
	void Update() {
		transform.localScale += new Vector3(growRate, growRate);
	}
}
