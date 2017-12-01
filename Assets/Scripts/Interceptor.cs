using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Allows a Weapon object to automatically fire at missiles that enter the trigger Collider2D
public class Interceptor : MonoBehaviour {
	public Transform projectile;
	public float speed = 24;
	void OnTriggerEnter2D(Collider2D other) {
		if(other.GetComponent<Projectile>() && !other.GetComponent<InterceptorShot>()) {
			print("Intercepting: " + other.name);
			Vector2 velocity = Helper.CalcInterceptShotVelocity(other.transform.position - transform.position, other.GetComponent<Rigidbody2D>().velocity, speed);
			if(velocity != Vector2.zero) {
				GameObject shot = Instantiate(projectile).gameObject;
				shot.GetComponent<Rigidbody2D>().velocity = velocity;
				shot.AddComponent<InterceptorShot>();
			}
		}
	}
}
class InterceptorShot : MonoBehaviour {}