using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {
	List<IUsable> usables;
	void Start() {
		usables = new List<IUsable>(Helper.InitializeComponents<IUsable>(gameObject));
	}
	void Update () {
		foreach(IUsable usable in usables) {
			usable.Activate();
		}
	}
}
