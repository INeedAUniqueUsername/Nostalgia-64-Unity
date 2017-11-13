using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour, IHitEffect {
    public Transform effect;
    public void CreateEffect(Vector3 position) {
        GameObject result = Instantiate(effect).gameObject;
        result.name = effect.name + " (HitEffect) of " + name;
        result.SetActive(true);
        result.transform.position = position;
    }
}
