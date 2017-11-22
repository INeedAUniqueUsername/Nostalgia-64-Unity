using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactor : MonoBehaviour, IReactor {
    public float maxFuel;
    public float fuel;
    public float output;
    public float GetPowerUse() { return 0; }
    public void Activate() {}
    public float GetCapacity() { return maxFuel; }
    public float GetCharge() { return fuel; }
    public float GetOutput() { return Mathf.Min(output, fuel); }
    public void Recharge(float fuel) {
        this.fuel += Mathf.Min(fuel, this.fuel - maxFuel);
    }
    public void Consume(float fuel) {
        this.fuel -= Mathf.Min(this.fuel, fuel);
    }
}
