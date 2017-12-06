using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentActivator : MonoBehaviour {
	IUsable[] usable;
	void Start() {
		usable = Helper.InitializeComponents<IUsable>(transform.parent.gameObject);
	}
	void Update () {
		foreach(IUsable usable in usable) {
			usable.Activate();
		}
	}
}
