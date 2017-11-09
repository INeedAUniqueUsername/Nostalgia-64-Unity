using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour, IDamageable
{
    public double structure;
    void OnCollisionEnter2D(Collision2D col) {
        Damage(col.relativeVelocity.magnitude);
    }
    public void Damage(double damage) {
        structure -= damage;
        if (!(structure > 0))
            Destroy(gameObject);
    }
}
