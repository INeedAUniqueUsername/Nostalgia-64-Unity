using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour, IDrive, IDevice
{
    public Transform exhaust;
    public Vector3 thrustForce;
    public Vector3 exhaustVelocity;
    private double EXHAUST_INTERVAL = 0.1f;
    private double nextExhaust = 0;
    Transform IDrive.GetExhaust() {
        return exhaust;
    }
    Vector3 IDrive.GetForce() {
        return thrustForce;
    }
    Vector3 IDrive.GetPosition() {
        return transform.position;
    }
    void Start () {
		
	}
	void Update () {
		
	}

    public void Activate()
    {
        bool makeExhaust = Time.time > nextExhaust;
        if(makeExhaust) {
            nextExhaust = Time.time + EXHAUST_INTERVAL;
        }

        Transform parent = gameObject.transform.parent;
        Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();
        float z = (transform.eulerAngles.z);
        IDrive d = ((IDrive)this);
        Vector3 pos = d.GetPosition();
        
        Vector3 force_adjusted = Helper.RotatePointAroundOrigin(d.GetForce(), new Vector3(0, 0, z));
        print("Force adjusted: " + force_adjusted);
        rb.AddForceAtPosition(force_adjusted, pos);
        Vector3 velocity_exhaust = Helper.RotatePointAroundOrigin(exhaustVelocity, new Vector3(0, 0, z + 180));
        Transform exhaustType = d.GetExhaust();
        if (exhaustType && makeExhaust) {
            nextExhaust = Time.time + EXHAUST_INTERVAL;

            Transform exhaust = Instantiate(exhaustType);
            
            exhaust.GetComponent<Projectile>().SetOwner(parent);
            exhaust.gameObject.SetActive(true);
            exhaust.position = pos + Helper.PolarOffset(z+180, 0.1f);
            exhaust.GetComponent<Rigidbody2D>().velocity = rb.velocity + new Vector2(velocity_exhaust.x, velocity_exhaust.y);
            exhaust.Rotate(new Vector3(0, 0, z + 90 + Vector3.Angle(Vector3.zero, force_adjusted)));
        }
    }
}
