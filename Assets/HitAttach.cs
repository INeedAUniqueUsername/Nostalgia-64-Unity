using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAttach : MonoBehaviour, IDamage {
	public Transform attachment;
	public void Damage(GameObject other) {
		Transform attached = Instantiate(attachment, other.transform);
		/*
		attached.GetComponent<Attached>().Initialize();
		*/
	}

}
