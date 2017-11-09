using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IDrive : IDevice {
    Vector3 GetPosition();
    Vector3 GetForce();
    Transform GetExhaust();
}
