using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IReactor : IUsable, ICapacitor {
    float GetOutput();
}
