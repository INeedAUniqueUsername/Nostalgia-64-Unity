using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Obsolete("Unused", true)]
public class Starship : MonoBehaviour {
    
    //public int rotation_accel = 5;
    
    private DriveController drives;
    private WeaponController weapons;
    void Start() {
        drives = GetComponent<DriveController>();
        weapons = GetComponent<WeaponController>();
    }
    void Update() {
    }
    /*
    public void Thrust() {
        /*
        float facing = transform.rotation.z;
        GetComponent<Rigidbody2D>().AddForce(new Vector3(Mathf.Cos(facing) * thrust_power * Time.deltaTime, Mathf.Sin(facing) * thrust_power * Time.deltaTime));
        *//*
        drives.Fire();
    }
    */
    public void Brake() {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        Vector3 vel = rb2d.velocity;
        float vel_direction = Mathf.Atan2(vel.y, vel.x);
        float vel_speed = Mathf.Sqrt(Mathf.Pow(vel.x, 2) + Mathf.Pow(vel.y, 2));
        float decel_direction = vel_direction + 180;
        rb2d.AddForce(new Vector3(vel_speed * Mathf.Cos(decel_direction), vel_speed * Mathf.Sin(decel_direction)));
        if (rb2d.angularVelocity > 0)
            rb2d.angularVelocity--;
        else if (rb2d.angularVelocity < 0)
            rb2d.angularVelocity++;
    }
    /*
    public void TurnLeft() {
        GetComponent<Rigidbody2D>().angularVelocity += rotation_accel;
    }
    public void TurnRight() {
        GetComponent<Rigidbody2D>().angularVelocity -= rotation_accel;
    }
    */
    public DriveController GetDrives() {
        return drives;
    }
    public WeaponController GetWeapons() {
        return weapons;
    }
}
