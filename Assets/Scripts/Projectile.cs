using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public int lifetime;
    public Transform owner;
    public bool passthrough;
    public ObjectTag[] canHit;
	void Update () {
        if (lifetime <= 0) {
            IOnObjectDestroyed[] onDestroyed = GetComponents<IOnObjectDestroyed>();
            for(int i = 0; i < onDestroyed.Length; i++) {
                onDestroyed[i].OnObjectDestroyed();
            }
            Destroy(gameObject);
        } else
            lifetime--;
	}
    void OnTriggerEnter2D(Collider2D other) {
        if(lifetime == 0) {
            return;
        }
        if (!Helper.isRelated(owner, other.transform) && matchesCriteria(other.gameObject)) {
            print("Hit " + other.name);
            IHitEffect[] hitEffects = GetComponents<IHitEffect>();
            for(int i = 0; i < hitEffects.Length; i++) {
                hitEffects[i].CreateEffect(GetComponent<Collider2D>().bounds.ClosestPoint(other.bounds.center));
            }
            IDamage[] damageEffects = GetComponents<IDamage>();
            for(int i = 0; i < damageEffects.Length; i++) {
                damageEffects[i].Damage(other.gameObject);
            }
            if(!passthrough) {
                lifetime = 0;
            }
        }
    }
    bool matchesCriteria(GameObject other) {
        ObjectTagSet t = other.GetComponent<ObjectTagSet>();
        if(t) {
            List<ObjectTag> tagList = t.tags;
            foreach(ObjectTag criterion in canHit) {
                if(tagList.Contains(criterion)) {
                    return true;
                }
            }
            return false;
        } else {
            return false;
        }
    }
}
