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
        if ((owner == null || !Helper.isRelated(owner, other.transform)) && matchesCriteria(other.gameObject)) {
            print("Hit " + other.name);
            foreach(IOnProjectileHit projectileHitEvent in other.GetComponents<IOnProjectileHit>()) {
                projectileHitEvent.OnHit(transform);
            }
            foreach(IHitEffect hitEffect in GetComponents<IHitEffect>()) {
                hitEffect.CreateEffect(GetComponent<Collider2D>().bounds.ClosestPoint(other.bounds.center));
            }
            foreach(IDamage damageEffect in GetComponents<IDamage>()) {
                damageEffect.Damage(other.gameObject);
            }
            if(!passthrough && !other.GetComponent<Projectile>()) {
                lifetime = 0;
            }
        }
    }
    bool matchesCriteria(GameObject other) {
        foreach(IHitCriterion criterion in GetComponents<IHitCriterion>()) {
            if(!criterion.Matches(other)) {
                return false;
            }
        }

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
            if(canHit.Length == 0) {
                return true;
            } else {
                return false;
            }
        }
    }
}
