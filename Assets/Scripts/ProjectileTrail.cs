using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrail : ObjectTrail {
    void Update() {
        next--;
        if (!(next > 0)) {
            next = interval;
            GameObject trail = Instantiate(effect).gameObject;
            trail.transform.position = transform.position;
            trail.transform.eulerAngles = transform.eulerAngles;
            trail.SetActive(true);
            trail.GetComponent<Projectile>().owner = GetComponent<Projectile>().owner;
        }
    }
}
