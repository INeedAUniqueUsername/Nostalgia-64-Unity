using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClearProjectileOwner : MonoBehaviour {
	public int delay;
	void Update() {
		delay--;
		if(delay <= 0) {
			//GetComponent<Projectile>().owner = gameObject.transform;
			GetComponent<Projectile>().owner = null;
			Destroy(this);
		}
	}
}
