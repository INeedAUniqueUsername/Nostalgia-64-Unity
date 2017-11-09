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
    void OnTriggerEnter2D(Collider2D other) {
        
        if (!Helper.isRelated(owner, other.transform) && !other.isTrigger) {
            if (lifetime > 1)
                lifetime = 1;
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
                damageable.Damage(damage);
            IHitEffect hit = gameObject.GetComponent<IHitEffect>();
            if (hit != null) {
                hit.CreateEffect(other.bounds.ClosestPoint(GetComponent<Collider2D>().bounds.center));
            }
        }
    }
}
