using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveController : MonoBehaviour
{
    public List<GameObject> driveObjects;
    private List<IDrive> drives;
    /*
    [System.Serializable]
    public abstract class ADriveDesc : System.Object
    {
        public abstract Vector3 GetOffset();
        public abstract Vector3 GetForce();
        public abstract Transform GetExhaust();
    }
    [System.Serializable]
    public class DriveDesc : ADriveDesc {
        public Vector3 position;
        public Vector3 force;
        public Transform exhaust;
        public override Vector3 GetOffset() {
            return position;
        }
        public override Vector3 GetForce() {
            return force;
        }
        public override Transform GetExhaust() {
            return exhaust;
        }
    }
    */

    // Use this for initialization
    void Start() {
        drives = Helper.InitializeComponent<IDrive>(driveObjects);
    }

    // Update is called once per frame
    void Update()
    {

    }
    const float EXHAUST_INTERVAL = 0.1f;
    private float nextExhaust = 0;
    public void Activate() {
        //Rigidbody2D rb = GetComponent<Rigidbody2D>();
        bool makeExhaust = Time.time >= nextExhaust;
        if (makeExhaust)
            nextExhaust = Time.time + EXHAUST_INTERVAL;
        for (int i = 0; i < drives.Count; i++) {
            Activate(i);
            /*
            IDrive drive = drives[i];
            float z = (transform.eulerAngles.z);

            Vector3 pos = drive.GetPosition();

            Vector3 force_adjusted = RotatePointAroundPivot(drive.GetForce(), Vector3.zero, new Vector3(0, 0, z));
            print("Force adjusted: " + force_adjusted);
            gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(force_adjusted, pos);
            Vector3 force_exhaust = RotatePointAroundPivot(drive.GetForce(), Vector3.zero, new Vector3(0, 0, z + 180));
            Transform exhaustType = drive.GetExhaust();
            if (exhaustType && makeExhaust) {
                Transform exhaust = Instantiate(exhaustType);
                exhaust.gameObject.SetActive(true);
                nextExhaust = Time.time + EXHAUST_INTERVAL;

                exhaust.position = pos;
                exhaust.GetComponent<Rigidbody2D>().velocity = rb.velocity;
                exhaust.Rotate(new Vector3(0, 0, z + 90 + Vector3.Angle(Vector3.zero, force_adjusted)));
                exhaust.GetComponent<Rigidbody2D>().AddForce(force_exhaust);
            }
            */

            /*
            ADriveDesc d = drives[i];
            float z = (transform.eulerAngles.z);
            Vector3 pos_offset = RotatePointAroundPivot(d.GetOffset(), Vector3.zero, new Vector3(0, 0, z));
            print("Pos offset: " + pos_offset);
            Vector3 pos_adjusted = pos_offset + gameObject.transform.position;
            print("Pos adjusted: " + pos_adjusted);
            Vector3 force_adjusted = RotatePointAroundPivot(d.GetForce(), Vector3.zero, new Vector3(0, 0, z));
            print("Force adjusted: " + force_adjusted);
            gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(force_adjusted, pos_adjusted);
            Vector3 force_exhaust = RotatePointAroundPivot(d.GetForce(), Vector3.zero, new Vector3(0, 0, z + 180));
            Transform exhaustType = d.GetExhaust();
            if (exhaustType && makeExhaust) {
                Transform exhaust = Instantiate(exhaustType);
                nextExhaust = Time.time + EXHAUST_INTERVAL;
                exhaust.GetComponent<Rigidbody2D>().velocity.Set(rb.velocity.x, rb.velocity.y);
                exhaust.Translate(pos_adjusted.x, pos_adjusted.y, pos_adjusted.z);
                exhaust.Rotate(new Vector3(0, 0, z + 90 + Vector3.Angle(Vector3.zero, force_adjusted)));
                exhaust.GetComponent<Rigidbody2D>().AddForce(force_exhaust);
            }
            */
        }

        /*
        float facing = transform.eulerAngles.z * Mathf.Deg2Rad;
        GetComponent<Rigidbody2D>().AddForce(new Vector3(Mathf.Cos(facing) * thrust_power * Time.deltaTime, Mathf.Sin(facing) * thrust_power * Time.deltaTime));
        */
    }
    public void Activate(int i) {
        drives[i].Activate();
    }
}
