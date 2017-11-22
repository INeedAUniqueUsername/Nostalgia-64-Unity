using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Mouse : MonoBehaviour {
    /*
    public Transform weaponObject;
    private IWeapon weapon;

    // Use this for initialization
    void Start() {
        if (weaponObject == null)
            throw new System.Exception("Invalid IWeapon Object");
        weapon = weaponObject.GetComponent<IWeapon>();
        if (weapon == null)
            throw new Exception("Invalid IWeapon");
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diff = mouse - pos;
        weaponObject.eulerAngles = new Vector3(0, 0, Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg);
    }
    */
    void Update() {
        Vector3 pos = transform.position;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diff = mouse - pos;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg);
    }
}
