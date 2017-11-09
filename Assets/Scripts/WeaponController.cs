using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    public List<GameObject> weaponObjects;
    private List<IWeapon> weapons;
	// Use this for initialization
	void Start () {
        weapons = Helper.InitializeComponent<IWeapon>(weaponObjects);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public int GetWeaponCount() {
        return weapons.Count;
    }
    public void Fire(int i) {
        //print("Firing Weapon " + i);
        weapons[i].Activate();
    }
}
