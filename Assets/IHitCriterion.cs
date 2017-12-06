using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitCriterion {
	bool Matches(GameObject other);
}
