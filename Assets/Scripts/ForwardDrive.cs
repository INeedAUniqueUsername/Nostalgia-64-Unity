using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardDrive : MonoBehaviour, IDrive, IDevice {
	public Transform exhaust;
	public float force;
    public float exhaustVelocity;
    private double EXHAUST_INTERVAL = 0.1f;
    private double nextExhaust = 0;
    private bool active;
    public Transform GetExhaust() {
        return exhaust;
    }
    public Vector3 GetForce() {
        return new Vector3(force, 0, 0);
    }
    public Vector3 GetAdjustedForce() {
        return Helper.RotatePointAroundOrigin(GetForce(), new Vector3(0, 0, transform.eulerAngles.z));
    }
    public Vector3 GetPosition() {
        return transform.position;
    }
    public Vector3 GetAdjustedPosition() {
        return GetPosition();
    }
    public float GetPowerUse() {
        return 0;
    }
    public void SetActive(bool active) { this.active = active; }
    public bool GetActive() { return active; }
    public void Activate()
    {
        bool makeExhaust = Time.time > nextExhaust;
        if(makeExhaust) {
            nextExhaust = Time.time + EXHAUST_INTERVAL;
        }

        Transform parent = gameObject.transform.parent;
        Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();
        float z = (transform.eulerAngles.z);
        
        Vector3 force_adjusted = Helper.PolarOffset2(z, force);
        //print("Force adjusted: " + force_adjusted);
        rb.AddForce(force_adjusted);

		Vector3 velocity_exhaust = Helper.PolarOffset2(z + 180, exhaustVelocity);
		IDrive d = ((IDrive)this);
        Transform exhaustType = d.GetExhaust();
        if (exhaustType && makeExhaust) {
            nextExhaust = Time.time + EXHAUST_INTERVAL;

            Transform exhaust = Instantiate(exhaustType);
            Vector3 pos = d.GetAdjustedPosition();

            exhaust.GetComponent<Projectile>().owner = parent;
            exhaust.gameObject.SetActive(true);
            exhaust.position = pos + Helper.PolarOffset3(z+180, 0.1f);
            exhaust.GetComponent<Rigidbody2D>().velocity = rb.velocity + new Vector2(velocity_exhaust.x, velocity_exhaust.y);
            exhaust.Rotate(new Vector3(0, 0, z + 90 + Vector3.Angle(Vector3.zero, force_adjusted)));
        }
    }
    void OnDrawGizmosSelected() {
        Vector3 position = ((IDrive)this).GetAdjustedPosition();
        Vector3 force = ((IDrive)this).GetAdjustedForce();
        float z = (transform.eulerAngles.z);
        Gizmos.color = Color.white;
        Gizmos.DrawLine(position, position + Helper.RotatePointAroundOrigin(force, new Vector3(0, 0, z)));
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(position, position + Helper.PolarOffset3(z + 180, exhaustVelocity));
    }
}
