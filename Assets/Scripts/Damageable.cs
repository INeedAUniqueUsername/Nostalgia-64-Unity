using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour, IDamageable
{
    public double structure;
    public void Damage(double damage) {
        structure -= damage;
        if (!(structure > 0)) {
            IOnObjectDestroyed[] onDestroyed = GetComponents<IOnObjectDestroyed>();
            for (int i = 0; i < onDestroyed.Length; i++) {
                onDestroyed[i].OnObjectDestroyed();
            }
            Destroy(gameObject);
        }
    }
}
