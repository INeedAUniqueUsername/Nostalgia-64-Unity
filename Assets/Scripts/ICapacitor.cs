using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ICapacitor : IUsable {
    float GetCapacity();
    float GetCharge();
    void Recharge(float charge);
    void Consume(float charge);
}
