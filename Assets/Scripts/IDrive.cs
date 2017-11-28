using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IDrive : IDevice {
    Vector3 GetPosition();
    Vector3 GetAdjustedPosition();
    Vector3 GetForce();
    Vector3 GetAdjustedForce();
    Transform GetExhaust();
}
