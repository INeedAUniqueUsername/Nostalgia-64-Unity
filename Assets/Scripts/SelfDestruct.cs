using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour, IUsable {
    public void Activate() {
        IDamageable damageable = gameObject.transform.parent.GetComponent<IDamageable>();
        damageable.Damage(int.MaxValue);
    }
}
