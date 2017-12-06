using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Allows a Weapon object to automatically fire at missiles that enter the trigger Collider2D
public class SwivelMissileInterceptor : MonoBehaviour {
	public Transform projectile;
	public float speed = 24;
	void OnTriggerEnter2D(Collider2D other) {
		Projectile projectile = other.GetComponent<Projectile>();
		InterceptorShot interceptorShot = other.GetComponent<InterceptorShot>();
		if(projectile && !Helper.isRelated(projectile.owner, transform) && (!interceptorShot || interceptorShot.creator == transform)) {
			print("Intercepting: " + other.name);
			Vector2 velocity = Helper.CalcInterceptShotVelocity(other.transform.position - transform.position, other.GetComponent<Rigidbody2D>().velocity, speed);
			if(velocity != Vector2.zero) {
				GameObject shot = Instantiate(projectile).gameObject;
				shot.GetComponent<Rigidbody2D>().velocity = velocity;
				shot.AddComponent<InterceptorShot>().creator = transform;
			}
		}
	}
}