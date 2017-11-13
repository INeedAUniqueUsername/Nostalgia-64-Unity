using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScale : MonoBehaviour {
    public float lifespan;
    public float lifeLeft;
	void Start () {
        lifeLeft = lifespan;
	}
	void Update () {
        lifeLeft--;
        if(!(lifeLeft > 0)) {
            Destroy(gameObject);
        }
        float ratio = lifeLeft / lifespan;
        gameObject.transform.localScale = new Vector3(ratio, ratio, ratio);
	}
}
