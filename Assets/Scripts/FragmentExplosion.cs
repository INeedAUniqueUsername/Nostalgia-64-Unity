using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentExplosion : MonoBehaviour, IOnObjectDestroyed {
    public Transform fragment;
    public int count;
    public float speed;
    public float angularVelocity;
    public float radius;
    public void OnObjectDestroyed() {
        float interval = 360F / count;
        for(int i = 0; i < count; i++) {
            float angle = interval * i;
            GameObject projectile = Instantiate(fragment).gameObject;
            projectile.SetActive(true);
            projectile.transform.position = transform.position + Helper.PolarOffset(angle, radius);
            projectile.transform.eulerAngles = new Vector3(0, 0, angle);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = Helper.PolarOffset(angle, speed);
            rb.angularVelocity = angularVelocity;
        }
    }
}
