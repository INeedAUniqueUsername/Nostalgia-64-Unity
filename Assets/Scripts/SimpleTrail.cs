using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrail : MonoBehaviour {
    public float interval;
    public float lifetime;
	// Use this for initialization
	void Start () {
        print("Simple Trail created");
    }
	
	// Update is called once per frame
	void Update () {
        interval--;
        if(!(interval > 0)) {
            GameObject result = new GameObject();
            result.SetActive(true);
            result.transform.position = transform.position;
            result.transform.localScale = transform.localScale;
            result.transform.eulerAngles = transform.eulerAngles;
            SpriteRenderer spriteRenderer = result.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = GetComponent<SpriteRenderer>().sprite;
            SpriteFade fade = result.AddComponent<SpriteFade>();
            fade.lifespan = lifetime;
            fade.SetLifeLeft(lifetime);
        }
	}
}
