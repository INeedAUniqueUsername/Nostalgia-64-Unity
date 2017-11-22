using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPDamage : MonoBehaviour, IDamage {
    public int damage;
    public void Damage(GameObject other) {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if(damageable != null)
            damageable.Damage(damage);
    }
}
