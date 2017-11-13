using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public int lifetime;
    public int damage;
    public Transform owner;
	// Use this for initialization
	void Start () {
		
	}
	public void SetOwner(Transform owner) {
        this.owner = owner;
    }
	void Update () {
        if (lifetime <= 0) {
            Destroy(gameObject);
        } else
            lifetime--;
	}
    void OnCollisionEnter2D(Collision2D col) {
        Physics2D.IgnoreCollision(col.collider, col.otherCollider, true);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(lifetime == 0) {
            return;
        }
        if (!Helper.isRelated(owner, other.transform) && !other.isTrigger) {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null) {
                damageable.Damage(damage);
            }
            IHitEffect hit = gameObject.GetComponent<IHitEffect>();
            if (hit != null) {
                hit.CreateEffect(GetComponent<Collider2D>().bounds.ClosestPoint(other.bounds.center));
            }
            lifetime = 0;
        }
    }
}
