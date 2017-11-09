using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Mouse : MonoBehaviour, IWeapon {
    public Transform weaponObject;
    private IWeapon weapon;

    public void Activate() {
        weapon.Activate();
    }

    public int GetCooldown() {
        return weapon.GetCooldown();
    }

    public int GetCooldownLeft() {
        return weapon.GetCooldownLeft();
    }

    public Transform GetProjectile() {
        return weapon.GetProjectile();
    }

    public bool IsReady() {
        return weapon.IsReady();
    }

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
}
