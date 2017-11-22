using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrail : MonoBehaviour {
    public Transform effect;
    public int interval;
    protected int next;
	// Update is called once per frame
	void Update () {
        next--;
        if(!(next > 0)) {
            next = interval;
            GameObject trail = Instantiate(effect).gameObject;
            trail.transform.position = transform.position;
            trail.transform.eulerAngles = transform.eulerAngles;
            trail.SetActive(true);
        }
	}
}
