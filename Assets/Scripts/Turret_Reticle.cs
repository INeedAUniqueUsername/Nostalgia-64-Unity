using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Reticle : MonoBehaviour {
    public Vector3 reticle_offset;
    void SetReticleOffset(Vector3 reticle_offset) {
        this.reticle_offset = reticle_offset;
    }
    void IncReticleOffset(Vector3 reticle_offset) {
        this.reticle_offset += reticle_offset;
    }
    Vector3 GetReticleOffset() {
        return reticle_offset;
    }
    void Update() {
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(reticle_offset.y, reticle_offset.x) * Mathf.Rad2Deg);
    }
}
