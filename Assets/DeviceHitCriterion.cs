using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceHitCriterion : MonoBehaviour, IHitCriterion {
	public bool Matches(GameObject other) {
		return other.GetComponent<IDevice>() != null;
	}
}
