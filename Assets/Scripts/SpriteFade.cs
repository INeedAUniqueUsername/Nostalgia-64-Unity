using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFade : MonoBehaviour {
    public float startOpacity = 255;
    public float lifespan;
    private float lifeLeft;

    void Start() {
        print("Sprite Fade created");
        startOpacity /= 255;
        lifeLeft = lifespan;
    }
    public void SetLifeLeft(float lifeLeft) {
        this.lifeLeft = lifeLeft;
    }
    void Update() {
        lifeLeft -= Time.deltaTime * 60;
        if(!(lifeLeft > 0)) {
            Destroy(gameObject);
        }
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, startOpacity * lifeLeft / lifespan);
    }
}
