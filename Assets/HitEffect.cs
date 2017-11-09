using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour, IHitEffect {
    public Transform effect;
    public void CreateEffect(Vector3 position) {
        GameObject result = Instantiate(effect).gameObject;
        result.transform.position = position;
        result.SetActive(true);
    }
}
