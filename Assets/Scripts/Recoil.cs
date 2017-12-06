using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour, IOnFireWeapon {
	public float recoil;
	public void OnFireWeapon() {
		transform.parent.GetComponent<Rigidbody2D>().AddForceAtPosition(Helper.PolarOffset2(transform.eulerAngles.z + 180, recoil), transform.position);
	}
}