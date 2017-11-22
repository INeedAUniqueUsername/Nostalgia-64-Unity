using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour, ICapacitor {
    public float capacity;
    public float charge;
    public float GetPowerUse() { return 0; }
    public void Activate() {}
    public float GetCapacity() { return capacity; }
    public float GetCharge() { return charge; }
    public void Recharge(float charge) {
        this.charge += Mathf.Min(charge, this.charge - capacity);
    }
    public void Consume(float charge) {
        this.charge -= Mathf.Min(this.charge, charge);
    }
}
